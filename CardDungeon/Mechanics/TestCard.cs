using Godot;
using System;
using Сохранялкагодота.Mechanics;

public partial class TestCard : Sprite2D
{
	public Card Card { get; set; }

	public TestCard() 
	{ 
		Card = new Warrior_SimpleAttack_Bronze();
	}

	public override void _Ready()
	{

		GetNode<Label>("Title").Text = Card.Title;
		GetNode<Label>("Class").Text = Card.Class;
		GetNode<Label>("Type").Text = Card.Type;
		GetNode<Label>("Description").Text = Card.Description;
		GetNode<Sprite2D>("Image_C").Texture = (Texture2D)Card.Image;
	 }

	public override void _Process(double delta)
	{
	}
}
