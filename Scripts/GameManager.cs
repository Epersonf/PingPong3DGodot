using Godot;
using System;
using System.Collections.Generic;

public class GameManager : Node
{

	public int ballRecord { get; private set; } = 0;

	public static GameManager singleton;

	public override void _Ready()
	{
		singleton = this;
		ballRecord = 0;
	}

	public void SetBallRecord(int newValue)
	{
		if (newValue < ballRecord) return;
		ballRecord = newValue;
	}
}
