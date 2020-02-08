using System;

namespace DataAccessLayer
{
    public interface IEntityBase
    {
        int Id { get; set; }
        int CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
