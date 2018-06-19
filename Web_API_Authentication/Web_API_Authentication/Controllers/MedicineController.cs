using System;
using System.Web.Http;
using API_Data_Layer;
using API_Data_Layer.Model;

namespace Web_API_Authentication.Controllers
{
    [RoutePrefix("api/Medicine")]
    [Authorize]
    public class MedicineController : ApiController
    {
        [HttpGet]
        // GET api/<controller>
        [Route("All")]
        public IHttpActionResult Get()
        {
            MedMaster medMaster = new MedMaster();
            var result = medMaster.GetMedicines();
            if (result !=  null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            
        }

        [Route("Find/{id}")]
        public IHttpActionResult Get(int id)
        {
            MedMaster medMaster = new MedMaster();;
            var result = medMaster.GetMedicines(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Post([FromBody]Medicine medicine)
        {
            MedMaster medMaster = new MedMaster();
            if (string.IsNullOrWhiteSpace( medicine.MedicineName))
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
                return Created(url,medicine);
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