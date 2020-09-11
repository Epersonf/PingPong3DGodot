using Godot;
using System;
using System.Collections.Generic;

public class GameManager : Node
{
	public List<int> score { get; private set; } = null;

	public static GameManager singleton;

	public override void _Ready()
	{
		singleton = this;
		ResetScore();
	}

	public void ResetScore()
	{
		score = new List<int>();
		for (int i = 0; i < 2; i++)
			score.Add(0);
	}

	public override void _Process(float delta)
	{

	}
}
