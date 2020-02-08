using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Database
{
    public partial class TAlbums:IEntityBase
    {
        public TAlbums()
        {
            TAlbumRatings = new HashSet<TAlbumRatings>();
            TSongs = new HashSet<TSongs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Review { get; set; }
        [ForeignKey("TArtists")]
        public int ArtistId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public TArtists Artist { get; set; }
        public ICollection<TAlbumRatings> TAlbumRatings { get; set; }
        public ICollection<TSongs> TSongs { get; set; }
    }
}
