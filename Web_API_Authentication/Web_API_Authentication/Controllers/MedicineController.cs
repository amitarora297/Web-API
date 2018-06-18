using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Data_Layer;
using API_Data_Layer.Model;

namespace Web_API_Authentication.Controllers
{
    public class MedicineController : ApiController
    {
        [HttpGet]
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            MedMaster medMaster = new MedMaster();
            return Ok (medMaster.GetMedicines());
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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