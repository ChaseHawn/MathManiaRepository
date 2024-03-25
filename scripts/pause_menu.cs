using Godot;
using System;

public partial class pause_menu : Control
{
	[Export]
	public world_game World;

	/// <summary>
	/// Hides the pause menu at the start of the game. Retrieves OnToggleGamePausedEventHandler from world_game node.
	/// </summary>
	public override void _Ready()
	{	
		Hide();
		var worldNode = GetNode<world_game>("/root/World");
		worldNode.Connect("ToggleGamePaused", new Callable(this, MethodName.OnToggleGamePaused));
	}

	/// <summary>
	/// The pause menu is shown and hidden depending on the state of isPaused.
	/// </summary>
	/// <param name="isPaused"> The game's state currently. </param>
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

	/// <summary>
	/// The game is resumed when the resume button is pressed.
	/// </summary>
	public void OnResumeButtonPressed()
	{
		var worldNode = GetNode<world_game>("/root/World");
		World = worldNode;
        World.gamePaused = false;
	}

	/// <summary>
	/// Volume settings become displayed when the volume button is pressed.
	/// </summary>
	public void OnVolumeButtonPressed()
	{
		GD.Print("Volume Menu");
	}

	/// <summary>
	/// The game stops running when the quit button is pressed.
	/// </summary>
	public void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}
}