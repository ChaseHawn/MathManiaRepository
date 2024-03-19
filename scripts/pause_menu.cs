using Godot;
using System;

public partial class pause_menu : Control
{
	[Export]
	public world_game World;

	public override void _Ready()
	{	
		Hide();
		var worldNode = GetNode<world_game>("/root/World");
		worldNode.Connect("ToggleGamePaused", new Callable(this, MethodName.OnToggleGamePaused));
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
		var worldNode = GetNode<world_game>("/root/World");
		World = worldNode;
        World.gamePaused = false;
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