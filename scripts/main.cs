using Godot;
using System;
using System.Threading.Tasks;

public partial class main : Control
{
	private AudioStreamPlayer ClickSound;
	private AudioStreamPlayer MenuMusic;
	public bool flag;
	
	/// <summary>
	/// Music and sound effects are retrieved and the menu's music is played.
	/// </summary>
	public override void _Ready()
	{
		ClickSound = GetNode<AudioStreamPlayer>("ClickSound");
		MenuMusic = GetNode<AudioStreamPlayer>("MenuMusic");
		MenuMusic.Play();
	}
	
	/// <summary>
	/// When the continue button is pressed a sound effect is played. 
	/// </summary>
	private void OnPlayPressed()
	{
		ClickSound.Play();
		flag = true;
	}
	
	/// <summary>
	/// When the quit button is pressed a sound effect is played. 
	/// </summary>
	private void OnQuitPressed()
	{
		ClickSound.Play();
		flag = false;
	}

	/// <summary>
	/// When the sound effect audio is finished playing it will either switch to the world scene or quit the game depending on which button was pressed.
	/// </summary>
	private void OnClickSoundFinished()
	{
		if (flag == true){
			GetTree().ChangeSceneToFile("res://scenes/world.tscn");
		}
		else {
			GetTree().Quit();
		}
	}
}
