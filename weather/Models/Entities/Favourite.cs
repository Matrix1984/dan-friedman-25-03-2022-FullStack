using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Favourite
    {
        public int FavouriteId { get; set; }
         
        public IList<City> Cities { get; set; }
    }
}
