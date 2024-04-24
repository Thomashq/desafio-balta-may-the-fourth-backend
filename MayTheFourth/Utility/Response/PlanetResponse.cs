using MayTheFourth.Models;

namespace MayTheFourth.Utility.Response;

public class PlanetResponse : BaseModel
{
    public string Name { get; set; }
    public string RotationPeriod { get; set; }
    public string OrbitalPeriod { get; set; }
    public string Diameter { get; set; }
    public string Climate { get; set; }
    public string Gravity { get; set; }
    public string Terrain { get; set; }
    public string SurfaceWater { get; set; }
    public string Population { get; set; }
    public List<string> Characters { get; set; }
    public List<string> Movies { get; set; }
}
