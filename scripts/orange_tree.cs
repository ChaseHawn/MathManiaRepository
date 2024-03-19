using Godot;
using System;

public partial class orange_tree : Node2D
{
	// Called when the node enters the scene tree for the first time.

	string state = "without_oranges";
	bool player_in_area = false;

	public Timer growthTimer;
	public AnimatedSprite2D animatedSprite2D;
	public AudioStreamPlayer collectFruit;

	public override void _Ready()
	{
		growthTimer = GetNode<Timer>("GrowthTimer");
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		collectFruit = GetNode<AudioStreamPlayer>("CollectFruit");

		NewRandomGrowthTime();
	}

	public void NewRandomGrowthTime(){
		var rand = new Random();
		var randGrowthTime = rand.Next(60, 120);
		growthTimer.WaitTime = randGrowthTime;

		if(state == "without_oranges"){
			growthTimer.Start();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (state == "without_oranges"){
			animatedSprite2D.Play("without_oranges");
		}
		else {
			animatedSprite2D.Play("with_oranges");
			if (player_in_area == true){
				if (Input.IsActionJustPressed("e")){
					state = "without_oranges";
					collectFruit.Play();
					growthTimer.Start();
				}
			}
		}
	}

	public void OnPickableAreaBodyEntered(playable_character playable_Character)
	{
		player_in_area = true;
	}

	public void OnPickableAreaBodyExited(playable_character playable_Character)
	{
		player_in_area = false;
	}

	public void OnGrowthTimerTimeout()
	{
		if (state == "without_oranges"){
			state = "with_oranges";
			NewRandomGrowthTime();
		}
	}
}
