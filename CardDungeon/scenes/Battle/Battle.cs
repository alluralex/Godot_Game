using Godot;
using System;

public partial class Battle : Node2D
{
    public override void _Ready()
    {
        base._Ready();
    }
    private void _on_escape_button_pressed()
    {
        GetNode<Sprite2D>("MenuBox").Visible = true;
    }
    private void _on_b_contunie_pressed()
    {
        GetNode<Sprite2D>("MenuBox").Visible = false;
    }

    private void _on_b_exit_pressed()
    {
        GetTree().ChangeSceneToFile("res://BackGrounds/Menu/menu.tscn");
    }

    private void _on_scr_music_value_changed(float value)
    {

        var gameMusic = GetNode<AudioStreamPlayer>("Music");

        gameMusic.VolumeDb = value;
    }
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

    private void _on_b_save_settings_pressed()
    {
        var config = new ConfigFile();

        float musicValue = (float)GetNode<HScrollBar>("MenuBox/Empty/Scr_Music").Value;
        float soundsValue = (float)GetNode<HScrollBar>("MenuBox/Empty/Scr_Sound").Value;
        bool fullscreen = GetNode<CheckButton>("MenuBox/Empty/B_FullScreen").ButtonPressed;

        config.SetValue("Settings", "music_value", musicValue);
        config.SetValue("Settings", "sounds_value", soundsValue);
        config.SetValue("Settings", "Fullscreen", fullscreen);

        var err = config.Save("res://config.cfg");
    }
    private void _on_b_back_pressed_returnallthreebuttons()
    {
        GetNode<Node2D>("MenuBox/Empty").Visible = false;
        GetNode<VBoxContainer>("MenuBox/ButtonForMenu").Visible = true;
    }
    private void _on_b_settings_pressed()
    {
        GetNode<Node2D>("MenuBox/Empty").Visible = true;
        GetNode<VBoxContainer>("MenuBox/ButtonForMenu").Visible = false;
    }
}
