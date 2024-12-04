using Godot;
using System;

public partial class HeroChoose : Node2D
{
	public HeroChoose() 
	{
        
    }

	public override void _Ready()
	{
		
	}

    private async void _on_button_warrior_pressed()
    {
        var stateMage = GetNode<Sprite2D>		("States/StateHeroMage");
        var stateWarrior = GetNode<Sprite2D>	("States/StateHeroWarrior");
        var stateArcher = GetNode<Sprite2D>		("States/StateHeroArcher");
        var empty = GetNode<Sprite2D>			("States/Empty");
        var startRun_B = GetNode<Button>		("StartRun");

        stateWarrior.Visible = true;
        startRun_B.Visible = true;

        stateMage.Visible = false;
        stateArcher.Visible = false;
        empty.Visible = false;
    }

    private async void _on_button_archer_pressed()
    {
        var stateMage = GetNode<Sprite2D>		("States/StateHeroMage");
        var stateWarrior = GetNode<Sprite2D>	("States/StateHeroWarrior");
        var stateArcher = GetNode<Sprite2D>		("States/StateHeroArcher");
        var empty = GetNode<Sprite2D>			("States/Empty");
        var startRun_B = GetNode<Button>		("StartRun");

        stateArcher.Visible = true;
        startRun_B.Visible = true;

        stateWarrior.Visible = false;
        stateMage.Visible = false;
        empty.Visible = false;
    }

    private async void _on_button_mage_pressed()
    {
        var stateMage = GetNode<Sprite2D>		("States/StateHeroMage");
        var stateWarrior = GetNode<Sprite2D>	("States/StateHeroWarrior");
        var stateArcher = GetNode<Sprite2D>		("States/StateHeroArcher");
        var empty = GetNode<Sprite2D>			("States/Empty");
        var startRun_B = GetNode<Button>		("StartRun");

		stateMage.Visible = true;
		startRun_B.Visible = true;

		stateWarrior.Visible = false;
		stateArcher.Visible = false;
		empty.Visible = false;


    }

    public override void _Process(double delta)
	{
	}
	private void _on_button_warrior_mouse_entered()
	{
		GetNode<AnimatedSprite2D>("Heroes/Button_Warrior/Circle_Warrior/w_sprites").Animation = "walk";
	}
	private void _on_button_warrior_mouse_exited()
	{
		GetNode<AnimatedSprite2D>("Heroes/Button_Warrior/Circle_Warrior/w_sprites").Animation = "idle";
	}
	private void _on_button_mage_mouse_entered()
	{
		GetNode<AnimatedSprite2D>("Heroes/Button_Mage/Circle_Mage/m_sprites").Animation = "walk";
	}
	private void _on_button_mage_mouse_exited()
	{
		GetNode<AnimatedSprite2D>("Heroes/Button_Mage/Circle_Mage/m_sprites").Animation = "idle";
	}
	private void _on_button_archer_mouse_entered()
	{
		GetNode<AnimatedSprite2D>("Heroes/Button_Archer/Circle_Archer/a_sprites").Animation = "walk";
	}
	private void _on_button_archer_mouse_exited()
	{
		GetNode<AnimatedSprite2D>("Heroes/Button_Archer/Circle_Archer/a_sprites").Animation = "idle";
	}
	
	
}