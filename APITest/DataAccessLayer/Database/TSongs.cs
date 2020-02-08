using System;
using System.Collections.Generic;

namespace DataAccessLayer.Database
{
    public partial class TSongs : IEntityBase
    {
        public TSongs()
        {
            TSongRatings = new HashSet<TSongRatings>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public decimal Price { get; set; }
        public int AlbumId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public TAlbums Album { get; set; }
        public ICollection<TSongRatings> TSongRatings { get; set; }
    }
}
