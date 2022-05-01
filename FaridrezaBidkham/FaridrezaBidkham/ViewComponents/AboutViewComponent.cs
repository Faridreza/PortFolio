[ViewComponent(Name = "About")]
public class AboutViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        string DataFile = File.ReadAllText("wwwroot\\Data\\About.txt");
        About? About = JsonConvert.DeserializeObject<About>(DataFile);
        return View("AboutComponent", About);
    }
}
