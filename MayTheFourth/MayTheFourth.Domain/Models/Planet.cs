using System.ComponentModel.DataAnnotations.Schema;

namespace MayTheFourth.Models;

public class Planet : BaseModel
{
	[Column("name")]
	public string Name { get; set; } = string.Empty;
	[Column("rotationPeriod")]
	public string RotationPeriod { get; set; } = string.Empty;
	[Column("orbitalPeriod")]
	public string OrbitalPeriod { get; set; } = string.Empty;
	[Column("diameter")]
	public string Diameter { get; set; } = string.Empty;
	[Column("climate")]
	public string Climate { get; set; } = string.Empty;
	[Column("gravity")]
	public string Gravity { get; set; } = string.Empty;
    [Column("terrain")]
	public string Terrain { get; set; } = string.Empty;
    [Column("surfaceWater")]
	public string SurfaceWater { get; set; } = string.Empty;
    [Column("population")]
	public string Population { get; set; } = string.Empty;
    [Column("characters")]
	public List<string> Characters { get; set; } = [];
    [Column("movies")]
	public List<string> Movies { get; set; } = [];
}
