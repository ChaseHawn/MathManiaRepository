using Godot;
using System;

public partial class ManSprite : CharacterBody2D
{
	int speed = 100;
<<<<<<< HEAD
	string player_state;
	private AnimatedSprite2D AnimatedSprite;

	public override void _Ready()
    {
        AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }
=======
	string player_state = "";
>>>>>>> parent of b0efae3 (Test)
	
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
		
<<<<<<< HEAD
		MoveAndSlide();
		PlayAnim();
=======
		PlayAnim(direction);
>>>>>>> parent of b0efae3 (Test)
	}
	
	public void PlayAnim(string dir)
	{
  		if (player_state == "idle")
		{
			ManSprite.AnimatedSprite2D.Play("idle");
		}
		if (player_state == "walking")
		{
			ManSprite.AnimatedSprite2D.Stop();
		}
	}
}