using Godot;

namespace StarterKit3DPlatformer;

public partial class Coin : Area3D
{
	private float m_time = 0f;
	private bool m_grabbed = false;
	
	public void OnBodyEntered(Node3D body)
	{
		if (!m_grabbed && body is ICollector collector)
		{
			collector.CollectCoin();
			
			Audio.Instance.Play("res://audio/coin.ogg");

			GetNode<Node>("Mesh").QueueFree();
			GetNode<CpuParticles3D>("Particles").Emitting = false;

			m_grabbed = true;
		}
	}

	public override void _Process(double delta)
	{
		RotateY(2 * (float)delta);
		Position += new Vector3(0f, (Mathf.Cos(m_time * 5f) * 1f) * (float)delta, 0f);

		m_time += (float)delta;
	}
}
