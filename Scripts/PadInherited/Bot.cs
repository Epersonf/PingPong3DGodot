using Godot;
using System;

public class Bot : Pad
{
	public override void _Ready()
	{
		base._Ready();
	}

	public override void _Process(float delta)
	{
		base._Process(delta);

		Node ball = GetObjectByTag("ball", (distance, distanceRecord, ballNode) => distance < distanceRecord);

		if (ball == null) return;

		Func<int> a = () => { return 1; };

		Vector3 distanceToBall = ((Spatial) ball).Translation - ((Spatial) this).Translation;
		distanceToBall = distanceToBall.Normalized();

		MoveGameObject(distanceToBall, delta);
	}

	public Node GetObjectByTag(string tag, Func<float, float, Node, bool> comparison)
	{
		float distanceRecord = -1f;
		Node toReturn = null;
		Godot.Collections.Array taggeds = GetTree().GetNodesInGroup(tag);
		foreach (Node node in taggeds)
		{
			Spatial spatial = this as Spatial;
			Spatial nodeSpatial = node as Spatial;
			float distance = nodeSpatial.Translation.DistanceTo(spatial.Translation);
			if (!comparison(distance, distanceRecord, node) && toReturn != null) continue;
			toReturn = node;
			distanceRecord = distance;
		}
		return toReturn;
	}
}
