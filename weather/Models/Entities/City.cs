using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class City
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int FavouriteId { get; set; }

        public Favourite Favourite { get; set; }
    }
}
