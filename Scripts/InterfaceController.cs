using Godot;
using System;

public class InterfaceController : Node
{
	public static InterfaceController singleton { get; private set; } = null;

	[Export]
	NodePath scoreTextPath;

	Label scoreText;

	public override void _EnterTree()
	{
		singleton = this;
		scoreText = GetNode(scoreTextPath) as Label;
	}

	public void Update()
	{
		scoreText.Text = "Score: " + BallSpawner.singleton.amountOfBalls + "/" + GameManager.singleton.ballRecord;
	}
}
