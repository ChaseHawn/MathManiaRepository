using Godot;
using System;
using System.Dynamic;

public partial class world1_game : Node2D
{
	private bool _gamePaused = false;

	[Signal]
	public delegate	void ToggleGamePausedEventHandler(bool isPaused);
	
	public bool gamePaused
	{
		get{
			return _gamePaused;
		}
		set{
			_gamePaused = value;
			GetTree().Paused = _gamePaused;
			EmitSignal("ToggleGamePaused", _gamePaused);
		}
	}
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey){
			if (eventKey.Pressed && eventKey.Keycode == Key.Escape){
				gamePaused = !gamePaused;
			}
		}
	}
}