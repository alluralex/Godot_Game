using Godot;
using System;

public partial class Drag : Panel
{
    public void _on_gui_input(InputEvent ev)
    {
        if (ev is InputEventScreenDrag screenDrag)
        {
            var rect = GetNode<Panel>("%TGUI");
            rect.Position += screenDrag.Relative;
        }
    }
  //  public void _on_mouse_entered()
  //  {
		//Battle.SelectedCard = GetTree().GetRoot().GetNode<Node2D>("OneCard");
  //  }
  //  public void _on_mouse_exited()
  //  {
  //      Battle.SelectedCard = new();
  //  }
}
