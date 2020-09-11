using Godot;
using System;

public class Ball : KinematicBody
{
	[Export]
	public float speed { get; private set; } = 5f;

	public void SetSpeed(float speed) => this.speed = speed;

	public Vector3 direction { get; private set; } = new Vector3(-1, 0, 1);

	int hitAmount = 0;

	public override void _PhysicsProcess(float delta)
	{
		MoveAndSlide(direction * speed, Vector3.Up);
		CheckCollision();
	}

	public void CheckCollision()
	{
		int slideCount = GetSlideCount();
		if (slideCount == 0) return;

		KinematicCollision collisionInfo = GetSlideCollision(slideCount - 1);

		Pad pad = collisionInfo.Collider as Pad;

		if (pad != null)
		{
			hitAmount++;
			if (hitAmount % 4 == 0)
				BallSpawner.singleton.SpawnBall();
			pad.shooter.ResetBullets();
		}

		Vector3 collisionNormal = collisionInfo.Normal;
		collisionNormal.y = 0;

		Vector3 reflectedDirection = (direction - 2 * (direction * collisionNormal) * collisionNormal).Normalized();

		direction = reflectedDirection;
	}
}
