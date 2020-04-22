using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class Room
    {
        public int Room_Id { get; set; }
        public int Hotel_No { get; set; }
        public char Types { get; set; }
        public int Room_No { get; set; }
        public int Price { get; set; }
    }
}
