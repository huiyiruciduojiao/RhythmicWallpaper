using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;


namespace AudioWallpaperManager {
    public class ChangeOutputDevices : IMMNotificationClient {
        Manager manager;
        public ChangeOutputDevices(Manager manager) {
            this.manager = manager;
        }

        public void OnDeviceStateChanged(string deviceId, DeviceState newState) {
            manager.DevicesStateChanged();
        }

        public void OnDeviceAdded(string pwstrDeviceId) {
            manager.DevicesStateChanged();
        }

        public void OnDeviceRemoved(string deviceId) {
            manager.DevicesStateChanged();
        }

        public void OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId) {
            manager.DevicesStateChanged();
        }

        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key) {
            return;
        }
    }
}
