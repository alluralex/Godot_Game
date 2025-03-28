using Godot;
using System;
using System.Collections.Generic;
using Game.Mechanics;
using Game.Creatures;

public partial class Battle : Node2D
{
    public Hero MyHero { get; set; }
    private List<Control> Cards { get; set; } = new();
    private List<Enemy> Enemies { get; set; } = new();
    public static Control SelectedCard { get; set; }
    [Export]
    public Control Hand { get; set; }
    [Export]
    public Label NameClass { get; set; }
    [Export]
    public Label CurrentMoney { get; set; }
    [Export]
    public Label Health { get; set; }

    public override void _Ready()
    {
        //var config = new ConfigFile();
        //var settings = config.Load("res://config.cfg");
        MyHero = CurrentHero.Hero;

        //GetNode<HScrollBar>("MenuBox/Empty/Scr_Music").Value = (double)config.GetValue("Settings", "music_value");
        //GetNode<HScrollBar>("MenuBox/Empty/Scr_Sound").Value = (double)config.GetValue("Settings", "sounds_value");
        //GetNode<CheckButton>("MenuBox/Empty/B_FullScreen").ButtonPressed = (bool)config.GetValue("Settings", "Fullscreen");

        NameClass.Text = $"{MyHero.Name}";
        CurrentMoney.Text = $"{MyHero.Gold}";
        Health.Text = $"{MyHero.CurrentHealth}/{MyHero.MaxHealth}";
        CreateHero();
        CreateCards();
        CreateMonster();
    }

    private void CreateMonster()
    {
        Random rnd = new Random();
        int countmonsters = 0;
        countmonsters = rnd.Next(1, 4);

        for (int i = 0; i <= countmonsters; i++)
        {
            Enemies.Add(new Goblin());

            PackedScene goblin = GD.Load<PackedScene>("res://Creatures/Enemies/First_loc/Golem_small/golem_small.tscn");

            Node2D newGoblinInstance = (Node2D)goblin.Instantiate();

            newGoblinInstance.Translate(new Vector2(300, 348));
            newGoblinInstance.Scale = new Vector2(2, 2);

            AddChild(newGoblinInstance);
        }
    }

    private void CreateCards()
    {
        int number = 0;
        foreach (Card card in MyHero.Cards)
        {
            PackedScene cards = GD.Load<PackedScene>("res://Mechanics/Cards/Card.tscn");

            Control cardsInstance = (Control)cards.Instantiate();

            cardsInstance.Scale = new Vector2(3, 3);
            cardsInstance.Name = $"{card.Title}{number}";

            number++;

            Hand.AddChild(cardsInstance);

            GD.Print(Cards);

            Cards.Add(cardsInstance);

            Hand.GetNode<Label>($"{cardsInstance.Name}/%Title").Text = card.Title;
            Hand.GetNode<Label>($"{cardsInstance.Name}/%Description").Text = card.Description;
            Hand.GetNode<Label>($"{cardsInstance.Name}/%Cost").Text = card.EnergyCost.ToString();
            Hand.GetNode<Label>($"{cardsInstance.Name}/%Type").Text = card.Type;
            Hand.GetNode<Sprite2D>($"{cardsInstance.Name}/%Image").Texture.ResourcePath = card.Image;
        }
    }
    private void CreateHero()
    {
        PackedScene new_hero = GD.Load<PackedScene>(MyHero.Sprite);

        Node2D newHeroInstance = (Node2D)new_hero.Instantiate();

        newHeroInstance.Translate(new Vector2(178, 348));
        newHeroInstance.Scale = new Vector2(4, 4);
        newHeroInstance.ZIndex = 0;

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
