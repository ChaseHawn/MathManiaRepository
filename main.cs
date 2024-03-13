using Godot;
using System;
using System.Threading.Tasks;

public partial class main : Control
{
	private AudioStreamPlayer ClickSound;
	public bool flag;
	public override void _Ready()
    {
		ClickSound = GetNode<AudioStreamPlayer>("ClickSound");
    }
	
	private void OnPlayPressed()
	{
		// Click sound plays before switching to world1 scene 
		ClickSound.Play();
		flag = true;
	}
	
	private async void OnQuitPressed()
	{
		// Click sound plays and a 1 second delay to ensure it plays before quitting the game
		ClickSound.Play();
		flag = false;
	}

	private void OnClickSoundFinished()
	{
		// 
		// Switches to world scene
		if (flag == true){
			GetTree().ChangeSceneToFile("res://world1.tscn");
		}
		else {
			GetTree().Quit();
		}
	}
}
