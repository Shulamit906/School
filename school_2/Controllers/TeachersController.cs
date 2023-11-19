using Microsoft.AspNetCore.Mvc;
using school_2.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace school_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        static int id = 1;
        private static List<Teacher> teachers = new List<Teacher> { new Teacher { Id = id++ , Name="Tachan", Subject="History" ,Status=1},
            new Teacher { Id = id++ , Name="Frid", Subject="Math" ,Status=1},
            new Teacher { Id = id++ , Name="Davidoviz", Subject="English" ,Status=1}
        };

        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return teachers;
        }


        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            Teacher t= teachers.Find(item => item.Id == id);
            if (t == null)
                return NotFound();
            return Ok(t);

        }


        [HttpPost]
        public void Post([FromBody] Teacher t)
        {
            teachers.Add(new Teacher { Id = t.Id, Name = t.Name, Subject = t.Subject, Status = t.Status });
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Teacher t)
        {
            Teacher th = teachers.Find(item => item.Id == id);
            if (th == null)
                return NotFound();
            teachers.Remove(th);
            th.Name = t.Name;
            th.Status = t.Status;
            th.Subject = t.Subject;
            teachers.Add(th);
            return Ok();
        }
        [HttpPut("{id}/{status}")]
        public ActionResult Put(int id,int status, [FromBody] Teacher t)
        {
            Teacher th = teachers.Find(item => item.Id == id);
            if (th == null)
                return NotFound();
            teachers.Remove(th);
            th.Name = t.Name;
            th.Status = status;
            th.Subject = t.Subject;
            teachers.Add(th);
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Teacher t = teachers.Find(item => item.Id == id);
            if (t == null)
                return NotFound();
            teachers.Remove(t);
            return Ok();    
        }
    }
}
