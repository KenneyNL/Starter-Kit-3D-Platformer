using System;
using Godot;

namespace StarterKit3DPlatformer;

public partial class View : Node3D
{
	[ExportGroup("Properties")]
	[Export] public Node3D Target;
	
	[ExportGroup("Zoom")]
	[Export] public float ZoomMinimum = 16f;
	[Export] public float ZoomMaximum = 4f;
	[Export] public float ZoomSpeed = 10f;
	
	[ExportGroup("Rotation")]
	[Export] public float RotationSpeed = 120f;

	private Vector3 m_cameraRotation;
	private float m_zoom = 10f;
	private Camera3D m_camera;

	public override void _Ready()
	{
		base._Ready();

		m_camera = GetNode<Camera3D>("Camera");

		m_cameraRotation = RotationDegrees;
	}

	public override void _PhysicsProcess(double delta)
	{
		Position = Position.Lerp(Target.Position, (float)delta * 4f);
		RotationDegrees = RotationDegrees.Lerp(m_cameraRotation, (float)delta * 6f);
		
		m_camera.Position = m_camera.Position.Lerp(new Vector3(0f, 0f, m_zoom), 8f * (float)delta);
		HandleInput(delta);
	}

	private void HandleInput(double delta)
	{
		// Rotation
		var input = Vector3.Zero;
		input.Y = Input.GetAxis("camera_left", "camera_right");
		input.X = Input.GetAxis("camera_up", "camera_down");

		m_cameraRotation += input * RotationSpeed * (float)delta;
		m_cameraRotation.X = Mathf.Clamp(m_cameraRotation.X, -80, -10);
		
		// Zooming
		m_zoom += Input.GetAxis("zoom_in", "zoom_out") * ZoomSpeed * (float)delta;
		m_zoom = Mathf.Clamp(m_zoom, ZoomMaximum, ZoomMinimum);
	}
}
