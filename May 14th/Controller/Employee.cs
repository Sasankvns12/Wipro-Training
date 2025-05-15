using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        public string Index()
        {
            return "This is Employee Index";
        }

        public string FirstName()
        {
            return "My First Name is Vithala";
        }

        public string LastName()
        {
            return "My Last Name is Sasank";
        }
    }
}
