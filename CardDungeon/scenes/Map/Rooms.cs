using Godot;
using System;
using System.Collections.Generic;

public partial class Rooms : Node
{
    public abstract class Room
    {
        public string Name { get; set; }
        public Image Icon { get; set; }
        public List<Enemy> Enemies { get; set; }
    }
    public class Start : Room
    {
        public Start()
        {
            Name = "��������� �������.";
        }
    }
    public class Campfire : Room
    {
        public Campfire()
        {
            Name = "�����.";
        }
    }
    public class EventRoom : Room
    {
        public EventRoom()
        {
            Name = "������� �������.";
        }
    }
    public class BattleRoom : Room
    {
        public BattleRoom()
        {
            Name = "������� � ���������.";
        }
    }
    public class TreasureRoom : Room
    {
        public TreasureRoom()
        {
            Name = "������������.";
        }
    }
    public class Shop : Room
    {
        public Shop()
        {
            Name = "�����.";
        }
    }
    public class Secret : Room
    {
        public Secret()
        {
            Random rnd = new();
            int rand = rnd.Next(1, 6);
            Room room = AllRooms[rand];

            Name = $"{room.Name}";
        }
    }
    public class BossRoom : Room
    {
        public BossRoom()
        {
            Name = "������� � ������.";
        }
    }


    public static List<Room> AllRooms = new List<Room> { new Start(),  new Campfire(), new Shop(), new TreasureRoom(), new BattleRoom(), new EventRoom(), new Secret(), new BossRoom()};

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
