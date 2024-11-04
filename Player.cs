using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private Vector2 _speed;
	private Sprite2D _sprite;
	private float _jumpVelocity = -600.0f;
	private float _gravity = 1000.0f;
	private Vector2 _velocity = Vector2.Zero;
	public override void _Ready()
	{
		_speed = new Vector2(200, 0);
		_sprite = GetNode<Sprite2D>("Sprite2D");
	}

	public override void _Process(double delta)
	{
		_velocity.Y += _gravity * (float) delta;

		if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
		{
			_velocity.Y = _jumpVelocity;
		}

		if (Input.IsActionPressed("ui_left"))
		{
			_sprite.Position -= _speed * (float) delta;
		}

		if (Input.IsActionPressed("ui_right"))
		{
			_sprite.Position += _speed * (float) delta;
		}

		_sprite.Position += _velocity * (float)delta;

		if(_sprite.Position.X > 1000){
			_sprite.Position = new Vector2(-100, 350);
			_velocity = Vector2.Zero;
		}

		if (_sprite.Position.Y > 290)
		{
			_sprite.Position = new Vector2(_sprite.Position.X, 290);
			_velocity.Y = 0;
		}
	}

	private bool IsOnFloor()
	{
		return _sprite.Position.Y >= 290;
	}
}
