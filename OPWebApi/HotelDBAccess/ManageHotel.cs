using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDBAccess.Interfaces;
using HotelModels;

namespace HotelDBAccess
{
    public class ManageHotel : IManageHotel
    {
        string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OPDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        string ConnectionString
        {
            get => _connectionString;
        }

        public int ExecuteNonQueryHotel(string queryString)
        {
            int rowsAffected = (-1);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                command.Connection.Close();
            }
            return rowsAffected;
        }

        public bool CreateHotel(Hotel hotel)
        {
            //Insert into Hotel Values(xx, yy, zz, ...)
            //throw new NotImplementedException();

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $"insert into DemoGuest Values({hotel.Hotel_No}, '{hotel.Name}','{hotel.Address}')";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }

            return (rowsAffected == 1);
        }

        public Hotel DeleteHotel(int hotelNr)
        {
            Hotel hotel = GetHotelFromId(hotelNr);
            ExecuteNonQueryHotel($"DELETE FROM Hotel WHERE Hotel_No={hotelNr}");
            return hotel;
        }

        public List<Hotel> GetAllHotel()
        {
            List<Hotel> hotelList = new List<Hotel>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                string queryString = "select * from Hotel";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                //command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Hotel curHotel = new Hotel();

                    curHotel.Hotel_No = reader.GetInt32(0); //læser int fra første søjle
                    curHotel.Name = reader.GetString(1); //læser string fra anden søjle
                    curHotel.Address = reader.GetString(2);

                    hotelList.Add(curHotel);
                }
            }

            return hotelList;
        }

        public Hotel GetHotelFromId(int hotelNr)
        {
            Hotel hotel = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                string queryString = $"SELECT * FROM Hotel WHERE Hotel_No = {hotelNr}";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                //command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    hotel = new Hotel();

                    hotel.Hotel_No = reader.GetInt32(0); //læser int fra første søjle
                    hotel.Name = reader.GetString(1); //læser string fra anden søjle
                    hotel.Address = reader.GetString(2);
                }
            }

            return hotel;
        }

        public bool UpdateHotel(Hotel hotel, int hotelNr)
        {
            int rowsAffected = ExecuteNonQueryHotel($"UPDATE Hotel SET name='{hotel.Name}', address='{hotel.Address}' WHERE Hotel_No={hotelNr}");
            return (rowsAffected == 1);
        }
    }
}
