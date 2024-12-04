using Godot;
using System;

public partial class HeroChoose : Node2D
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
	private void _on_control_warrior_mouse_entered()
	{
		GetNode<AnimatedSprite2D>("Control_Warrior/Circle_Warrior/w_sprites").Animation = "walk";
	}
	private void _on_control_warrior_mouse_exited()
	{
		GetNode<AnimatedSprite2D>("Control_Warrior/Circle_Warrior/w_sprites").Animation = "idle";
	}
	private void _on_control_mag_mouse_entered()
	{
		GetNode<AnimatedSprite2D>("Control_Mag/Circle_Mag/m_sprites").Animation = "walk";
	}
	private void _on_control_mag_mouse_exited()
	{
        GetNode<AnimatedSprite2D>("Control_Mag/Circle_Mag/m_sprites").Animation = "idle";
    }
	private void _on_control_archer_mouse_entered()
	{
        GetNode<AnimatedSprite2D>("Control_Archer/Circle_Archer/a_sprites").Animation = "walk";
    }
	private void _on_control_archer_mouse_exited()
	{
        GetNode<AnimatedSprite2D>("Control_Archer/Circle_Archer/a_sprites").Animation = "idle";
    }
}
