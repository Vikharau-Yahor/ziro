using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Models.api.User.UploadAvatar
{
    public class UploadAvatarRequest
    {
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
