using Godot;
using System;

public class Pad : RigidBody, IShooter
{
	[Export]
	Spatial spawnPoint = null;

	[Export]
	float speed = 50f;

	[Export]
	float jumpForce = 5f;

	[Export]
	PackedScene projectile;

	protected void MoveGameObject(Vector3 direction, float delta)
	{
		AddForce(direction * speed * delta, Vector3.Zero);
	}

	protected void Jump()
	{
		AddForce(new Vector3(0, jumpForce, 0), Vector3.Zero);
	}

	public void Shoot()
	{
		if (projectile == null) return;
		Node newProjectile = projectile.Instance();
		AddChild(newProjectile);
		Spatial nodeSpatial = newProjectile.GetChild<Spatial>(0);
		nodeSpatial.Translation = Vector3.Zero;
	}
}
