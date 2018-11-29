using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModulusCheck.ServiceModel.Response;
using ServiceStack;

namespace ModulusCheck.ServiceModel.Request
{
    [Route("/modulusCheck/{AccountNumber}/{SortCode}")]
    public class CheckRequest : IReturn<CheckResponse>
    {
        public string AccountNumber { get; set; }
        public string SortCode { get; set; }
    }
}
