using ForumSystem.DataModels;
using ForumSystem.Web.Infrastructure.Mapping;
using System;

namespace ForumSystem.Web.ViewModels.Home
{
    public class IndexBlogPostViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}