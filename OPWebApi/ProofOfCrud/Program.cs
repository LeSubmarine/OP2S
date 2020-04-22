using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HotelModels;

namespace ProofOfCrud
{
    class Program
    {
        const string serverUrl = "http://localhost:52808/";
        
        static void Main(string[] args)
        {


            #region Create

            Console.WriteLine("This is all the facilities:");
            ReadFacilities();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Here we CREATE a test facility");
            string ApiAddress = "api/Facility";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            var objectForPosting = new Facility {Facility_No = 10,Types = "TestFacility"};
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.PostAsJsonAsync(ApiAddress, objectForPosting).Result;
                    string result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            Console.WriteLine("Now this is all the facilities:");
            ReadFacilities();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Read

            Console.WriteLine("Now we READ all the elements in the facility table:");
            ReadFacilities();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Now we READ all the elements in the hotel table:");
            ReadHotels();
            Console.WriteLine();
            Console.WriteLine();

            #endregion


            #region Update
            Console.WriteLine("Here we UPDATE the test facility");
            ApiAddress = "api/Facility/10";
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            var objectForPuting = new Facility { Facility_No = 10, Types = "updated TestFacility" };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.PutAsJsonAsync(ApiAddress, objectForPuting).Result;
                    string result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            Console.WriteLine("Now this is all the facilities:");
            ReadFacilities();
            Console.WriteLine();
            Console.WriteLine();
            #endregion


            #region Delete

            Console.WriteLine("Here we DELETE the test facility:");
            ApiAddress = "api/Facility";
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            var idForDeletion = 10;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.DeleteAsync(ApiAddress + "/10").Result;
                    string result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            ReadFacilities();
            #endregion

            Console.ReadLine();
        }

        static void ReadHotels()
        {
            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var responce = client.GetAsync("api/Hotel").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var hotels = responce.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        foreach (var hotel in hotels)
                        {
                            Console.WriteLine(hotel);
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        static void ReadFacilities()
        {
            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var responce = client.GetAsync("api/Facility").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var facilities = responce.Content.ReadAsAsync<IEnumerable<Facility>>().Result;
                        foreach (var facility in facilities)
                        {
                            Console.WriteLine(facility);
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
