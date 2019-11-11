using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Models
{
    public class LogMessage
    {
        public string Application { get; set; }

        public string Message { get; set; }

        public string ClassName { get; set; }

        public string MethodName { get; set; }

        public object Parameters { get; set; }

        public LogMessage()
        {
            this.Application = "";
            this.MethodName = "";
            this.Message = "";
            this.ClassName = "";
            this.Parameters = null;
        }
    }
}
