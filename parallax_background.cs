using Godot;
using System;

public partial class parallax_background : ParallaxBackground
{
	// The speed at which the parallax background moves. 
	public int scrollingSpeed = 1;
	public override void _Process(double delta)
	{
		// Parallax background moves horizontally while the menu screen is displayed.
		ScrollOffset += new Vector2(-scrollingSpeed, 0);
	}
}
