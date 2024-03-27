using Godot;
using System;

public partial class parallax_background : ParallaxBackground
{
	public float scrollingSpeed = 0.5f;

	/// <summary>
	/// Parallax background moves horizontally while the menu screen is displayed.
	/// </summary>
	public override void _Process(double delta)
	{
		ScrollOffset += new Vector2(-scrollingSpeed, 0);
	}
}
