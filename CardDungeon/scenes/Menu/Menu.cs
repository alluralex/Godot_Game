using Godot;
using System;

public partial class Menu : Node2D
{

    private void _on_b_exit_pressed()
    {
        GetTree().Quit();
    }
}
