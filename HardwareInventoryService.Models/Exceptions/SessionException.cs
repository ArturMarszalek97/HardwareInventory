using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Models.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Exceptions
{
    public class SessionException : Exception
    {
        private readonly Session _session;

        public readonly ErrorCode errorCode;

        public readonly int? attemptsLeft;

        public readonly DateTime? blockedTill;

        public SessionException()
        {

        }

        public SessionException(string message) : base(message)
        {

        }

        public SessionException(string message, Session session) : this(message)
        {
            this._session = session;
        }

        public SessionException(string message, ErrorCode code) : this(message)
        {
            this.errorCode = code;
        }

        public SessionException(string message, ErrorCode code, int attemptsLeft) : this(message)
        {
            this.errorCode = code;
            this.attemptsLeft = attemptsLeft;
        }

        public SessionException(string message, ErrorCode code, DateTime blockedTill) : this(message)
        {
            this.errorCode = code;
            this.blockedTill = blockedTill;
        }
    }
}
