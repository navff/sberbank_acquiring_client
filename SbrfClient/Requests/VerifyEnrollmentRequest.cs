using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbrfClient.Params;

namespace SbrfClient.Requests
{
    internal class VerifyEnrollmentRequest : VerifyEnrollmentParams
    {
        public string userName { get; set; }
        public string password { get; set; }

        public VerifyEnrollmentRequest(VerifyEnrollmentParams verifyEnrollmentParams)
        {
            this.pan = verifyEnrollmentParams.pan;
        }
    }
}
