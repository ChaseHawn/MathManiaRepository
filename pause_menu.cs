using Godot;
using System;

public partial class pause_menu : Control
{
	public world1_game World1;

	public override void _Ready()
	{	
		Hide();
		World1 = GetNode<world1_game>("res://world1.tscn");
		World1.Connect("SomeDataReady", this, nameof(OnSomeDataReady));
	}

	public void OnSomeDataReady(int data);
	{
		GD.Print("DATA RECEIVED: " + data);
	}

	// [Export] public world1_game World1;

	// public override void _Ready()
	// {	
	// 	Hide();
	// 	Node2D Testvar = GetNode<Node2D>("World1");
	// 	Testvar.Connect("ToggleGamePaused", this, nameof(Onworld1_gameToggleGamePaused));
	// }

	// public void _on_resume_button_pressed()
	// {
	// 	GetTree().Paused = false;
	// 	Hide();
	// }

	// public void _on_world1_menu_toggle_game_paused(bool isPaused)
	// {
	// 	if (isPaused){
	// 		Show();
	// 	}
	// 	else {
	// 		Hide();
	// 	}
	// }
}
