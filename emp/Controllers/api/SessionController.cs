using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using employee;
using static System.Collections.Specialized.BitVector32;

namespace emp.Controllers.api
{
    [RoutePrefix("api/session")]
    public class SessionController : ApiController
    {
        //this is route for fetch data

        [HttpPost]
        [Route("SessionList")]


        public ExpandoObject SessionList()
        {
            dynamic  response =  new ExpandoObject();
            try
            {
                 EmpDataDataContext dataContext = new EmpDataDataContext();
                var session = (from s1 in dataContext.sessions
                               select new
                               {
                                   s1.sessionId,
                                   s1.sessionName,
                                   s1.endFrom,
                                   s1.startFrom,
                                   s1.status
                               }).ToList();
                response.SessionList = session;
                response.Message = "Data Fatch Successfully..";
            }

            catch (Exception ex) {
                response.message = ex.Message;
                throw new Exception("data not found");
            }
            return response;
        }

        //this is insert data into the database

        [HttpPost]
        [Route("InsertSession")]

        public ExpandoObject InsertSession(session ses)
        {
            dynamic response = new ExpandoObject();
            try
            {
                EmpDataDataContext dataContext = new EmpDataDataContext();
                session ses1 = new session();
                ses1.sessionName = ses.sessionName;
                ses1.startFrom = ses.startFrom;
                ses1.endFrom = ses.endFrom;
                ses1.status = ses.status;
                dataContext.sessions.InsertOnSubmit(ses1);
                dataContext.SubmitChanges();
                response.Message = "Success";
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        //this is update data into the database

        [HttpPost]
        [Route("UpdateSession")]

        public ExpandoObject UpdateSession(session sess2)
        {
            dynamic response = new ExpandoObject();
            try
            {
                EmpDataDataContext dataContext = new EmpDataDataContext();
                session sess;

                if (sess2.sessionId > 0)
                {
                    // Update existing session
                    sess = dataContext.sessions.FirstOrDefault(x => x.sessionId == sess2.sessionId);
                    if (sess != null)
                    {
                        sess.sessionName = sess2.sessionName;
                        sess.startFrom = sess2.startFrom;
                        sess.endFrom = sess2.endFrom;
                        sess.status = sess2.status;
                    }
                    else
                    {
                        response.Message = "Session not found";
                        return response;
                    }
                dataContext.SubmitChanges();
                response.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        //this is for delete the data from the table 

        [HttpPost]
        [Route("DeleteSession")]

        public ExpandoObject DeleteSession(session dels)
        {
            dynamic resposnse = new ExpandoObject();

            try
            {
                EmpDataDataContext dataContext = new EmpDataDataContext();
                var sess = dataContext.sessions.FirstOrDefault(x => x.sessionId == dels.sessionId);

                if(sess!= null)
                {
                    dataContext.sessions.DeleteOnSubmit(sess);
                    dataContext.SubmitChanges();
                    resposnse.Message = "data delete successfull";
                }
                else
                {
                    resposnse.Message = "please enter the ID";
                }


            }
            catch (Exception ex)
            {
                
                resposnse.Message = "the data not found";
                resposnse.Message = ex.Message;
            }
            return resposnse;
        }


    }
}
