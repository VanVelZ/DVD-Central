using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZJV.DVDCentral.BL;
using ZJV.DVDCentral.BL.Models;

namespace ZJV.DVDCentral.API.Controllers
{
    public class FormatController : ApiController
    {
        // GET: api/Format
        public IEnumerable<Format> Get()
        {
            List<Format> programs = FormatManager.Load();
            return programs;
        }

        // GET: api/Format/5
        public Format Get(int id)
        {
            Format program = FormatManager.LoadByID(id);
            return program;
        }

        // POST: api/Format
        public void Post([FromBody]Format program)
        {
            FormatManager.Insert(program);
        }

        // PUT: api/Format/5
        public void Put(int id, [FromBody]Format program)
        {
            FormatManager.Update(program);
        }

        // DELETE: api/Format/5
        public void Delete(int id)
        {
            FormatManager.Delete(id);
        }
    }
}
