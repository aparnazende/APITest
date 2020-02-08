using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AlbumViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Review { get; set; }
        public string BannerURL { get; set; }
        public int ArtistId { get; set; }
        
    }
}
