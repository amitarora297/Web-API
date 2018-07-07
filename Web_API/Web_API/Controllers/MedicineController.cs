using System;
using System.Net.Http;
using System.Web.Http;
using API_Data_Layer;
using API_Data_Layer.Model;
using Web_API;

namespace Web_API_Authentication.Controllers
{
    [MedicineExceptionFIlter]
    [Authorize(Users = "Amit")]
    [RoutePrefix("api/Medicine")]
    public class MedicineController : ApiController
    {
        [HttpGet]
        // GET api/<controller>
        [Route("All")]
        public IHttpActionResult Get()
        {
            MedMaster medMaster = new MedMaster();
            var result = medMaster.GetMedicines();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        // HttpResponseException
        //[Route("Find/{id}")]
        //[AllowAnonymous]
        //public IHttpActionResult Get(int id)
        //{
        //    MedMaster medMaster = new MedMaster(); ;
        //    var result = medMaster.GetMedicines(id);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        HttpResponseMessage msg = new HttpResponseMessage()
        //        {
        //            Content = new StringContent("Medicine with given id does not exist."),
        //            //ReasonPhrase = "Medcine does not exist in database",
        //            StatusCode = System.Net.HttpStatusCode.NotFound


        //        };
        //        throw new HttpResponseException(msg);
        //    }
        //}

        // HttpError

        [Route("Find/{id}")]
        [AllowAnonymous]
        public HttpResponseMessage Get(int id)
        {
            MedMaster medMaster = new MedMaster(); ;
            var result = medMaster.GetMedicines(id);
            if (result != null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK,result);
            }
            else
            {
                string msg = "Medicine id does not exist";
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound,msg);
            }
        }

        [HttpPost]
        [Route("~/Add")]
        public IHttpActionResult Post([FromBody]Medicine medicine)
        {
            MedMaster medMaster = new MedMaster();
            if (string.IsNullOrWhiteSpace(medicine.MedicineName))
            {
                return BadRequest("You must supply medicine name");
            }
            if (string.IsNullOrWhiteSpace(medicine.Purpose))
            {
                return BadRequest("You must supply medicine purpose");
            }
            var result = medMaster.AddMedicine(medicine);
            if (result > 0)
            {
                var url = new Uri(string.Format("localhost:50428/api/medicine/Find/{0}", result));
                return Created(url, medicine);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}