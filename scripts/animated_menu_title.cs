using Godot;
using System;

public partial class animated_menu_title : AnimatedSprite2D
{
	public override void _Ready()
    {
        // The main menu title animation plays.
        Play("default");
    }
}