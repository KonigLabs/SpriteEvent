using KonigLabs.SpriteEvent.ViewModel.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KonigLabs.SpriteEvent.ViewModel.Providers
{
    public class SettingsProvider
    {
        public CameraSettingsDto GetCameraSettings()
        {
            CameraSettingsDto settings = null;
            if (!File.Exists("CameraPhotoSettings.xml"))
            {
                settings = new CameraSettingsDto
                {
                    SelectedAeMode = SDKData.Enums.AEMode.Manual,
                    SelectedAvValue = SDKData.Enums.ApertureValue.AV_8,
                    SelectedIsoSensitivity = SDKData.Enums.CameraISOSensitivity.ISO_400,
                    SelectedWhiteBalance = SDKData.Enums.WhiteBalance.Daylight,
                    SelectedShutterSpeed = SDKData.Enums.ShutterSpeed.TV_200,
                    SelectedCompensation = SDKData.Enums.ExposureCompensation.Zero
                };
                using (var file = File.Create("CameraPhotoSettings.xml"))
                {
                    new XmlSerializer(settings.GetType()).Serialize(file, settings);
                    file.Close();
                }

            }
            else {
                using (var file = File.OpenRead("CameraPhotoSettings.xml"))
                {
                    settings = (CameraSettingsDto)new XmlSerializer(typeof(CameraSettingsDto)).Deserialize(file);
                    file.Close();
                }
            }
            return settings;
        }
    }
}
