using System;
using System.Collections.Generic;
using System.Text;

namespace IoT_casus_Application2
{
    class DeviceDataBase
    {
        private int _domoticzId;
        private string _deviceType;
        private string _deviceName;    
        private string _status;
        private int _roomId;

        public DeviceDataBase(int domoticzId, string deviceType, string deviceName, string status, int roomId) 
        {
            _domoticzId = domoticzId;
            _deviceType = deviceType;
            _deviceName = deviceName;
            _status = status;
            _roomId = roomId;
        }

        public int GetdomoticzId() 
        {
            return _domoticzId;
        }
    }
}
