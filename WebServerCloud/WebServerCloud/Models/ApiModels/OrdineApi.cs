using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerCloud.Models.ApiModels
{
    public class OrdineApi
    {
        public Guid TenantId { get; set; }
        public Guid SpedizioneId { get; set; }
        public string VideoData { get; set; }
        public string VideoName { get; set; }
    }
}
