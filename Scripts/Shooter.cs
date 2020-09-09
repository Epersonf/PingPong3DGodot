using Godot;
using System;
using System.Collections.Generic;

public class Shooter : Node
{
	int gun = 0;

	[Export]
	List<NodePath> spawnPoint = null;
	
	[Export]
	PackedScene projectile;

	public void Shoot()
	{
		if (projectile == null) return;
		Node newProjectile = projectile.Instance();
		AddChild(newProjectile);
		Spatial nodeSpatial = newProjectile as Spatial;
		nodeSpatial.Translation = (GetNode(spawnPoint[gun]) as Spatial).Translation;
		gun = (gun + 1) % spawnPoint.Count;
	}

}
