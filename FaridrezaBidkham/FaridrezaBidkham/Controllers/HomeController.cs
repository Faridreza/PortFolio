namespace FaridrezaBidkham.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ModalInformashion(int Id)
        {
            if (HttpContext.AjaxOnly())
            {
                string DataFile = System.IO.File.ReadAllText("wwwroot\\Data\\Projects.txt");
                IEnumerable<Project>? Projects = JsonConvert.DeserializeObject<IEnumerable<Project>>(DataFile);
                Project? Result = null;
                if (Projects is not null)
                {
                    Result = Projects.FirstOrDefault(i => i.Id == Id);
                    if (Result is not null)
                    {
                        return Json(Result);
                    }
                }
            }
            return Json(NotFound());
        }
        [HttpPost]
        public async Task<JsonResult> ContactMessage(IFormCollection FormValue)
        {
            if (HttpContext.AjaxOnly())
            {
                string Name = FormValue["name"];
                string Email = FormValue["email"];
                string Phone = FormValue["phone"];
                string Message = FormValue["message"];
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Message))
                    {
                        if (string.IsNullOrEmpty(Phone))
                        {
                            Phone = "Empty";
                        }
                        else if (!string.IsNullOrEmpty(Phone) && !double.TryParse(Phone, out _) && Phone.Length != 11)
                        {
                            return Json("No");
                        }
                        try
                        {
                            string DataFile = System.IO.File.ReadAllText("wwwroot\\Data\\Contact.txt");
                            Contact? Contact = JsonConvert.DeserializeObject<Contact>(DataFile);
                            string Result = $"Hi\n\nNew Email Resived!\n Informashion:\nName: {Name}\nEmail: {Email}\nPhone: {Phone}\n Message:{Message}";
                            if (Contact != null)
                            {
                                await new Email().SendMessage($"{Contact.Email}", "Message Support", $"{Result}");
                                return Json("Ok");
                            }
                        }
                        catch { }
                    }
                }
                return Json("No");
            }
            return Json(NotFound());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}