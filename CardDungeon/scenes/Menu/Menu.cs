using Godot;
using System;

public partial class Menu : Node2D
{
    //exit
    private void _on_b_exit_pressed()
    {
        GetTree().Quit();
    }
    //return
    private void _on_b_back_pressed()
    {
        var main = GetNode<Node2D>("Main");
        main.Visible = true;

        var settings = GetNode<Node2D>("Settings");
        settings.Visible = false;
    }
    //settings
    private void _on_b_settings_pressed()
    {
        var main = GetNode<Node2D>("Main");
        main.Visible = false;

        var settings = GetNode<Node2D>("Settings");
        settings.Visible = true;
    }
    //changemusic
    private void _on_scr_music_value_changed(float value)
    {

        var gameMusic = GetNode<AudioStreamPlayer>("Music");

        gameMusic.VolumeDb = value;
    }
    //fullscreen
    private void _on_b_full_screen_toggled(bool value)
    {
        if (value == true)
        {
            GetTree().Root.Mode = Window.ModeEnum.Fullscreen;
        }
        if (value == false)
        {
            GetTree().Root.Mode = Window.ModeEnum.Windowed;
        }
    }
}
