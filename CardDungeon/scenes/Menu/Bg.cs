using Godot;
using System;

public partial class Bg : ParallaxBackground
{
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        this.ScrollOffset += new Vector2((float)(20 * delta), 0);
    }
}