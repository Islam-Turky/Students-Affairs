using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace StudentAffairsAPIs.Controllers
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class StudentsController : ControllerBase
    {
        public Student? student = new Student();

        private readonly ILogger<StudentsController> _logger;
        private readonly DbStudent _dbStudent;
        public StudentsController(ILogger<StudentsController> logger, DbStudent dbStudent)
        {
            _logger = logger;
            _dbStudent = dbStudent;
        }

        [HttpGet]
        public List<Student> GetAll()
        {
            return _dbStudent.Students.Select(e => e).ToList();
        }

        [HttpGet("student/{id}")]
        public IActionResult Get([FromRoute] string Id)
        {
            int parsedId = 0;
            int.TryParse(Id, out parsedId);
            Student? targetStudentById = _dbStudent.Students.FirstOrDefault(e => e.Id.Equals(parsedId));
            return Ok(targetStudentById);
        }

        [HttpPost("student")]
        public IActionResult Post([FromBody] Student student)
        {
            _dbStudent.Students.Add(student);
            _dbStudent.SaveChanges();
            return Created();
        }

        [HttpPost]
        public IActionResult PostAll([FromBody] List<Student> students)
        {
            _dbStudent.Students.AddRange(students);
            _dbStudent.SaveChanges();
            return Created();
        }

        [HttpDelete]
        public IActionResult DeleteAll()
        {
            int deleteAll = _dbStudent.Students.ExecuteDelete();
            _dbStudent.SaveChanges();
            return Ok(deleteAll);
        }

        [HttpDelete("student/{id}")]
        public Student Delete([FromRoute] string id) 
        {
            int parseId = 0;
            int.TryParse(id, out parseId);
            Student? studentTargetToDelete = _dbStudent.Students.FirstOrDefault(e => e.Id == parseId);
            if (studentTargetToDelete is not null) 
            {
                _dbStudent.Students.Remove(studentTargetToDelete ?? new());
                _dbStudent.SaveChanges();
            }
            return studentTargetToDelete ?? new();
        }

        [HttpPut("student/{id}")]
        public Student Put([FromRoute] string id, [FromBody] Student upStudent)
        {
            int parseId = 0;
            int.TryParse(id, out parseId);
            Student? targetStudent = _dbStudent.Students.FirstOrDefault(e => e.Id == parseId);
            if(targetStudent is not null)
            {
                targetStudent.Name = upStudent.Name;
                targetStudent.Age = upStudent.Age;
                targetStudent.Mobile = upStudent.Mobile;
                _dbStudent.SaveChanges();
            }
            return targetStudent ?? new();
        }
    }
}
