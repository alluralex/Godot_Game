using Godot;
using System;

public partial class Drag : Panel
{
	[Export]
	private Control Card;
	public void _on_gui_input(InputEvent ev)
	{
		if (ev is InputEventScreenDrag screenDrag)
		{
			ZIndex = 100;
			var rect = GetNode<Panel>("%TGUI");
			rect.Position += screenDrag.Relative;
		}
	}
	public void _on_mouse_entered()
	{
		Battle.SelectedCard = Card;
		Card.Scale = new Vector2(2, 2);
	}
	public void _on_mouse_exited()
	{
		Battle.SelectedCard = new();
		Card.Scale = new Vector2(1, 1);
	}
}
