using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Models.api.Task.AddLogWork
{
    public class AddLogWorkRequest
    {
        public Guid TaskId { get; set; }
        public string Text { get; set; }
        public double SpentHours { get; set; }
    }
}
