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
    [RoutePrefix("api/lookups")]
    public class LookupsController : ApiController

    {
        
        [HttpGet]
        [Route("genders")]
        public ExpandoObject getGender()
        {
        EmpDataDataContext dataContext = new EmpDataDataContext();
        dynamic res = new ExpandoObject();
            try
            {
                var genderdata = dataContext.genders.Select
                    (g => new { g.genderId, g.genderName, g.status }).ToList();
                res.GenderData = genderdata;
            }
            catch(Exception ex)
            {
                res.Message = ex.Message;
            }
            return res;
        }

        [HttpGet]
        [Route("states")]
        public ExpandoObject getState()
        {
            EmpDataDataContext dataContext = new EmpDataDataContext();
            dynamic res = new ExpandoObject();
            try
            {
                var statedata = dataContext.states.Select
                    (s => new { s.stateId, s.stateName, s.stateCode, s.status }).ToList();
                res.StateData = statedata;
            }
            catch(Exception ex)
            {
                res.Message = ex.Message;
            }
            return res;
        }

        [HttpGet]
        [Route("cities")]
        public ExpandoObject getCities()
        {
            EmpDataDataContext dataContext = new EmpDataDataContext();
            dynamic res = new ExpandoObject();
            try
            {
                var citydata = dataContext.cities.Select (c => new { c.cityId, c.cityName, c.status }).ToList();
                res.CitiesData = citydata;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
            
            }
            return res;

        }

        [HttpGet]
        [Route("bloodgroups")]
        public ExpandoObject getbloodgroups()
        {
            EmpDataDataContext dataContext = new EmpDataDataContext();
            dynamic res = new ExpandoObject();
            try
            {
                var bloodgroups = dataContext.bloodGroups.Select(b => new {b.bloodId,b.bloodName,b.status }).ToList();
                res.BloodGroups = bloodgroups;
            }
            catch(Exception ex)
            {
                res.Message = ex.Message;
            }
            return res;
        }

        [HttpGet]
        [Route("catogery")]
        public ExpandoObject getcatogery() 
        {
            EmpDataDataContext dataContext = new EmpDataDataContext();
            dynamic res = new ExpandoObject();
            try
            {
                var catogery = dataContext.catogeries.Select(ca => new {ca.catogeryId,ca.catogeryName,ca.status}).ToList();
                res.Catogery = catogery;
            }
            catch(Exception es)
            {
                res.Message = es.Message;
            }
            return res;
        }

        [HttpGet]
        [Route("nationality")]
        public ExpandoObject getcategorias() 
        {
            EmpDataDataContext dataContext = new EmpDataDataContext();
            dynamic res = new ExpandoObject();
            try
            {
                var nationality = dataContext.nationalities.Select(n => new { n.nationalityId, n.nationality1, n.status }).ToList();
                res.Nationality = nationality;

            }
            catch (Exception ex) 
            {
                res.Message = ex.Message;
            }
            return res;
        }

        [HttpGet]
        [Route("class")]
        public ExpandoObject getclass()
        {
            EmpDataDataContext dataContext = new EmpDataDataContext();  
            dynamic res = new ExpandoObject();
            try
            {
                var classlist = dataContext.classes.Select(cla => new
                {
                    cla.classId,
                    cla.className,
                    cla.status
                }).ToList();

                res.Classlist = classlist;

            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
            }

            return res;
        }

        [HttpGet]
        [Route("section")]
        public ExpandoObject getsection()
        {
            EmpDataDataContext dataContext = new EmpDataDataContext();
            dynamic res = new ExpandoObject();
            try
            {
                var section = dataContext.sections.Select(sec => new {sec.sectionId,sec.sectionName,sec.classId,sec.status}).ToList();
                res.Sections = section;

            }
            catch(Exception ex) 
            {
                res.Message = ex.Message;
            }
            return res;
        }

        [HttpGet]
        [Route("session")]
        public ExpandoObject getsession()
        {
            EmpDataDataContext dataContext = new EmpDataDataContext();
            dynamic res = new ExpandoObject();

            try
            {
                var session = dataContext.sessions.Select(ses => new { ses.sessionId, ses.sessionName, ses.startFrom, ses.endFrom, ses.status }).ToList();
                res.Sessions = session;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
            }
            return res;
        }

    }
}
