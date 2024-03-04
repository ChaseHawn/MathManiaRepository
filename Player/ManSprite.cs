using Godot;
using System;

public partial class ManSprite : CharacterBody2D
{
	int speed = 100;
	string player_state;
	private AnimatedSprite2D AnimatedSprite;
	
	public override void _PhysicsProcess(double delta)
	{
		var direction = Input.GetVector("left", "right", "up", "down");
		
		if (direction.X == 0 && direction.Y == 0)
		{
			player_state = "idle";
		}
		else if (direction.X != 0 || direction.Y != 0)
		{
			player_state = "walking";
		}
		Velocity = direction * speed;
		MoveAndSlide();
		
		PlayAnim();
	}
	
	public void PlayAnim()
	{
		GD.Print("TEST");
  		if (player_state == "idle")
		{
			AnimatedSprite.Play("idle");
		}
		if (player_state == "walking")
		{
			AnimatedSprite.Stop();
		}
	}
}
