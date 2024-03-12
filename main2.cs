using Godot;
using System;

public partial class main2 : Node2D
{
	private void _on_play_pressed()
	{
		// Switches to world scene
		GetTree().ChangeSceneToFile("res://world1.tscn");
	}
	
	private void _on_quit_pressed()
	{
		// Exits the program
		GetTree().Quit();
	}
}
