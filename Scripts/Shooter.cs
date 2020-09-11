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

	Node playerNode;

	[Export]
	int maxBullets = 2;

	int bullets = 0;

	public override void _Ready()
	{
		playerNode = Owner;
	}

	public void ResetBullets()
    {
		bullets = maxBullets;
    }

	public void Shoot()
	{
		if (projectile == null || bullets <= 0) return;
		bullets--;
		Node newProjectile = projectile.Instance();
		playerNode.Owner.AddChild(newProjectile);
		Spatial nodeSpatial = newProjectile as Spatial;
		Spatial spawnSpatial = (GetNode(spawnPoint[gun]) as Spatial);
		nodeSpatial.Translation = spawnSpatial.GlobalTransform.Xform(spawnSpatial.Translation);
		nodeSpatial.Rotation = (playerNode as Spatial).Rotation * new Vector3(0, 180, 0);
		gun = (gun + 1) % spawnPoint.Count;
	}

}
