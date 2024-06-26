﻿using System.ComponentModel.DataAnnotations.Schema;

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
	public List<long> Characters { get; set; }

    [Column("movies")]
	public List<long> Movies { get; set; }
}
