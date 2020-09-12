using Godot;
using System;
using System.Collections.Generic;

public class ScoreCounter : Area
{

	private void _on_Area_body_entered(object body) =>
		BallSpawner.singleton.RemoveBall(body as Node);

}
