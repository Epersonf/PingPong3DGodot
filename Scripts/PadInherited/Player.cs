using Godot;
using System;

public class Player : Pad
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		base._Process(delta);
		float horizontal = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		float vertical = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
		if (horizontal == 0 && vertical == 0) return;
		Vector3 direction = new Vector3(horizontal, vertical, 0);
		GD.Print(direction);
		MoveGameObject(direction);
	}
}
