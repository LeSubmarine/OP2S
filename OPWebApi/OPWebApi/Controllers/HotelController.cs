using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDBAccess;
using HotelModels;

namespace OPWebApi.Controllers
{
    public class HotelController : ApiController
    {
        // GET: api/Hotel
        public IEnumerable<Hotel> Get()
        {
            return (new ManageHotel()).GetAllHotel();
        }

        // GET: api/Hotel/5
        public Hotel Get(int id)
        {
            return (new ManageHotel()).GetHotelFromId(id);
        }

        // POST: api/Hotel
        public void Post([FromBody]Hotel value)
        {
            new ManageHotel().CreateHotel(value);
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]Hotel value)
        {
            new ManageHotel().UpdateHotel(value, id);
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
            new ManageHotel().DeleteHotel(id);
        }
    }
}
