using System;
using System.Collections.Generic;

namespace ViewModel
{
    public class SongsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public decimal Price { get; set; }
        public int AlbumId { get; set; }       
        public dynamic SongRatings { get; set; }
    }
   
}
