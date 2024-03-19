using Godot;
using System;
using System.Threading.Tasks;

public partial class main : Control
{
	private AudioStreamPlayer ClickSound;
	private AudioStreamPlayer MenuMusic;
	public bool flag;
	
	public override void _Ready()
	{
		// Both ClickSound and MenuMusic is audio is retrieved. The MenuMusic audio is played.
		ClickSound = GetNode<AudioStreamPlayer>("ClickSound");
		MenuMusic = GetNode<AudioStreamPlayer>("MenuMusic");
		MenuMusic.Play();
	}
	
	private void OnPlayPressed()
	{
		// When the continue button is pressed, it plays the ClickSound audio. 
		ClickSound.Play();
		flag = true;
	}
	
	private void OnQuitPressed()
	{
		// When the quit button is pressed, it plays the ClickSound audio.
		ClickSound.Play();
		flag = false;
	}

	private void OnClickSoundFinished()
	{
		// When the ClickSound audio is finished playing, it will change to the world1 scene or quit the game depending on which button the player pressed.
		if (flag == true){
			GetTree().ChangeSceneToFile("res://scenes/world.tscn");
		}
		else {
			GetTree().Quit();
		}
	}
}