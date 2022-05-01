[ViewComponent(Name = "Experience")]
public class ExperienceViewComponent:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        string DataFile = File.ReadAllText("wwwroot\\Data\\Experience.txt");
        IEnumerable<Experience>? Experience=JsonConvert.DeserializeObject<IEnumerable<Experience>>(DataFile);
        return View("ExperienceComponent",Experience);
    }
}
