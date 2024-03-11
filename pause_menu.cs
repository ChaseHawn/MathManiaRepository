using Godot;
using System;

public partial class pause_menu : Control
{
	[Export]
	public world1_game World1;

	public override void _Ready()
	{	
		Hide();
		var world1Node = GetTree().Root.FindChild("World1", true, false);
		world1Node.Connect("ToggleGamePaused", new Callable(this, MethodName.OnToggleGamePaused));
	}

	public void OnToggleGamePaused(bool isPaused)
	{
		if (isPaused){
			Show();
		}
		else {
			Hide();
		}
	}

	public void OnResumeButtonPressed()
	{
		// Resumes the game
		var world1Node = GetNode<world1_game>("/root/World1");
		World1 = world1Node;

        // Resumes the game by setting gamePaused to false
        World1.gamePaused = false;
	}

	public void OnVolumeButtonPressed()
	{
		// Volume menu pop-up
		GD.Print("Volume");
	}

	public void OnQuitButtonPressed()
	{
		// Exits the game
		GetTree().Quit();
	}
}