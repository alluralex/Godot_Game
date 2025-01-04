using Godot;
using System;

public partial class Cardui : Control
{
	public override void _Ready()
	{
		var color = GetNode<ColorRect>("Color");
		var label = GetNode<Label>("State");
	}

	public override void _Process(double delta)
	{

	}
}
