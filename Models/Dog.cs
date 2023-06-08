using System;
namespace ApiDogs.Models;

public class Dog
{
	public Guid Gid { get; set; }

	public string Name { get; set; } = string.Empty;

	public string Color { get; set; } = string.Empty;

	public int TailLength { get; set; }

	public int Weight { get; set; }
}

