using System;

namespace ForumSystem.Data.Common
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }
        bool PreserveCreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}