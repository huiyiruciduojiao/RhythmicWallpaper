namespace AudioWallpaper.Entity {
    [Serializable]
    public class ConfigurationObject {
        private GeneralConfigurationObjects? generalConfigurationObjects;
        private VideoWallpaperConfigObject? videoWallpaperConfigObject;
        public bool DeviceStateChange = false;
        public bool SignRenderingStatus = false;
        public bool RenderingStatus = true;

        public GeneralConfigurationObjects GeneralConfigurationObjects {
            get {
                if (generalConfigurationObjects != null) {
                    return generalConfigurationObjects;
                }
                return new GeneralConfigurationObjects();
            }
            set {
                if (value != null) {
                    generalConfigurationObjects = value;
                } else {
                    generalConfigurationObjects = new GeneralConfigurationObjects();
                }

            }
        }
        public VideoWallpaperConfigObject VideoWallpaperConfigObject {
            get {
                if (videoWallpaperConfigObject != null) {
                    return videoWallpaperConfigObject;
                }
                return new VideoWallpaperConfigObject();
            }
            set {
                if (value != null) {
                    videoWallpaperConfigObject = value;
                } else {
                    videoWallpaperConfigObject = new VideoWallpaperConfigObject();
                }
            }
        }

    }
}
