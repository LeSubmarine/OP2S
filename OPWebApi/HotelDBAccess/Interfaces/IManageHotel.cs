using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelModels;

namespace HotelDBAccess.Interfaces
{
    public interface IManageHotel
    {
        /// <summary>
        /// henter alle hoteller fra databasen
        /// </summary>
        /// <returns>Liste af hoteller</returns>
        List<Hotel> GetAllHotel();

        /// <summary>
        /// Henter et specifikt hotel fra database 
        /// </summary>
        /// <param name="hotelNr">Udpeger det hotel der ønskes fra databasen</param>
        /// <returns>Det fundne hotel eller null hvis hotellet ikke findes</returns>
        Hotel GetHotelFromId(int hotelNr);

        /// <summary>
        /// Indsætter et nyt hotel i databasen
        /// </summary>
        /// <param name="hotel">Hotellet der skal indsættes</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool CreateHotel(Hotel hotel);

        /// <summary>
        /// Opdaterer et hotel i databasen
        /// </summary>
        /// <param name="hotel">De nye værdier til hotellet</param>
        /// <param name="hotelNr">Nummer på det hotel der skal opdateres</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool UpdateHotel(Hotel hotel, int hotelNr);

        /// <summary>
        /// Sletter et hotel fra databasen
        /// </summary>
        /// <param name="hotelNr">Nummer på det hotel der skal slettes</param>
        /// <returns>Det hotel der er slettet fra databasen, returnere null hvis hotellet ikke findes</returns>
        Hotel DeleteHotel(int hotelNr);
    }
}
