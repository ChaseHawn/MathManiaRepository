using Godot;
using System;
using System.Numerics;
using System.Reflection.PortableExecutable;

public partial class playable_character : CharacterBody2D
{
	int speed = 70;
	string player_state;
	private AudioStreamPlayer Grass;
	private AnimatedSprite2D AnimatedSprite;
	private Node2D AppleTree;

	public override void _Ready()
	{
		// 
		AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Grass = GetNode<AudioStreamPlayer>("/root/World/Grass");
		AppleTree = GetNode<Node2D>("/root/World/AppleTree");
		
		Godot.Vector2 currentPosition = Position;
		currentPosition += AppleTree.GlobalPosition;
		Position = currentPosition;
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
			Grass.Play();
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
	public void OnArea2DBodyEntered(Node body)
	{
		if (body.IsInGroup("fakegrass")){
			CallDeferred(nameof(DifferedSceneChange));
		}
	}

	public void DifferedSceneChange()
	{
		GetTree().ChangeSceneToFile("res://scenes/battle.tscn");
	}
}