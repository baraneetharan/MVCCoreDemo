using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models;

namespace MVCCoreDemo.Controllers  
{  
    public class StudentController : Controller  
    {  
        StudentDataAccessLayer objstudent = new StudentDataAccessLayer();  
  
        public IActionResult Index()  
        {  
            List<Student> lststudent = new List<Student>();  
            lststudent = objstudent.GetAllStudent().ToList();  
  
            return View(lststudent);  
        }  
     }  
}
