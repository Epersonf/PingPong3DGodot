using Godot;
using System;

public class Pad : KinematicBody, IAliveCreature
{
	#region Inspector Fields

	//export = SerializeField
	[Export]
	float speed = 700f;

	[Export]
	float jumpForce = 500f;

	[Export]
	NodePath shooterNode;

	[Export]
	NodePath aliveCreatureNode;

	[Export]
	float gravityForce = 10f;

	[Export]
	bool lockZ = false;

	[Export]
	bool lockX = false;

	#endregion

	#region Private fields

	float upSpeed = 0;

	Shooter shooter;

	AliveCreature aliveCreature;

	#endregion

	#region Inherited

	//start
	public override void _Ready()
	{
		//get component
		shooter = GetNode(shooterNode) as Shooter;
		aliveCreature = GetNode(aliveCreatureNode) as AliveCreature;
	}

	//fixedupdate
	public override void _PhysicsProcess(float delta)
	{
		MoveAndSlide(new Vector3(0, upSpeed, 0), Vector3.Up);
		if (upSpeed <= -gravityForce) return;
		upSpeed -= .5f;
	}

	#endregion

	#region Inputs

	protected void MoveGameObject(Vector3 direction, float delta)
	{
		Vector3 force = direction * speed * delta;
		if (lockX) force.x = 0;
		if (lockZ) force.z = 0;
		MoveAndSlide(force, Vector3.Up);
	}

	protected void Jump()
	{
		//osGrounded
		if (!IsOnFloor()) return;
		upSpeed = 10f;
	}

	protected void Shoot() => shooter.Shoot();

	public void DealDamage(int value) => aliveCreature.DealDamage(value);

	#endregion Inputs
}
