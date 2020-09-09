using Godot;
using System;

public class Pad : RigidBody
{

	[Export]
	float speed = 50f;

	[Export]
	float jumpForce = 5f;

	[Export]
	NodePath shooterNode;

	Shooter shooter;

	public override void _Ready()
	{
		//get component
		shooter = GetNode(shooterNode) as Shooter;
	}

	#region Inputs

	protected void MoveGameObject(Vector3 direction, float delta) => AddForce(direction * speed * delta, Vector3.Zero);

	protected void Jump()
	{
		AddForce(new Vector3(0, jumpForce, 0), Vector3.Zero);
	}

	public void Shoot() => shooter.Shoot();

	#endregion Inputs
}
