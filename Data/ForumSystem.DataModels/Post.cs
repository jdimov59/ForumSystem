using ForumSystem.Data.Common;
using ForumSystem.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.DataModels
{
    public class Post : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        //TODO: Author

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
