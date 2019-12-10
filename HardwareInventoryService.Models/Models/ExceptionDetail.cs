using HardwareInventoryService.Models.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Models
{
    [DataContract]
    public class ExceptionDetail
    {
        [DataMember]
        public bool Result;

        [DataMember]
        public string Message;

        [DataMember]
        public string Description;

        [DataMember]
        public ErrorCode Status;

        [DataMember]
        private string ExceptionType;

        [DataMember]
        public DateTime? BlockedTill;

        [DataMember]
        public int? LoginAttempts;

        public ExceptionDetail()
        {
            this.Result = false;
            this.Message = null;
            this.Description = "No Exception detail provided";
        }

        public ExceptionDetail(bool result, string message, string description)
        {
            this.Result = result;
            this.Message = message;
            this.Description = description;
        }

        public ExceptionDetail(bool result, string message, string description, ErrorCode status) : this(result,
             message, description)
        {
            this.Status = status;
        }

        public ExceptionDetail(bool result, string message, string description, ErrorCode status, Type exceptionType) :
            this(result, message, description, status)
        {
            this.ExceptionType = exceptionType.FullName;
        }

        public ExceptionDetail(bool result, string message, string description, ErrorCode status, Type exceptionType, int? loginAttempts, DateTime? blockedTill) :
            this(result, message, description, status, exceptionType)
        {
            this.BlockedTill = blockedTill;
            this.LoginAttempts = loginAttempts;
        }
    }
}
