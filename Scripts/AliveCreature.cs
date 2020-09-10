using Godot;
using System;

public class AliveCreature : Node
{
	[Export]
	int life = 5;

	[Export]
	int maxLife = 6;

	public override void _Ready()
	{
		ResetLife();		
	}

	public void ResetLife()
	{
		life = maxLife;
	}

	public void DealDamage(int value = 1)
	{
		life -= value;
		if (life <= 0) Die();
	}

	public void Die()
	{
		Owner.QueueFree();
	}
}

public interface IAliveCreature {
	void DealDamage(int value);
}
