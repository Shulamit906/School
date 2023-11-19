using Microsoft.AspNetCore.Mvc;
using school_2.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace school_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        static int id = 1;
        private static List<Course> courses = new List<Course> { new Course { Id = id++, Name="History" ,Description="A short and concise course in the history of the Jewish people"},
            new Course { Id = id++, Name="English" ,Description="English course for beginners in the basics of the language"},
            new Course { Id = id++, Name="Math" ,Description="A deep and theoretical course in the field of group theory"},
        };

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return courses;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            Course c= courses.Find(item => item.Id == id); 
            if(c==null)
                return NotFound();
            return Ok(c);
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post([FromBody] Course c)
        {
            courses.Add(new Course { Id = c.Id, Name = c.Name, Description = c.Description });
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course c)
        {
            Course c1 = courses.Find(item => item.Id == id);
            if(c1==null)
                return NotFound();
            courses.Remove(c1);
            c1.Name = c.Name;
            c1.Description = c.Description;
            courses.Add(c1);
            return Ok();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Course c = courses.Find(item => item.Id == id);
            if(c== null)
                return NotFound();
            courses.Remove(c);
            return Ok();
        }
    }
}
