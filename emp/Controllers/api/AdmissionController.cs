using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using employee;

namespace emp.Controllers.api
{
    [RoutePrefix("api/admission")]
    public class AdmissionController : ApiController
    {

        [HttpGet]
        [Route("{id:int}")]
        public ExpandoObject getAdmissionData(int id)
        {
            dynamic res = new ExpandoObject();
            try
            {
                EmpDataDataContext dataContext = new EmpDataDataContext();
                var AdmData = (from adm in dataContext.admissions
                               where adm.admissionId == id
                               select new
                               {
                                   adm.admissionId,
                                   adm.admissionNo,
                                   adm.studentName,
                                   adm.DOB,
                                   adm.addharNo,
                                   adm.Email,
                                   adm.mobileNo,
                                   adm.GenderId,
                                   adm.bloodGroup,
                                   adm.nationality,
                                   adm.sessionId,
                                   adm.sectionId,
                                   adm.categoryId,
                                   adm.stateId,
                                   adm.cityId,
                                   adm.fatherName,
                                   adm.motherName,
                                   adm.fatherMobileNo,
                                   adm.fatherOccupation,
                                   adm.status
                               }).FirstOrDefault();

                res.AdmissionData = AdmData;
                res.Message = AdmData != null ? "data found" : "data not found";
            }
            catch (Exception ex)
            {
                res.Message = "Error: " + ex.Message;
            }
            return res;
        }

        [HttpPost]
        [Route("CreateAddmission")]
        public ExpandoObject cteateAddmission(admission userdata)

        {
            dynamic res = new ExpandoObject();
            try
            {
                EmpDataDataContext dataContext = new EmpDataDataContext();
                var td = new admission();

                td.admissionNo = userdata.admissionNo;
                td.studentName = userdata.studentName;
                td.DOB = userdata.DOB;
                td.GenderId = userdata.GenderId;
                td.addharNo = userdata.addharNo;
                td.bloodGroup = userdata.bloodGroup;
                td.nationality = userdata.nationality;
                td.categoryId = userdata.categoryId;
                td.stateId = userdata.stateId;
                td.cityId = userdata.cityId;
                td.sectionId = userdata.sectionId;
                td.sessionId = userdata.sessionId;
                td.mobileNo = userdata.mobileNo;
                td.Email = userdata.Email;
                td.fatherName = userdata.fatherName;
                td.motherName = userdata.motherName;
                td.fatherMobileNo = userdata.fatherMobileNo;
                td.fatherOccupation = userdata.fatherOccupation;
                dataContext.admissions.InsertOnSubmit( td );
                dataContext.SubmitChanges();
                res.Message = "addmission application created!";
            }
            catch (Exception ex)
            {   
                res.Message = ex.Message;
                res.Message = "fronted me issue hai";

            }
            
            return res;
        }
        
        [HttpPut]
        [Route("{id}")]

        public ExpandoObject updateAddmission(int id , admission userdata)
        {
            dynamic res = new ExpandoObject();
            try
            {
                EmpDataDataContext dataContext = new EmpDataDataContext();
                var fetchdata = dataContext.admissions.FirstOrDefault(x => x.admissionId == id);
                if (fetchdata == null)
                {
                    res.Message = "addmission data not found";
                }
                

                fetchdata.studentName = userdata.studentName;
                fetchdata.DOB = userdata.DOB;
                fetchdata.addharNo = userdata.addharNo;
                fetchdata.Email = userdata.Email;
                fetchdata.mobileNo = userdata.mobileNo;
                fetchdata.GenderId = userdata.GenderId;
                fetchdata.bloodGroup = userdata.bloodGroup;
                fetchdata.nationality = userdata.nationality;
                fetchdata.sessionId = userdata.sessionId;
                fetchdata.sectionId = userdata.sectionId;
                fetchdata.categoryId = userdata.categoryId;
                fetchdata.stateId = userdata.stateId;
                fetchdata.cityId = userdata.cityId;
                fetchdata.fatherName = userdata.fatherName;
                fetchdata.motherName = userdata.motherName;
                fetchdata.fatherMobileNo = userdata.fatherMobileNo;
                fetchdata.fatherOccupation = userdata.fatherOccupation;
                fetchdata.status = userdata.status;

                dataContext.SubmitChanges();
                res.Message = "Success";
            }

            catch (Exception ex)
            {
                res.Message = ex.Message;
            }
            return res;
        }
            
        
    }
}
