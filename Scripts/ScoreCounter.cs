using Godot;
using System;
using System.Collections.Generic;

public class ScoreCounter : Area
{
	[Export] int playerId = 0;

	private void _on_Area_body_entered(object body)
	{
		Node ball = body as Node;
		if (!(ball).IsInGroup("ball")) return;
		if (playerId >= GameManager.singleton.score.Count) return;
		GameManager.singleton.score[playerId]++;
		ball.QueueFree();
		BallSpawner.singleton.SpawnBall();
	}

}
