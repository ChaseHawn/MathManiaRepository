using Godot;
using System;

public partial class pause_menu : Control
{
	[Export]
	public world1_game World1;

	public override void _Ready()
	{	
		Hide();
		Node2D TESTING = GetNode<Node2D>("World1");
		TESTING.Connect("ToggleGamePaused", new Callable(this, MethodName.OnToggleGamePaused));
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
}