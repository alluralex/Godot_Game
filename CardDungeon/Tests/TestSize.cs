using Godot;
using System;

public partial class TestSize : Control
{
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_mouse_entered()
	{
		var test_card = GetNode<Sprite2D>("Test_Card");
		test_card.Scale *= 1.3f;
	}

	private void _on_control_mouse_exited()
	{
		var test_card = GetNode<Sprite2D>("Test_Card");
		test_card.Scale /= 1.3f;
	}

	
}
