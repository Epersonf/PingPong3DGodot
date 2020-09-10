using Godot;
using System;

public class Player : Pad
{
	public override void _Ready()
	{
		base._Ready();
	}

	public override void _Process(float delta)
	{
		base._Process(delta);
		float horizontal = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		float vertical = Input.GetActionStrength("ui_up") - Input.GetActionStrength("ui_down");

		if (Input.IsActionJustPressed("ui_select")) Shoot();

		if (horizontal == 0 && vertical == 0) return;

		if (vertical > 0) Jump();

		Vector3 direction = new Vector3(horizontal, (vertical < 0) ? vertical : 0, 0);
		MoveGameObject(direction, delta);
	}
}
