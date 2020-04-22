using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class Facility
    {
        public int Facility_No { get; set; }
        public string Types { get; set; }

        public override string ToString()
        {
            return $"{nameof(Facility_No)}: {Facility_No}, {nameof(Types)}: {Types}";
        }
    }
}
