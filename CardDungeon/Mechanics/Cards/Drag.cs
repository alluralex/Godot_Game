using Godot;
using System;

public partial class Drag : Panel
{
    [Export]
    private Control Card;
    public void _on_gui_input(InputEvent ev)
    {
        if (ev is InputEventMouseButton eventKey)
        {
            if (eventKey.Pressed && eventKey.ButtonIndex == MouseButton.Left)
            {
                Battle.SelectedCard.GetNode<Line2D>("%Border").Visible = false;

                if (GetNode<Line2D>("%Border").Visible == true)
                {
                    GetNode<Line2D>("%Border").Visible = false;
                }
                else
                {
                    GetNode<Line2D>("%Border").Visible = true;
                }

                Battle.SelectedCard = Card;

            }
        }
    }
    public void _on_mouse_entered()
    {
        Battle.SelectedCard = Card;
        Card.Scale = new Vector2(2, 2);
        Card.ZIndex = 2;
    }
    public void _on_mouse_exited()
    {
        Battle.SelectedCard = new();
        Card.Scale = new Vector2(1, 1);
        Card.ZIndex = 1;
    }
}
