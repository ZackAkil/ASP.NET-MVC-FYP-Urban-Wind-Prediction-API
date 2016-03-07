using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UrbanWindPredictorAPI.Controllers
{
    public class TestObj
    {
        public int id = 1;
        public string words = "yo yo wasup";
        public string[] vals = { "value1", "value2" };

    }
   // [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public TestObj Get()
        {
            
            return new TestObj();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
            //test email update
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
