using Godot;
using System;

public class Pad : KinematicBody
{
    #region Inspector Fields

    //export = SerializeField
    [Export]
	float speed = 50f;

	[Export]
	float jumpForce = 500f;

	[Export]
	NodePath shooterNode;

	[Export]
	NodePath aliveCreatureNode;

    [Export]
	float gravityForce = 10f;

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
		MoveAndSlide(force, Vector3.Up);
	}

	protected void Jump()
	{
		//osGrounded
		if (!IsOnFloor()) return;
		upSpeed = 10f;
	}

	protected void Shoot() => shooter.Shoot();

	protected void DealDamage(int value) => aliveCreature.DealDamage(value);

	#endregion Inputs
}
