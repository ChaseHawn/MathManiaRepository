using Godot;
using System;

public partial class main : Control
{
	private void OnPlayPressed()
	{
		// Switches to world scene
		GetTree().ChangeSceneToFile("res://world1.tscn");
	}
	
	private void OnQuitPressed()
	{
		// Exits the program
		GetTree().Quit();
	}
}
