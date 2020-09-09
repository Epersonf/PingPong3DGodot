using Godot;
using System;

public class Pad : RigidBody, IShooter
{

	[Export]
	float speed = 50;

	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{

	}

	public void MoveGameObject(Vector3 direction)
	{
		GD.Print(direction);
		AddForce(direction * speed, Vector3.Zero);
	}

	public void Shoot()
	{

	}
}
