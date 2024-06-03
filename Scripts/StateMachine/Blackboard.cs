using Godot;

public partial class Blackboard : Node
{
	[Export] private NodePath CharacterBody2DPath;
	[Export] private NodePath AnimationPlayerPath;
	[Export] private NodePath SoundPlayerPath;

	public bool isFacingRight = true;
	public float moveSpeed = 200.0f;

	public CharacterBody2D _characterBody2D;
	public AnimatedSprite2D _animationPlayer;
	public AudioStreamPlayer2D _soundPlayer;

	public override void _Ready()
	{
		_characterBody2D = GetNode<CharacterBody2D>(CharacterBody2DPath);
		_animationPlayer = GetNode<AnimatedSprite2D>(AnimationPlayerPath);
		_soundPlayer = GetNode<AudioStreamPlayer2D>(SoundPlayerPath);
	}
}
