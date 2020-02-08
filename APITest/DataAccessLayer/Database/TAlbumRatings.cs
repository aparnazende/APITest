using System;
using System.Collections.Generic;

namespace DataAccessLayer.Database
{
    public partial class TAlbumRatings:IEntityBase
    {
        public int Id { get; set; }
        public byte Rating { get; set; }
        public int AlbumId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public TAlbums Album { get; set; }
    }
}
