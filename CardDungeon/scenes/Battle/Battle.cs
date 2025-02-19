using Godot;
using System;

public partial class Battle : Node2D
{
    Heroes.Hero MyHero;

    public override void _Ready()
    {
        var config = new ConfigFile();
        var settings = config.Load("res://config.cfg");
        MyHero = CurrentHero.Hero;

        GetNode<HScrollBar>("MenuBox/Empty/Scr_Music").Value = (double)config.GetValue("Settings", "music_value");
        GetNode<HScrollBar>("MenuBox/Empty/Scr_Sound").Value = (double)config.GetValue("Settings", "sounds_value");
        GetNode<CheckButton>("MenuBox/Empty/B_FullScreen").ButtonPressed = (bool)config.GetValue("Settings", "Fullscreen");

        GetNode<Label>("TopMenu/TopLineBox/HealthBoxWithNameClass/NameClass").Text = $"{MyHero.Name}";
        GetNode<Label>("TopMenu/TopLineBox/HealthBoxWithNameClass/Money/CurrentMoney").Text = $"{MyHero.Gold}";
        GetNode<Label>("TopMenu/TopLineBox/HealthBoxWithNameClass/Health/Health2").Text = $"{MyHero.CurrentHealth}/{MyHero.MaxHealth}";
        create_hero();
        create_cards();



    }
    void create_cards()
    {
        PackedScene cards = GD.Load<PackedScene>("res://Mechanics/Cards/Card.tscn");

        Node2D cardsInstance = (Node2D)cards.Instantiate();

        cardsInstance.Translate(new Vector2(200, 200));
        cardsInstance.Scale = new Vector2(3, 3);

        AddChild(cardsInstance);
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
