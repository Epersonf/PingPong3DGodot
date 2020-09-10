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
		Hit();
	}

	private void _on_Projectile_body_entered(object body)
	{
		Hit(body);
	}

	public void Hit(object body = null)
	{
		if (body != null)
		{
			IAliveCreature hit = body as IAliveCreature;
			if (hit == null) return;
			hit.DealDamage(damage);
		}
		QueueFree();
	}
}
