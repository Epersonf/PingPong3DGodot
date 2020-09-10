using Godot;
using System;

public class Ball : KinematicBody
{
	[Export] float speed = 5f;

	Vector3 direction = new Vector3(-1, 0, 1);

	public override void _PhysicsProcess(float delta)
	{
		MoveAndSlide(direction * speed, Vector3.Up);
		CheckCollision();
	}

	public void CheckCollision()
	{
		int slideCount = GetSlideCount();
		if (slideCount == 0) return;

		Vector3 collisionNormal = GetSlideCollision(slideCount - 1).Normal;
		collisionNormal.y = 0;

		Vector3 reflectedDirection = direction - 2 * (direction * collisionNormal) * collisionNormal;

		direction = reflectedDirection;
	}
}
