using Godot;
using System;

public partial class main : Node2D
{
	private void _on_play_pressed()
	{
		// Switches to world scene
		GetTree().ChangeSceneToFile("res://world.tscn");
	}
	
	private void _on_quit_pressed()
	{
		// Exits the program
		GetTree().Quit();
	}
}
