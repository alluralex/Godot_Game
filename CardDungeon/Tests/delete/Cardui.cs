using Godot;
using System;

public partial class Cardui : Control
{



	public override void _Ready()
	{
		var color = GetNode<ColorRect>("Color");
		var label = GetNode<Label>("State");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
