using Godot;
using System;

public partial class animated_menu_title : AnimatedSprite2D
{
	public override void _Ready()
    {
        //Plays animation for menu title
        Play("default");
    }
}
