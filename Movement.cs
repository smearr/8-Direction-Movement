using Godot;
using System;

public class Player : KinematicBody2D
{
	public Vector2 velocity = new Vector2();
	
	//Children
	public AnimatedSprite anim;
	
	//boolean
	public bool going_idle = false;
	
	public override void _Ready()
	{
		anim = GetNode<AnimatedSprite>("AnimatedSprite");
	}
	
	public void GetInput()
	{
		velocity = new Vector2();

		if (Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_up") && !Input.IsActionPressed("ui_down"))
		{
			velocity.x += 1;
			anim.Play("running-right");
		}

		if (Input.IsActionPressed("ui_left") && !Input.IsActionPressed("ui_up") && !Input.IsActionPressed("ui_down"))
		{
			velocity.x -= 1;
			anim.Play("running-left");
		}
			

		if (Input.IsActionPressed("ui_down") && !Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_left"))
		{
			velocity.y += 1;
			anim.Play("running-down");
		}

		if (Input.IsActionPressed("ui_up") && !Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_left"))
		{
			velocity.y -= 1;
			anim.Play("running-up");
		}
		
		else if (Input.IsActionPressed("ui_up") && Input.IsActionPressed("ui_right"))
		{
			anim.Play("running-ne");
			velocity.x += 1;
			velocity.y -= 1;
		}
		
		else if (Input.IsActionPressed("ui_down") && Input.IsActionPressed("ui_right"))
		{
			anim.Play("running-se");
			velocity.x += 1;
			velocity.y += 1;
		}
		
		else if (Input.IsActionPressed("ui_down") && Input.IsActionPressed("ui_left"))
		{
			anim.Play("running-sw");
			velocity.x -= 1;
			velocity.y += 1;
		}
		
		else if (Input.IsActionPressed("ui_up") && Input.IsActionPressed("ui_left"))
		{
			anim.Play("running-nw");
			velocity.x -= 1;
			velocity.y -= 1;
		}
		
		else if (velocity.x == 0 && velocity.y == 0)
		{
			anim.Stop();
		}
		

		velocity = velocity.Normalized() * 50;
	}

	public override void _PhysicsProcess(float delta)
	{
		GetInput();
		velocity = MoveAndSlide(velocity);
				

	}
	
}



