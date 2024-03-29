using Godot;
using System;
using System.Numerics;
using System.Reflection.PortableExecutable;

public partial class playable_character : CharacterBody2D
{
	int speed = 80;
	string player_state;
	private AnimatedSprite2D AnimatedSprite;

	public override void _Ready()
	{
		// 
		AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	
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
		PlayAnim(direction);
	}
		
	public void PlayAnim(Godot.Vector2 dir)
	{
  		if (player_state == "idle")
		{
			AnimatedSprite.Play("idle");
		}
		if (player_state == "walking")
		{
			if (dir.Y == -1)
				{
					AnimatedSprite.Play("n-walk");
				}
			if (dir.X == 1)
				{
					AnimatedSprite.Play("e-walk");
				}
			if (dir.Y == 1)
				{
					AnimatedSprite.Play("s-walk");
				}
			if (dir.X == -1)
				{
					AnimatedSprite.Play("w-walk");
				}

			if (dir.X > 0.5 && dir.Y < -0.5)
				{
					AnimatedSprite.Play("ne-walk");
				}
			if (dir.X < -0.5 && dir.Y < -0.5)
				{
					AnimatedSprite.Play("nw-walk");
				}
			if (dir.X < -0.5 && dir.Y > 0.5)
				{
					AnimatedSprite.Play("sw-walk");
				}
			if (dir.X > 0.5 && dir.Y > 0.5)
				{
					AnimatedSprite.Play("se-walk");
				}
		}
	}
}
