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

	[Signal]
	public delegate	void ToggleGamePausedEventHandler(bool isPaused);

	[Signal]
	public delegate	void ToggleGameInventoryEventHandler(bool inInventory);

	private bool _gamePaused = false;
	private bool _gameInventory = false;
	
	/// <summary>
	/// Retrieves background songs and calls the method that plays them.
	/// </summary>
	public override void _Ready()
    {
		backgroundSong1 = GetNode<AudioStreamPlayer>("BackgroundSong1");
		backgroundSong2 = GetNode<AudioStreamPlayer>("BackgroundSong2");
		backgroundSong3 = GetNode<AudioStreamPlayer>("BackgroundSong3");
		
		BackgroundMusicPlaylist();
    }

	/// <summary>
	/// A list of background music that might be played during a user's session in the world scene.
	/// </summary>
	public async void BackgroundMusicPlaylist()
	{
		// List of background songs.
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

	/// <summary>
	/// Returns the current state of gamePaused. Emits a signal from ToggleGamePausedEventHandler and is recieved in another script.
	/// </summary>
	/// <returns> A boolean determining if the pause menu will be shown. </returns>
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

	/// <summary>
	/// Returns the current state of gameInventory. Emits a signal from ToggleGameInventoryEventHandler and is recieved in another script.
	/// </summary>
	/// <returns> A boolean determining if the inventory will be shown. </returns>
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

	/// <summary>
	/// Handles input from the user. Allows them to pause the game and open their inventory.
	/// </summary>
	/// <param name="@event"> An event received from the game. </param>
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey){
			// When the Escape key is pressed the game pauses.
			if (eventKey.Pressed && eventKey.Keycode == Key.Escape){
				if (gameInventory == false){
					gamePaused = !gamePaused;
				}
			}
			// When the Q key is pressed it will either display the user's inventory or close it.
			else if (eventKey.Pressed && eventKey.Keycode == Key.Q){
				gameInventory = !gameInventory;
			}
		}
	}

	public void OnArea2DBodyEntered(Node body)
	{
		CallDeferred(nameof(DifferedSceneChange));
	}

	public void DifferedSceneChange()
	{
		GetTree().ChangeSceneToFile("res://scenes/battle.tscn");
	}
}