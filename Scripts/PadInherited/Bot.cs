using Godot;
using System;

public class Bot : Pad
{
	[Export] NodePath ballPath;

	Node ball;

	public override void _Ready()
	{
		base._Ready();
		ball = GetNode(ballPath);
	}

	public override void _Process(float delta)
	{
		base._Process(delta);

		Vector3 distanceToBall = ((Spatial)ball).Translation - ((Spatial) this).Translation;
		distanceToBall = distanceToBall.Normalized();

		MoveGameObject(distanceToBall, delta);
	}
}
