using Godot;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

public partial class world_game : Node2D
{
	private AudioStreamPlayer backgroundSong1;
	private AudioStreamPlayer backgroundSong2;
	private AudioStreamPlayer backgroundSong3;
	private bool _gamePaused = false;
	private bool _gameInventory = false;

	[Signal]
	public delegate	void ToggleGamePausedEventHandler(bool isPaused);

	[Signal]
	public delegate	void ToggleGameInventoryEventHandler(bool inInventory);
	
	public override async void _Ready()
	{
		// Background music audio is retrieved.
		backgroundSong1 = GetNode<AudioStreamPlayer>("BackgroundSong1");
		backgroundSong2 = GetNode<AudioStreamPlayer>("BackgroundSong2");
		backgroundSong3 = GetNode<AudioStreamPlayer>("BackgroundSong3");

		// A list of background music audio that may play during a user's session in World 1.
		List<AudioStreamPlayer> musicList = new List<AudioStreamPlayer>
		{
			backgroundSong1,
			backgroundSong2,
			backgroundSong3,
		};

		// A while loop that plays songs in an unspecified order.
		while(true){
			// Selects a random song in musicList and assigns the index to randomSong.
			var rand = new Random();
			var index = rand.Next(musicList.Count);
			var randomSong = musicList[index];

			// Loops through each song in musicList to find the corresponding index of randomSong.
			foreach (AudioStreamPlayer song in musicList){
				if (randomSong == song){
					song.Play();
					// Converts the song length from seconds to milliseconds to be compatible with Task.Delay. Loop is delayed until the song finishes. 
					int songLengthSeconds = (int)song.Stream.GetLength();
					int songLengthMilliseconds = (songLengthSeconds * 1000) + 3000;
					await Task.Delay(songLengthMilliseconds);
				}
			}
		}
	}

	public bool gamePaused
	{
		get{
			return _gamePaused;
		}
		set{
			_gamePaused = value;
			GetTree().Paused = _gamePaused;
			EmitSignal("ToggleGamePaused", _gamePaused);
		}
	}

	public bool gameInventory
	{
		get{
			return _gameInventory;
		}
		set{
			_gameInventory = value;
			EmitSignal("ToggleGameInventory", _gameInventory);
		}
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey){
			if (eventKey.Pressed && eventKey.Keycode == Key.Escape){
				if (gameInventory == false){
					gamePaused = !gamePaused;
				}
			}
			else if (eventKey.Pressed && eventKey.Keycode == Key.Q){
				gameInventory = !gameInventory;
			}
		}
	}
}
