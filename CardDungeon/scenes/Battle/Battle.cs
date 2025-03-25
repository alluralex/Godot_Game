using Godot;
using System;
using System.Collections.Generic;
using Game.Mechanics;

public partial class Battle : Node2D
{
	public Hero MyHero { get; set; }
	private List<Control> Cards { get; set; } = new();
	public static Control SelectedCard { get; set; } = new();
	[Export]
	public Control Hand { get; set; }

	public override void _Ready()
	{
		//var config = new ConfigFile();
		//var settings = config.Load("res://config.cfg");
		MyHero = CurrentHero.Hero;

		//GetNode<HScrollBar>("MenuBox/Empty/Scr_Music").Value = (double)config.GetValue("Settings", "music_value");
		//GetNode<HScrollBar>("MenuBox/Empty/Scr_Sound").Value = (double)config.GetValue("Settings", "sounds_value");
		//GetNode<CheckButton>("MenuBox/Empty/B_FullScreen").ButtonPressed = (bool)config.GetValue("Settings", "Fullscreen");

		GetNode<Label>("TopMenu/TopLineBox/HealthBoxWithNameClass/NameClass").Text = $"{MyHero.Name}";
		GetNode<Label>("TopMenu/TopLineBox/HealthBoxWithNameClass/Money/CurrentMoney").Text = $"{MyHero.Gold}";
		GetNode<Label>("TopMenu/TopLineBox/HealthBoxWithNameClass/Health/Health2").Text = $"{MyHero.CurrentHealth}/{MyHero.MaxHealth}";
		create_hero();
		create_cards();
	}
	//public void _on_area_use_mouse_entered()
	//{
	//	SelectedCard.Scale = new Vector2(5, 5);
	//}

	void create_cards()
	{
		foreach (Card card in MyHero.Cards)
		{
			GD.Print(card);
			PackedScene cards = GD.Load<PackedScene>("res://Mechanics/Cards/Card.tscn");

			Control cardsInstance = (Control)cards.Instantiate();

			cardsInstance.Scale = new Vector2(3, 3);
			cardsInstance.Name = card.Title;

			Hand.AddChild(cardsInstance);
			
			GD.Print(Cards);

			Cards.Add(cardsInstance);

			Hand.GetNode<Label>($"{card.Title}/TGUI/Card_png/Title").Text = card.Title;
			Hand.GetNode<Label>($"{card.Title}/TGUI/Card_png/Description").Text = card.Description;
			Hand.GetNode<Label>($"{card.Title}/TGUI/Card_png/Cost").Text = card.EnergyCost.ToString();
			//GetParent().GetNode<Label>($"{card.Title}/Card/TGUI/Card_png/Image").Text = card.Image;
		}
	}
	void create_hero()
	{
		PackedScene new_hero = GD.Load<PackedScene>(MyHero.Sprite);

		Node2D newHeroInstance = (Node2D)new_hero.Instantiate();

		newHeroInstance.Translate(new Vector2(178, 348));
		newHeroInstance.Scale = new Vector2(4, 4);

		AddChild(newHeroInstance);
	}

	private void _on_deck_of_cards_pressed()
	{
		GetNode<Sprite2D>("HeroDeckBox").Visible = true;
	}

	private void _on_escape_button_pressed()
	{
		GetNode<Sprite2D>("MenuBox").Visible = true;
	}

	private void _on_quit_deck_pressed()
	{
		GetNode<Sprite2D>("HeroDeckBox").Visible = false;
	}

	private void _on_b_contunie_pressed()
	{
		GetNode<Sprite2D>("MenuBox").Visible = false;
	}

	private void _on_b_settings_pressed()
	{
		GetNode<Node2D>("MenuBox/Empty").Visible = true;
		GetNode<VBoxContainer>("MenuBox/ButtonForMenu").Visible = false;
	}

	private void _on_b_exit_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/Menu/menu.tscn");
	}

	private void _on_b_back_pressed()
	{
		GetNode<Node2D>("MenuBox/Empty").Visible = false;
		GetNode<VBoxContainer>("MenuBox/ButtonForMenu").Visible = true;
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
	private void _on_b_full_screen_toggled(bool value)
	{
		var config = new ConfigFile();
		if (value == true)
		{
			GetTree().Root.Mode = Window.ModeEnum.Fullscreen;
		}
		if (value == false)
		{
			GetTree().Root.Mode = Window.ModeEnum.Windowed;
		}
		bool fullscreen = GetNode<CheckButton>("MenuBox/Empty/B_FullScreen").ButtonPressed;
		config.SetValue("Settings", "Fullscreen", fullscreen);
		var err = config.Save("res://config.cfg");
	}
}
