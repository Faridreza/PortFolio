[ViewComponent(Name = "Skills")]
public class SkillsViewComponent:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        string DataFile = File.ReadAllText("wwwroot\\Data\\Skills.txt");
        IEnumerable<Experience>? Experience=JsonConvert.DeserializeObject<IEnumerable<Experience>>(DataFile);
        return View("SkillsComponent", Experience);
    }
}
