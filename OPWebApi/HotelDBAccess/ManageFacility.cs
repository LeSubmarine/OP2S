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
    public class ManageFacility : IManageFacility
    {
        string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OPDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        string ConnectionString
        {
            get => _connectionString;
        }

        public int ExecuteNonQueryFacility(string queryString)
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

        public bool CreateFacility(Facility facility)
        {
            //Insert into Hotel Values(xx, yy, zz, ...)
            //throw new NotImplementedException();

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $"INSERT INTO Facility VALUES({facility.Facility_No}, '{facility.Types}')";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }

            return (rowsAffected == 1);
        }

        public Facility DeleteFacility(int facilityNr)
        {
            Facility facility = GetFacilityFromId(facilityNr);
            ExecuteNonQueryFacility($"DELETE FROM Facility WHERE Facility_No={facilityNr}");
            return facility;
        }

        public List<Facility> GetAllFacility()
        {
            List<Facility> facilityList = new List<Facility>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                string queryString = "select * from Facility";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                //command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Facility curFacility = new Facility();

                    curFacility.Facility_No = reader.GetInt32(0); //læser int fra første søjle
                    curFacility.Types = reader.GetString(1); //læser string fra anden søjle

                    facilityList.Add(curFacility);
                }
            }

            return facilityList;
        }

        public Facility GetFacilityFromId(int facilityNr)
        {
            Facility facility = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                string queryString = $"select * from Facility where Facility_No = {facilityNr}";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                //command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    facility = new Facility();

                    facility.Facility_No = reader.GetInt32(0); //læser int fra første søjle
                    facility.Types = reader.GetString(1); //læser string fra anden søjle
                    
                }
            }

            return facility;
        }

        public bool UpdateFacility(Facility facility, int facilityNr)
        {
            int rowsAffected = ExecuteNonQueryFacility($"UPDATE Facility SET types='{facility.Types}', WHERE Facility_No={facilityNr}");
            return (rowsAffected == 1);
        }
    }
}
