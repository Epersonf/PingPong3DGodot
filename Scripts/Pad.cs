using Godot;
using System;

public class Pad : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		float horizontal = Input.GetActionStrength("ui_left") - Input.GetActionStrength("ui_right");
		float vertical = Input.GetActionStrength("ui_up") - Input.GetActionStrength("ui_down");
	}

	public void MoveGameObject(Vector3 direction)
	{

	}
}
