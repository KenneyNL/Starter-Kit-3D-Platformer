using Godot;
using System;

namespace StarterKit3DPlatformer;

public partial class Player : CharacterBody3D, ICollector
{
	[ExportSubgroup("Components")]
	[Export] public Node3D View;

	[ExportSubgroup("Properties")]
	[Export] public float MovementSpeed = 200f;
	[Export] public float JumpStrength = 6f;

	private Vector3 m_movementVelocity;
	private float m_rotationDirection;
	private float m_gravity;

	private bool m_previouslyFloored = false;
	private bool m_jumpSingle = true;
	private bool m_jumpDouble = true;
	private int m_coins = 0;

	private CpuParticles3D m_particlesTrail;
	private AudioStreamPlayer m_soundFootsteps;
	private Node3D m_model;
	private AnimationPlayer m_animation;
	
	[Signal]
	public delegate void CoinCollectedEventHandler(int coins);

	public override void _Ready()
	{
		m_particlesTrail = GetNode<CpuParticles3D>("ParticlesTrail");
		m_soundFootsteps = GetNode<AudioStreamPlayer>("SoundFootsteps");
		m_model = GetNode<Node3D>("Character");
		m_animation = GetNode<AnimationPlayer>("Character/AnimationPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{
		// Handle Functions
		HandleControls(delta);
		HandleGravity(delta);
		
		HandleAnimations();

		// Movement
		var appliedVelocity  = Velocity.Lerp(m_movementVelocity, (float)delta * 10f);
		appliedVelocity.Y = -m_gravity;
		Velocity = appliedVelocity;
		MoveAndSlide();

		// Rotation
		if (Velocity.Length() > 0f)
		{
			m_rotationDirection = new Vector2(Velocity.Z, Velocity.X).Angle();
		}

		var newRotation = Rotation;
		newRotation.Y = Mathf.LerpAngle(Rotation.Y, m_rotationDirection, (float)delta * 10f);
		Rotation = newRotation;

		// Scale Animation (Juice)
		m_model.Scale = m_model.Scale.Lerp(new Vector3(1f, 1f, 1f), (float)delta * 10f);
		
		// Animation when landing
		if (IsOnFloor() && m_gravity > 2f && !m_previouslyFloored)
		{
			m_model.Scale = new Vector3(1.25f, 0.75f, 1.25f);
		}

		m_previouslyFloored = IsOnFloor();
	}

	private void HandleControls(double delta)
	{
		// Movement
		var input = Vector3.Zero;
		input.X = Input.GetAxis("move_left", "move_right");
		input.Z = Input.GetAxis("move_forward", "move_back");

		m_movementVelocity = View.Basis * input * MovementSpeed * (float)delta;
		
		// Jumping
		if (Input.IsActionJustPressed("jump"))
		{
			if (m_jumpSingle || m_jumpDouble)
			{
				Audio.Instance.Play("res://audio/jump.ogg");
			}

			if (m_jumpDouble)
			{
				m_gravity = -JumpStrength;

				m_jumpDouble = false;
				m_model.Scale = new Vector3(0.5f, 1.5f, 0.5f);
			}

			if (m_jumpSingle)
			{
				Jump();
			}
		}
	}

	private void HandleGravity(double delta)
	{
		m_gravity += 25f * (float)delta;

		if (m_gravity > 0f && IsOnFloor())
		{
			m_jumpSingle = true;
			m_gravity = 0f;
		}
	}

	private void HandleAnimations()
	{
		m_particlesTrail.Emitting = false;
		m_soundFootsteps.StreamPaused = true;

		if (IsOnFloor())
		{
			if (Mathf.Abs(Velocity.X) > 1f || Mathf.Abs(Velocity.Z) > 1f)
			{
				m_animation.Play("walk", 0.5f);
				m_particlesTrail.Emitting = true;
				m_soundFootsteps.StreamPaused = false;
			}
			else
			{
				m_animation.Play("idle", 0.5f);
			}
		}
		else
		{
			m_animation.Play("jump", 0.5f);
		}
	}

	// Jumping
	private void Jump()
	{
		m_gravity = -JumpStrength;

		m_model.Scale = new Vector3(0.5f, 1.5f, 0.5f);

		m_jumpSingle = false;
		m_jumpDouble = true;
	}
	
	// Collecting Coins
	public void CollectCoin()
	{
		m_coins += 1;
		EmitSignal(SignalName.CoinCollected, m_coins);
	}
}
