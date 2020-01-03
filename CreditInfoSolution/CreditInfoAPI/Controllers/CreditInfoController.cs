using CreditInfoAPI.Models;
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

        [HttpGet]
        public DetailMethodResultViewModel DetailMethod(string NationalId)
        {
            DetailMethodResultViewModel result = new DetailMethodResultViewModel();
            Contract ResultContract;
            //List<ContractData> data;
            //Individual Ind;
            //SubjectRole role;
            using (CreditInfoModel CIM = new CreditInfoModel())
            {
                //Ind = CIM.Individuals.Where(x => x.IdN.NationalID == NationalId).FirstOrDefault();
                //role = CIM.SubjectRoles.Where(x => x.CustomerCode == Ind.CustomerCode && x.RoleOfCustomer == "MainDebtor").FirstOrDefault();
                //contract = CIM.Contracts.Where(x => x.Id == 22).FirstOrDefault();
                //data = CIM.ContractDatas.Where(x => x.con)

                ResultContract = (from contracts in CIM.Contracts
                                  from individuals in contracts.Individuals
                                  from roles in contracts.SubjectRoles
                                  from datas in contracts.ContractsData
                                  where individuals.IdN.NationalID == NationalId
                                        && roles.RoleOfCustomer == "MainDebtor"
                                  select new Contract
                                  { Id = contracts.Id,
                                      ContractCode = contracts.ContractCode,
                                      ContractsData = contracts.ContractsData,
                                      Individuals = contracts.Individuals,
                                      SubjectRoles = contracts.SubjectRoles
                                 }
                                 ).FirstOrDefault();

            }

            return result;

        }


    }
}
