using KonigLabs.SpriteEvent.SDKData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.ViewModel.Settings
{
    public class CameraSettingsDto
    {
        public AEMode SelectedAeMode { get; set; }

        public ExposureCompensation SelectedCompensation { get; set; }

        public WhiteBalance SelectedWhiteBalance { get; set; }

        public CameraISOSensitivity SelectedIsoSensitivity { get; set; }

        public ShutterSpeed SelectedShutterSpeed { get; set; }

        public ApertureValue SelectedAvValue { get; set; }
    }
}
