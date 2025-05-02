using employee;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace emp.Controllers.api
{
    [RoutePrefix("api/state")]
    public class StateController : ApiController
    {
        [HttpPost]
        [Route("stateList")]
        public ExpandoObject StateList()
        {
            dynamic response = new ExpandoObject();
            try
            {
                EmpDataDataContext dataContext = new EmpDataDataContext();
                var sta = (from s1 in dataContext.states
                           select new
                           {
                               s1.stateId,
                               s1.stateName,
                               s1.stateCode,
                               s1.status
                           }
                           ).ToList();
                response.StateList = sta;
                response.Message = "data found successfully";

            }
            catch (Exception ex)
            {
                response.Messagge = ex.Message;
                response.Message = "state not found";
            }
            return response;
        }


        [HttpPost]
        [Route("stateInsert")]
        public ExpandoObject StateInsert(state postdata)
        {
            dynamic response = new ExpandoObject();
            try
            {
                EmpDataDataContext dataContext = new EmpDataDataContext();

                state data = null;
                if (postdata.stateId > 0)
                {
                    data = dataContext.states.Where(x => x.stateId == postdata.stateId).First();
                    data.stateName = postdata.stateName;
                    data.stateCode = postdata.stateCode;
                    data.status = postdata.status;

                }
                else
                {
                    data = new state();
                    data.stateName = postdata.stateName;
                    data.stateCode = postdata.stateCode;
                    data.status = postdata.status;

                    dataContext.states.InsertOnSubmit(data);
                }
                dataContext.SubmitChanges();

                response.Message = "Data Inserted Successfully";


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                //response.Message = "data not insert there are some issue in try block";

            }
            return response;
        }

        [HttpPost]
        [Route("stateDelete")]
        public ExpandoObject StateDelete(state postData)
        {
            dynamic response = new ExpandoObject();
            try
            {
                EmpDataDataContext dataContext = new EmpDataDataContext();
                if (postData.stateId > 0)
                {
                    var data = dataContext.states.Where(x => x.stateId == postData.stateId).First();
                    dataContext.states.DeleteOnSubmit(data);
                    dataContext.SubmitChanges();
                    response.Message = "data delete successfull";
                }
                else
                {
                    response.Message = "the state is not present in the data base";
                }
            }
            catch(Exception ex)
            {
                response.Message = (new Exception("there are some issue in this code" + ex.Message));
            }
            return response;
        }
    }
}
