using Godot;
using System;

public class Projectile : Area
{
	[Export]
	float speed = 100;

	public override void _Ready()
	{
		
	}

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
			Node hit = body as Node;
		}
		QueueFree();
	}
}
