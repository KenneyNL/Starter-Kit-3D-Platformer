using Godot;

namespace StarterKit3DPlatformer;

public partial class Hud : Node
{
	private Label m_coins;

	public override void _Ready()
	{
		m_coins = GetNode<Label>("Coins");
	}

	public void OnCoinCollected(int coins)
	{
		m_coins.Text = coins.ToString();
	}
}
