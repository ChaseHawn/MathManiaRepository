using Godot;
using System;

public partial class pause_menu : Control
{
	[Export]
	public world1_game World1;
	
	public override void _Ready()
	{
		Hide();
	}

	public void _on_resume_button_pressed()
	{
		GetTree().Paused = false;
		Hide();
	}
}
