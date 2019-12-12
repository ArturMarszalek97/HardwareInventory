using HardwareInventoryService.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Models.Authorization
{
    [HashDataForLog]
    public class Session : IAuthCacheModel
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public List<DateTime> FailedLoginAttempts { get; set; }

        [DataMember]
        public DateTime? TokenValidity { get; set; }

        [DataMember]
        public byte[] AccountPhoto { get; set; }

        public Session()
        {
            this.FailedLoginAttempts = new List<DateTime>();
        }

        public Session(string userName, string password) : this()
        {
            this.Username = userName;
            this.Password = password;
        }
    }
}
