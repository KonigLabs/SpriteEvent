﻿using KonigLabs.SpriteEvent.CommonViewModels.Messenger;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Dialogs;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Factories;

namespace KonigLabs.SpriteEvent.CommonViewModels.Services
{
    public interface IDialogService
    {
        bool ShowConfirmationDialog(string message);

        void SetWindowCloseState(bool state);

        bool ShowResultDialog(ResultBaseViewModel viewModel);

        void ShowInfo(string info);
    }

    public class DialogService : IDialogService
    {
        private readonly IMessenger _messenger;
        private readonly IChildrenViewModelsFactory _viewModelFactory;

        public DialogService(IMessenger messenger, IChildrenViewModelsFactory viewModelFactory)
        {
            _messenger = messenger;
            _viewModelFactory = viewModelFactory;
        }

        public bool ShowConfirmationDialog(string messageText)
        {
            ShowChildWindowMessage message = _messenger.CreateMessage<ShowChildWindowMessage>();
            ConfirmDialogViewModel viewModel = (ConfirmDialogViewModel) _viewModelFactory.GetChild<ConfirmDialogViewModel>(messageText);
            message.Content = viewModel;
            message.IsDialog = true;
            _messenger.Send(message);
            return viewModel.Status;
        }

        public void SetWindowCloseState(bool state)
        {
            var message = _messenger.CreateMessage<WindowStateMessage>();
            message.State = state;
            _messenger.Send(message);
        }

        public bool ShowResultDialog(ResultBaseViewModel contentViewModel)
        {
            ShowChildWindowMessage message = _messenger.CreateMessage<ShowChildWindowMessage>();
            ResultDialogViewModel viewModel = (ResultDialogViewModel)_viewModelFactory.GetChild<ResultDialogViewModel>(contentViewModel);
            message.Content = viewModel;
            message.IsDialog = true;
            _messenger.Send(message);
            return viewModel.Status;
        }

        public void ShowInfo(string info)
        {
            ShowChildWindowMessage message = _messenger.CreateMessage<ShowChildWindowMessage>();
            InfoDialogViewModel viewModel = (InfoDialogViewModel)_viewModelFactory.GetChild<InfoDialogViewModel>(info);
            message.Content = viewModel;
            message.IsDialog = false;
            _messenger.Send(message);
        }
    }
}
