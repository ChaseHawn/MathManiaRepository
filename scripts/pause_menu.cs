using Godot;
using System;

public partial class pause_menu : Control
{
	[Export]
	public world1_game World1;

	public override void _Ready()
	{	
		Hide();
		var world1Node = GetNode<world1_game>("/root/World1");
		world1Node.Connect("ToggleGamePaused", new Callable(this, MethodName.OnToggleGamePaused));
	}

	public void OnToggleGamePaused(bool isPaused)
	{
		// When the game is paused, the pause menu is displayed on screen. Otherwise it becomes hidden.
		if (isPaused){
			Show();
		}
		else {
			Hide();
		}
	}

	public void OnResumeButtonPressed()
	{
		// The game is resumed when the resume button is pressed.
		var world1Node = GetNode<world1_game>("/root/World1");
		World1 = world1Node;
        World1.gamePaused = false;
	}

	public void OnVolumeButtonPressed()
	{
		GD.Print("Volume");
	}

	public void OnQuitButtonPressed()
	{
		// The game stops running when the quit button is pressed.
		GetTree().Quit();
	}
}