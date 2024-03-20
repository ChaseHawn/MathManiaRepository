using Godot;
using System;

public partial class inventory : Control
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public world_game World;
	
	public override void _Ready()
	{
		Hide();
		var worldNode = GetNode<world_game>("/root/World");
		worldNode.Connect("ToggleGameInventory", new Callable(this, MethodName.OnToggleGameInventory));
	}

	public void OnToggleGameInventory(bool inInventory)
	{
		if (inInventory){
			Show();
		}
		else {
			Hide();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
