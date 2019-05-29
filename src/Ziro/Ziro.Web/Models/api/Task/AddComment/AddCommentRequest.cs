using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Models.api.Task.AddComment
{
    public class AddCommentRequest
    {
        public Guid TaskId { get; set; }
        public string Text { get; set; }
    }
}
