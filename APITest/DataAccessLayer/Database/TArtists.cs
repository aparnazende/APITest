using System;
using System.Collections.Generic;

namespace DataAccessLayer.Database
{
    public partial class TArtists : IEntityBase
    {
        public TArtists()
        {
            TAlbums = new HashSet<TAlbums>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public TGenres Genre { get; set; }
        public ICollection<TAlbums> TAlbums { get; set; }
    }
}
