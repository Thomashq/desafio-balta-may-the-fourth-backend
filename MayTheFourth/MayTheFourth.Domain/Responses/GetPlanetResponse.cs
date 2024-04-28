using MayTheFourth.Models;

namespace MayTheFourth.Response;

public class GetPlanetResponse : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string RotationPeriod { get; set; } = string.Empty;
    public string OrbitalPeriod { get; set; } = string.Empty;
    public string Diameter { get; set; } = string.Empty;
    public string Climate { get; set; } = string.Empty; 
    public string Gravity { get; set; } = string.Empty;
    public string Terrain { get; set; } = string.Empty; 
    public string SurfaceWater { get; set; } = string.Empty;
    public string Population { get; set; } = string.Empty;
    public List<string> Characters { get; set; } = new List<string>();
    public List<string> Movies { get; set; } = new List<string>();
}
