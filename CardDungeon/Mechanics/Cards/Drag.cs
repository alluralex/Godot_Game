using Godot;
using System;

public partial class Drag : Panel
{
	// Called when the node enters the scene tree for the first time.
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
            var rect = GetNode<Panel>("%TGUI");
            rect.Position += screenDrag.Relative;
        }
    }
}
