using Godot;
using System;
using System.Dynamic;

public partial class world1_game : Node2D
{
	[Signal]
	public delegate	void ToggleGamePausedEventHandler(bool isPaused);
	public bool gamePaused = false;
	
	public bool Test
	{
		get
		{
			return gamePaused;
		}
		set
		{
			gamePaused = false;
			GetTree().Paused = gamePaused;
			EmitSignal("ToggleGamePaused", gamePaused);
		}
	}

	public override void _Input(InputEvent @event)
    {
		GD.Print("TEST");
        Test = !gamePaused;
    }
}