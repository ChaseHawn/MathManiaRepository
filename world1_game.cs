using Godot;
using System;

public partial class world1_game : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _UnhandledInput(InputEvent @event)
	{
	if (@event is InputEventKey eventKey)
		if (eventKey.Pressed && eventKey.Keycode == Key.Escape)
		{
			bool current_value = GetTree().Paused;
			GetTree().Paused = !current_value;
		}
	}
}
