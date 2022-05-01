[ViewComponent(Name = "Projects")]
public class ProjectsViewComponent:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        string DataFile = File.ReadAllText("wwwroot\\Data\\Projects.txt");
        IEnumerable<Project>? Projects = JsonConvert.DeserializeObject<IEnumerable<Project>>(DataFile);
        return View("ProjectsComponent",Projects);
    }
}