using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace IoT_casus_Application2
{
    class DAL
    {
        public static string connectionString = "Data Source =.; Initial Catalog = Hospital_B2D4; Integrated Security = True;";
        public List<DeviceDataBase> AllDevicesDataBase = new List<DeviceDataBase>();
        public List<RoomDataBaSE> AllRoomsDataBase = new List<RoomDataBaSE>();
        public DAL()
        {
        }



        public void RetrieveAllRooms()
        {
            AllRoomsDataBase.Clear();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cnn.ConnectionString = connectionString;
                    cnn.Open();
                    cmd.Connection = cnn;
                    //toevoegen query als database er is
                    cmd.CommandText = "SELECT domoticzRoomId, RoomName, FloorId, roomId FROM Rooms_table";
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            //toevoegen variablen als database er is
                            AllRoomsDataBase.Add(new RoomDataBaSE(Int32.Parse(dataReader[0].ToString())
                                                              , dataReader[1].ToString(),
                                                               Int32.Parse(dataReader[2].ToString()), 
                                                               Int32.Parse(dataReader[3].ToString())
                                                               )
                                             );
                        }
                    }
                    cnn.Close();
                }
            }
        }





        public void RetrieveAllDevices()
        {
            AllDevicesDataBase.Clear();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cnn.ConnectionString = connectionString;
                    cnn.Open();
                    cmd.Connection = cnn;
                    //toevoegen query als database er is
                    cmd.CommandText = "SELECT Devices_table.domoticzId, Devices_table.deviceType, " +
                        "Devices_table.deviceName, Devices_table.status, Rooms_table.roomId " +
                        "FROM Rooms_table " +
                        "INNER JOIN Devices_table " +    
                        "ON Rooms_table.roomID = Devices_table.roomId;	";
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            //toevoegen variablen als database er is
                            AllDevicesDataBase.Add(new DeviceDataBase(Int32.Parse(dataReader[0].ToString())
                                                              ,dataReader[1].ToString(),
                                                               dataReader[2].ToString(),
                                                               dataReader[3].ToString(),
                                                               Int32.Parse(dataReader[4].ToString()) 
                                                               
                                                               )
                                             );
                        }
                    }
                    cnn.Close();
                }
            }
        }

        public void AddRoom(int domoticzRoomId, string roomName) 
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = connectionString;
            cnn.Open();
            string sql = "INSERT INTO Rooms_table (domoticzRoomId, roomName, floorId) VALUES (@domoticzRoomId, @roomName, @floorId)";

            using (SqlCommand cmd = new SqlCommand(sql, cnn))
            {
                cmd.Parameters.AddWithValue("@domoticzRoomId", domoticzRoomId);
                cmd.Parameters.AddWithValue("@roomName", roomName);
                cmd.Parameters.AddWithValue("@floorId", 1);
                cmd.ExecuteNonQuery();
            }
            cnn.Close();
        }

        public void AddDevice(int domoticzId, string deviceType, string deviceName, string status,int roomId) 
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = connectionString;
            cnn.Open();
            string sql = "INSERT INTO Devices_table (domoticzId, deviceType, deviceName, status, roomId) VALUES (@domoticzId, @deviceType, @deviceName, @status, @roomId)";
            
            using (SqlCommand cmd = new SqlCommand(sql, cnn))
            {
                cmd.Parameters.AddWithValue("@domoticzId", domoticzId);
                cmd.Parameters.AddWithValue("@deviceType", deviceType);
                cmd.Parameters.AddWithValue("@deviceName", deviceName);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@roomId", roomId);

                cmd.ExecuteNonQuery();
            }
            cnn.Close();
        }

    }
}
