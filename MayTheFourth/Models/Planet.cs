using MayTheFourth.Utility.Requests;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace MayTheFourth.Models;

public class Planet : BaseModel
{
	[Column("name")]
	public string Name { get; set; }
	[Column("rotationPeriod")]
	public string RotationPeriod { get; set; }
	[Column("orbitalPeriod")]
	public string OrbitalPeriod { get; set; }
	[Column("diameter")]
	public string Diameter { get; set; }
	[Column("climate")]
	public string Climate { get; set; }
	[Column("gravity")]
	public string Gravity { get; set; }
	[Column("terrain")]
	public string Terrain { get; set; }
	[Column("surfaceWater")]
	public string SurfaceWater { get; set; }
	[Column("population")]
	public string Population { get; set; }
	[Column("characters")]
	public List<string> Characters { get; set; }
	[Column("movies")]
	public List<string> Movies { get; set; }

	public void Update(PlanetRequest planet)
	{
		this.Name = planet.Name;
		this.RotationPeriod = planet.RotationPeriod;
		this.OrbitalPeriod = planet.OrbitalPeriod;
		this.Diameter = planet.Diameter;
		this.Climate = planet.Climate;
		this.Gravity = planet.Gravity;	
		this.Terrain = planet.Terrain;
		this.SurfaceWater = planet.SurfaceWater;
		this.Population = planet.Population;
		this.Characters = planet.Characters;
		this.Movies = planet.Movies;
	}
}
