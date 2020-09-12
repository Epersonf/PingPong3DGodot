using Godot;
using System;

public class BallSpawner : Node
{

    public static BallSpawner singleton;
    public int amountOfBalls { get; private set; } = 1;

    [Export]
    NodePath spawnPositionPath = null;

    [Export]
    PackedScene ballPrefab = null;

    Node spawnPosition;

    public override void _Ready()
    {
        singleton = this;
        amountOfBalls = 1;
        spawnPosition = GetNode(spawnPositionPath);
        InterfaceController.singleton.Update();
        GameManager.singleton.SetBallRecord(amountOfBalls);
    }

    public void SpawnBall()
    {
        Node ballInstance = ballPrefab.Instance();
        Owner.AddChild(ballInstance);
        ((Spatial)ballInstance).Translation = ((Spatial)spawnPosition).Translation;
        amountOfBalls++;
        InterfaceController.singleton.Update();
        GameManager.singleton.SetBallRecord(amountOfBalls);
    }

    public void RemoveBall(Node node)
    {
        if (node as Ball == null) return;
        amountOfBalls--;
        node.QueueFree();
        InterfaceController.singleton.Update();
        GameManager.singleton.SetBallRecord(amountOfBalls);
    }

}
