using Godot;
using System;

public partial class Menu : Node2D
{
	public override void _Ready()
	{
		var config = new ConfigFile();
		var settings = config.Load("res://config.cfg");
		
		GetNode<HScrollBar>("Settings/Scr_Music").Value = (double)config.GetValue("Settings", "music_value");
		GetNode<HScrollBar>("Settings/Scr_Sound").Value = (double)config.GetValue("Settings", "sounds_value");
		GetNode<CheckButton>("Settings/B_FullScreen").ButtonPressed = (bool)config.GetValue("Settings", "Fullscreen");;
	}
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
	private void _on_b_save_settings_pressed()
	{
		var config = new ConfigFile();
		
		float musicValue = (float)GetNode<HScrollBar>("Settings/Scr_Music").Value;
		float soundsValue = (float)GetNode<HScrollBar>("Settings/Scr_Sound").Value;
		bool fullscreen = GetNode<CheckButton>("Settings/B_FullScreen").ButtonPressed;
		
		config.SetValue("Settings", "music_value", musicValue);
		config.SetValue("Settings", "sounds_value", soundsValue);
		config.SetValue("Settings", "Fullscreen", fullscreen);
		
		var err = config.Save("res://config.cfg");
	}
}
