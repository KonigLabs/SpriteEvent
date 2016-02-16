﻿
using KonigLabs.SpriteEvent.PatternProcessing.ImageProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonigLabs.SpriteEvent.PatternProcessing.Dto;
using System.Threading;
using KonigLabs.SpriteEvent.PatternProcessing;
using KonigLabs.SpriteEvent.CommonViewModels.Async;
using KonigLabs.SpriteEvent.ViewModel.Providers;
using KonigLabs.SpriteEvent.ViewModel.Settings;
using GalaSoft.MvvmLight.Command;
using System.Monads;
using KonigLabs.SpriteEvent.SDKData.Enums;
using KonigLabs.SpriteEvent.SDKData.Events;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Navigation;

namespace KonigLabs.SpriteEvent.ViewModel.ViewModels
{
    public class TakePhotoViewModel:BaseViewModel
    {

        private const int CDefWidth = 2048;
        private const int CDefHeight = 1536;

        private CameraSettingsDto _settings;
        private  SettingsProvider _settingsProvider;
        //private readonly IDialogService _dialogService;
        private IViewModelNavigator _navigator;
        private CompositionModelProcessor _imageProcessor;
        private int _width;
        private int _height;
        private int _imageNumber;

        private RelayCommand _goBackCommand;
        private RelayCommand _openSessionCommand;
        private RelayCommand _closeSessionCommand;
        private RelayCommand _refreshCameraCommand;
        private RelayCommand _startLiveViewCommand;
        private IAsyncCommand _takePictureCommand;
        private RelayCommand<uint> _setFocusCommand;

        private byte[] _liveViewImageStream;

        private bool _sessionOpened;
        private bool _takingPicture;
        private bool _isLiveViewOn;
        private int _counter;

        static AutoResetEvent _cameraStreamSynchronize;
        public TakePhotoViewModel(
            IViewModelNavigator navigator,
            CompositionModelProcessor imageProcessor,
            SettingsProvider settingsProvider
            )
        {
            _settingsProvider = settingsProvider;
            _navigator = navigator;
            _imageProcessor = imageProcessor;

            _width = CDefWidth;
            _height = CDefHeight;
        }

        public override void Initialize()
        {
            _imageProcessor.TimerElapsed += ImageProcessorOnTimerElapsed;
            _imageProcessor.CameraErrorEvent += ImageProcessorOnCameraErrorEvent;
            _imageProcessor.ImageChanged += ImageProcessorOnStreamChanged;
            _imageProcessor.ImageNumberChanged += ImageProcessorOnImageNumberChanged;


            _imageProcessor.InitializeProcessor();
            OpenSession();
            if (!_sessionOpened)
                return;

            _settings = _settingsProvider.GetCameraSettings();

            if (_settings != null)
            {
                _imageProcessor.SetSetting((uint)PropertyId.AEMode, (uint)_settings.SelectedAeMode);
                _imageProcessor.SetSetting((uint)PropertyId.WhiteBalance, (uint)_settings.SelectedWhiteBalance);
                _imageProcessor.SetSetting((uint)PropertyId.Av, (uint)_settings.SelectedAvValue);
                _imageProcessor.SetSetting((uint)PropertyId.ExposureCompensation, (uint)_settings.SelectedCompensation);
                _imageProcessor.SetSetting((uint)PropertyId.ISOSpeed, (uint)_settings.SelectedIsoSensitivity);
                _imageProcessor.SetSetting((uint)PropertyId.Tv, (uint)_settings.SelectedShutterSpeed);
            }
            _cameraStreamSynchronize = new AutoResetEvent(false);
            StartLiveView();
        }

        private void ImageProcessorOnImageNumberChanged(object sender, int newValue)
        {
            ImageNumber = newValue;
        }

        public override void Dispose()
        {
            _imageProcessor.TimerElapsed -= ImageProcessorOnTimerElapsed;
            _imageProcessor.CameraErrorEvent -= ImageProcessorOnCameraErrorEvent;
            _imageProcessor.ImageChanged -= ImageProcessorOnStreamChanged;
            _imageProcessor.ImageNumberChanged -= ImageProcessorOnImageNumberChanged;

            _sessionOpened = false;
            TakingPicture = false;
            _isLiveViewOn = false;
            _imageProcessor.Dispose();
        }

        private void ImageProcessorOnTimerElapsed(object sender, int tick)
        {
            Counter = tick;
        }

        private void ImageProcessorOnCameraErrorEvent(object sender, CameraEventBase cameraErrorInfo)
        {
            switch (cameraErrorInfo.EventType)
            {
                case CameraEventType.Shutdown:
                    TakingPicture = false;
                    //_dialogService.ShowInfo(cameraErrorInfo.Message);
                    Dispose();
                    break;
                case CameraEventType.Error:
                    TakingPicture = false;

                    ErrorEvent ev = cameraErrorInfo as ErrorEvent;
                    if (ev != null && ev.ErrorCode == ReturnValue.TakePictureAutoFocusNG)
                    {
                       // _dialogService.ShowInfo("Не удалось сфокусироваться. Пожалуйста, повторите попытку.");
                        Dispose();
                        Initialize();
                    }
                    break;
            }
        }

        private void ImageProcessorOnStreamChanged(object sender, ImageDto image)
        {
            Width = image.Width;
            Height = image.Height;
            LiveViewImageStream = image.ImageData;
            if (LiveViewImageStream.Length > 0)
                _cameraStreamSynchronize.Set();
        }

        private async Task<byte[]> TakePicture(CancellationToken token)
        {
            return await Task.Run(() =>
            {
                TakingPicture = true;

                token.ThrowIfCancellationRequested();
                _cameraStreamSynchronize.WaitOne();
                token.ThrowIfCancellationRequested();
                TakingPicture = false;
                var result = LiveViewImageStream.ToArray();
                _navigator.NavigateForward<TakePhotoResultViewModel>(this, result);
                return result;
            }, token);
        }

        private void StartLiveView()
        {
            _imageProcessor.StartLiveView();
            _isLiveViewOn = true;
        }

        private void RefreshCamera()
        {
            _imageProcessor.RefreshCamera();
        }

        private void CloseSession()
        {
            _imageProcessor.CloseSession();
            _sessionOpened = false;
        }

        private void OpenSession()
        {
            bool result = _imageProcessor.OpenSession();
            if (!result)
            {
                //_dialogService.ShowInfo("Камера отсутствует или не готова");
                GoBack();
                return;
            }

            _sessionOpened = true;
        }

        private void GoBack()
        {
            _cameraStreamSynchronize.Do(x => x.Set());

            AsyncCommand<Task<CompositionProcessingResult>> takePictireCmd = ((AsyncCommand<Task<CompositionProcessingResult>>)TakePictureCommand);
            if (takePictireCmd.CancelCommand.CanExecute(null))
                takePictireCmd.CancelCommand.Execute(null);
            _navigator.NavigateBack(this);
        }


        public int Counter
        {
            get { return _counter; }
            set { Set(() => Counter, ref _counter, value); }
        }


        public bool TakingPicture
        {
            get { return _takingPicture; }
            set
            {
                if (_takingPicture == value)
                    return;

                _takingPicture = value;
                RaisePropertyChanged();
                RaisePropertyChanged(() => NotTakingPicture);
            }
        }

        public bool NotTakingPicture
        {
            get { return !TakingPicture; }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                Set(() => Width, ref _width, value);
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                Set(() => Height, ref _height, value);
            }
        }

        public int ImageNumber
        {
            get { return _imageNumber; }
            set { Set(() => ImageNumber, ref _imageNumber, value); }
        }

        public byte[] LiveViewImageStream
        {
            get { return _liveViewImageStream; }
            set
            {
                _liveViewImageStream = value;
                RaisePropertyChanged();
            }
        }

        public IAsyncCommand TakePictureCommand
        {
            get { return _takePictureCommand ?? (_takePictureCommand = AsyncCommand.Create<Task<CompositionProcessingResult>>(t => TakePicture(t), () => _sessionOpened && !TakingPicture)); }
        }


        private void SetFocus(uint focus)
        {
            _imageProcessor.SetFocus(focus);
        }

        private IList<uint> _focusPoints;


        public IList<uint> FocusPoints
        {
            get { return _focusPoints ?? (_focusPoints = Enum.GetValues(typeof(LiveViewDriveLens)).OfType<uint>().ToList()); }
        }

        public RelayCommand<uint> SetFocusCommand
        {
            get
            {
                return _setFocusCommand ?? (_setFocusCommand = new RelayCommand<uint>(SetFocus,
                    (x) => _sessionOpened && !TakingPicture && _isLiveViewOn));
            }
        }

        public RelayCommand GoBackCommand
        {
            get { return _goBackCommand ?? (_goBackCommand = new RelayCommand(GoBack)); }
        }

        public RelayCommand OpenSessionCommand
        {
            get { return _openSessionCommand ?? (_openSessionCommand = new RelayCommand(OpenSession, () => true)); } //todo
        }

        public RelayCommand CloseSessionCommand
        {
            get { return _closeSessionCommand ?? (_closeSessionCommand = new RelayCommand(CloseSession, () => _sessionOpened && !TakingPicture)); }
        }

        public RelayCommand RefreshCameraCommand
        {
            get { return _refreshCameraCommand ?? (_refreshCameraCommand = new RelayCommand(RefreshCamera, () => _sessionOpened && !TakingPicture)); }
        }

        public RelayCommand StartLiveViewCommand
        {
            get { return _startLiveViewCommand ?? (_startLiveViewCommand = new RelayCommand(StartLiveView, () => _sessionOpened && !TakingPicture)); }
        }

    }
}
