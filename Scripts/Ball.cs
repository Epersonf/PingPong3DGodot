using Godot;
using System;

public class Ball : KinematicBody
{
	[Export] float speed = 5f;

	Vector2 direction = new Vector2(-1, 1);

	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(float delta)
	{
		MoveAndSlide(new Vector3(direction.x, 0, direction.y) * speed, Vector3.Up);
		CheckCollision();
	}

	public void CheckCollision()
	{
		int slideCount = GetSlideCount();
		if (slideCount == 0) return;

		Vector3 collisionNormal = GetSlideCollision(slideCount - 1).Normal;

		GD.Print(collisionNormal);

		direction.x *= (collisionNormal.y >= 0) ? -1 : 1;
		direction.y *= (collisionNormal.x >= 0) ? -1 : 1;
	}
}
