using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class AlbumDataViewModel
    {
        public AlbumViewModel Album { get; set; }
        public ArtistViewModel Artist { get; set; }
        public GenreViewModel Genre { get; set; }
        public CategoryViewModel Category { get; set; }
        public List<SongsViewModel> Songs { get; set; }
    }
}
