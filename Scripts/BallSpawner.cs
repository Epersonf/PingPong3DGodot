using Godot;
using System;

public class BallSpawner : Node
{
    public static BallSpawner singleton;

    [Export]
    NodePath spawnPositionPath = null;

    [Export]
    PackedScene ballPrefab = null;

    Node spawnPosition;

    public override void _Ready()
    {
        singleton = this;
        spawnPosition = GetNode(spawnPositionPath);
    }

    public void SpawnBall()
    {
        Node ballInstance = ballPrefab.Instance();
        Owner.AddChild(ballInstance);
        ((Spatial)ballInstance).Translation = ((Spatial)spawnPosition).Translation;
    }

}
