using Microsoft.AspNetCore.Mvc;
using school_2.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace school_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static int id = 1;
        private static List<Student> students = new List<Student> { new Student { Id = id++,Name="Ruth", Age=15, Status=1 },
            new Student { Id = id++,Name="Miri", Age=19, Status=1 },
            new Student { Id = id++,Name="Ayala", Age=16, Status=1 }
        };

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            Student s= students.Find(item => item.Id == id);
            if(s==null)
                return NotFound();
            return Ok(s);
        }


        [HttpPost]
        public void Post([FromBody] Student s)
        {
            students.Add(new Student { Id = s.Id, Name = s.Name, Age = s.Age, Courses = s.Courses, Status = s.Status });
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student st)
        {
            Student s = students.Find(item => item.Id == id);
            if(s == null)
                return NotFound();
            students.Remove(s);
            s.Name = st.Name;
            s.Age = st.Age;
            s.Courses = st.Courses;
            s.Status = st.Status;
            students.Add(s);
            return Ok();
        }
        [HttpPut("{id}/{status}")]
        public ActionResult Put(int id,int status, [FromBody] Student st)
        {
            Student s = students.Find(item => item.Id == id);
            if (s == null)
                return NotFound();
            students.Remove(s);
            s.Name = st.Name;
            s.Age = st.Age;
            s.Courses = st.Courses;
            s.Status = status;
            students.Add(s);
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Student s = students.Find(item => item.Id == id);
            if(s==null) 
                return NotFound();
            students.Remove(s);
            return Ok();
        }
    }
}
