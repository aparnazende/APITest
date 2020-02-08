using System;
using System.Collections.Generic;

namespace DataAccessLayer.Database
{
    public partial class TGenres : IEntityBase
    {
        public TGenres()
        {
            TArtists = new HashSet<TArtists>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public TCategory Category { get; set; }
        public ICollection<TArtists> TArtists { get; set; }
    }
}
