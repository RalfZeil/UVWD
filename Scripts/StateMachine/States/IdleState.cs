using Godot;

public partial class IdleState : GroundedState
{
	public IdleState(StateMachine _owner) : base(_owner) { }

	public override void Enter()
	{
		owner.blackboard._animationPlayer.Play("Idle");
	}

	public override void Update(double delta)
	{
		base.Update(delta);
	}

	public override void Exit()
	{
	}
}
