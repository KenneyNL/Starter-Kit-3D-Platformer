using Godot;
using System.Collections.Generic;
using System.Linq;

namespace StarterKit3DPlatformer;

public partial class Audio : Node
{
	public static Audio Instance;
	
	private int m_players = 12;
	private string m_bus = "master";
	private List<AudioStreamPlayer> m_available = new();
	private List<string> m_queue = new();

	public override void _EnterTree()
	{
		Instance = this;
	}

	public override void _Ready()
	{
		for (int i = 0; i < m_players; i++)
		{
			var audioStreamPlayer = new AudioStreamPlayer();
			AddChild(audioStreamPlayer);
			
			m_available.Add(audioStreamPlayer);

			audioStreamPlayer.VolumeDb = -10;
			audioStreamPlayer.Bus = m_bus;
		}
	}

	public override void _Process(double delta)
	{
		if (m_queue.Count > 0 && m_available.Any(x => !x.Playing))
		{
			var queueItem = m_queue[0];
			var audioStreamPlayer = m_available.First(x => !x.Playing);
			
			audioStreamPlayer.Stream = GD.Load<AudioStream>(queueItem);
			audioStreamPlayer.Play();
			audioStreamPlayer.PitchScale = (float)GD.RandRange(0.9f, 1.1f);

			m_queue.Remove(queueItem);
		}
	}

	public void Play(string soundPath)
	{
		m_queue.Add(soundPath);
	}
}
