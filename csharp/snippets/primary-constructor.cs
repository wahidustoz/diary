// struct tipida ishlatish
public readonly struct Nuqta(int x, int y)
{
    public readonly int X => x;
    public readonly int Y => y;
}
// ota klassga ma'lumot uzatish
public class Ustoz(int id, string ism) : Ishchi(id)
{
    public int Id => id;
    public string Ism => ism;
}
// dependency injection
public interface IService
{
    Distance GetDistance();
}

public class ExampleController(IService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<Distance> Get()
    {
        return service.GetDistance();
    }
}