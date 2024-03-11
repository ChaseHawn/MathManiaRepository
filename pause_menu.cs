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
		GD.Print("Entered");
		if (isPaused){
			Show();
		}
		else {
			Hide();
		}
	}
}