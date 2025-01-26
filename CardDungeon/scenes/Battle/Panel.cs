using Godot;
using System;

public partial class Panel : Godot.Panel
{
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_gui_input(InputEvent ev)
	{
        if (ev is InputEventScreenDrag screenDrag)
        {
            var rect = GetNode<Panel>("%Panel");
            rect.Position += screenDrag.Relative;
        }
    }
}
