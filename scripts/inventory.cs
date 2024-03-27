using Godot;
using System;

public partial class inventory : Control
{
	[Export]
	public world_game World;
	private Node2D WaypointPillar;
	private CharacterBody2D AnimatedSprite;
	
	/// <summary>
	/// Hides the inventory at the start of the game. Retrieves OnToggleGameInventoryEventHandler from world_game node.
	/// </summary>
	public override void _Ready()
	{
		Hide();
		WaypointPillar = GetNode<Node2D>("/root/World/WaypointPillar");
		AnimatedSprite = GetNode<CharacterBody2D>("/root/World/ManSprite");

		var worldNode = GetNode<world_game>("/root/World");
		worldNode.Connect("ToggleGameInventory", new Callable(this, MethodName.OnToggleGameInventory));
	}

	/// <summary>
	/// The inventory is shown and hidden depending on the state of inInventory.
	/// </summary>
	/// <param name="inInventory"> The inventory state currently. </param>
	public void OnToggleGameInventory(bool inInventory)
	{
		// When the inventory is shown it's displayed on screen. Otherwise it becomes hidden.
		if (inInventory){
			Show();
		}
		else {
			Hide();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public void OnCheckpoint1Pressed()
	{
		Hide();
		
		Godot.Vector2 currentPosition = AnimatedSprite.Position;
		currentPosition = WaypointPillar.GlobalPosition;
		AnimatedSprite.Position = currentPosition;
	}
}
