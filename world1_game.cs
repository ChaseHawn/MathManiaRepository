using Godot;
using System;
using System.Dynamic;

public partial class world1_game : Node2D
{
	public override void _Input(InputEvent @event)
    {
        GD.Print("TEST!!");
    }
	public int SomeData;

	public override void _Ready()
	{	
		SomeData = 43;
		EmitSignal("SomeDataReady", SomeData);
	}
	// [Signal]
	// public delegate	void ToggleGamePausedEventHandler(bool isPaused);
	// public bool gamePaused = false;
	
	// public bool Test
	// {
	// 	get
	// 	{
	// 		return gamePaused;
	// 	}
	// 	set
	// 	{
	// 		gamePaused = false;
	// 		GetTree().Paused = gamePaused;
	// 		EmitSignal("ToggleGamePaused", gamePaused);
	// 	}
	// }

	// public override void _UnhandledInput(InputEvent @event)
	// {
	// if (@event is InputEventKey eventKey)
	// 	if (eventKey.Pressed && eventKey.Keycode == Key.Escape)
	// 	{
	// 		Test = !gamePaused;
	// 	}
	// }
}