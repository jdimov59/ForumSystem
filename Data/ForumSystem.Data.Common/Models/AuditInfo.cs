using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Data.Common
{
    public abstract class AuditInfo : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        ///<summary>
        ///Opredelq dali propyrtito CreatedOn trqbva da se setva awtomatichno
        ///</summary>

        [NotMapped]
        public bool PreserveCreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
