[ViewComponent(Name = "Head")]
public class HeadViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        string DataFile = File.ReadAllText("wwwroot\\Data\\Informashion.txt");
        Informashion? Informashion = JsonConvert.DeserializeObject<Informashion>(DataFile);
        return View("HeadComponent", Informashion);
    }
}