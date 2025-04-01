using Godot;
using System;

public partial class Drag : Control
{
    public void _on_tgui_gui_input(InputEvent ev)
    {
        if (ev is InputEventMouseButton eventKey)
        {
            if (eventKey.Pressed && eventKey.ButtonIndex == MouseButton.Left)
            {
                Battle.SelectedCard = this;
                GD.Print(Battle.SelectedCard.Name);
            }
        }
    }
    public void _on_tgui_mouse_entered()
    {
        Scale = new Vector2(2, 2);
        Position -= new Vector2(0, 60);
        ZIndex = 2;
    }
    public void _on_tgui_mouse_exited()
    {
        Scale = new Vector2(1, 1);
        Position += new Vector2(0, 60); 
        ZIndex = 1;
    }
}
