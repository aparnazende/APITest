using System;
using System.Collections.Generic;

namespace DataAccessLayer.Database
{
    public partial class TCategory : IEntityBase
    {
        public TCategory()
        {
            TGenres = new HashSet<TGenres>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ICollection<TGenres> TGenres { get; set; }
    }
}
