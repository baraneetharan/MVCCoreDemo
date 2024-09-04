using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models; // Include this to access the Student class
 
namespace MVCCoreDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDataAccessLayer _studentDataAccess;
 
        public StudentController(StudentDataAccessLayer studentDataAccess)
        {
            _studentDataAccess = studentDataAccess;
        }
 
        public IActionResult Index()
        {
            List<Student> lststudent = _studentDataAccess.GetAllStudent().ToList();
            return View(lststudent);
        }
 
         // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentDataAccess.AddStudent(student);
                return RedirectToAction(nameof(Index)); // Ensure you have an Index action to redirect to
            }
            return View(student);
        }
 
        // GET: Student/Edit/5
        public IActionResult Edit(int id)
        {
            var student = _studentDataAccess.GetStudentData(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
 
        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.StudId)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    _studentDataAccess.UpdateStudent(student);
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., log it)
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return View(student);
                }
 
                return RedirectToAction(nameof(Index)); // Redirect to a list or other action
            }
            return View(student);
        }
     public IActionResult Details(int id)
    {
        var student = _studentDataAccess.GetStudentData(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }
 
 
    public IActionResult Delete(int id)
    {
        _studentDataAccess.DeleteStudent(id);
        return RedirectToAction("Index"); // Redirect to the index page after deletion
    }
 
        // Other actions (Create, Edit, Details, Delete) would be here
    }
}
