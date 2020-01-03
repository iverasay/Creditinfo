using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditInfoAPI.Controllers
{
    public class CreditInfoController : ApiController
    {
        [HttpGet]
        public string SearchMethod(string NationalId)
        {
            Individual result;
            using (CreditInfoModel CIM = new CreditInfoModel())
            {
                result = CIM.Individuals.Where(x => x.IdN.NationalID == NationalId).FirstOrDefault();
            }

            if (result != null)
                return "single hit";
            else
                return "no hit";

        }
    }
}
