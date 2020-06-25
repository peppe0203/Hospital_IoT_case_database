using System;
using System.Collections.Generic;
using System.Text;

namespace IoT_casus_Application2
{
    class RoomDataBaSE
    {
        private int _domoticzRoomId;
        private string _roomName;
        private int _floorId;
        private int _roomId;

        public RoomDataBaSE(int domoticzRoomId, string roomName, int FloorId, int roomId) 
        {
            _domoticzRoomId = domoticzRoomId;
            _roomName = roomName;
            _floorId = FloorId;
            _roomId = roomId;
        }

        public int GetDomoticzRoomId() 
        {
            return _domoticzRoomId;
        }
        public int GetRoomId()
        {
            return _roomId;
        }

    }
}
