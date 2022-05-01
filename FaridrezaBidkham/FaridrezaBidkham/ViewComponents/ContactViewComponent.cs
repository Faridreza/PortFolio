[ViewComponent(Name = "Contact")]
public class ContactViewComponent:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        string DataFile = File.ReadAllText("wwwroot\\Data\\Contact.txt");
        Contact? Contact =JsonConvert.DeserializeObject<Contact>(DataFile);
        return View("ContactComponent",Contact);
    }
}
