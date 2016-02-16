using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Settings;
using System.IO;
using System.Xml.Serialization;

namespace KonigLabs.SpriteEvent.CommonViewModels.Providers
{
    public class SettingsProvider
    {
        

        public virtual CameraSettingsDto GetCameraSettings()
        {
            CameraSettingsDto settings = null;
            if (File.Exists("CameraPhotoSettings.xml"))
            {
                using (var fs = File.OpenRead("CameraPhotoSettings.xml"))
                {
                    settings = (CameraSettingsDto)new XmlSerializer(typeof(CameraSettingsDto)).Deserialize(fs);
                }
            }
            else
            {
                settings = new CameraSettingsDto
                {
                    SelectedAeMode = SDKData.Enums.AEMode.Manual,
                    SelectedAvValue = SDKData.Enums.ApertureValue.AV_8,
                    SelectedIsoSensitivity = SDKData.Enums.CameraISOSensitivity.ISO_400,
                    SelectedWhiteBalance = SDKData.Enums.WhiteBalance.Daylight,
                    SelectedShutterSpeed = SDKData.Enums.ShutterSpeed.TV_200,
                };
                using (var fs = File.Open("CameraPhotoSettings.xml", FileMode.OpenOrCreate))
                {
                    new XmlSerializer(typeof(CameraSettingsDto)).Serialize(fs, settings);
                }
            }
            return settings;
        }

    }
}
