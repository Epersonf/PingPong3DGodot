using Godot;
using System;

public class Projectile : Area
{
	[Export]
	int damage = 1;

	[Export]
	float speed = 100;

	public override void _PhysicsProcess(float delta)
	{
		((Spatial) this).Translation += -Transform.basis.z * speed;
	}

	private void _on_Timer_timeout()
	{
		Destroy();
	}

	private void _on_Projectile_body_entered(object body)
	{
		Destroy(body);
	}

	public void Destroy(object body = null)
	{
		QueueFree();
		if (body != null)
		{
			IAliveCreature hit = body as IAliveCreature;
			Ball ball = body as Ball;
			if (hit != null)
				hit.DealDamage(damage);
			if (ball != null)
				ball.SetSpeed(ball.speed * 1.1f);
		}
	}
}
