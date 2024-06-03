public partial class LightKickState : AttackState
{
    private static float kickTime = 0.4f;

    public LightKickState(StateMachine _owner) : base(_owner, kickTime) { }

    public override void Enter()
    {
        base.Enter();

        owner.blackboard._animationPlayer.Play("Kick");
        owner.blackboard._soundPlayer.Play();
    }

    // Attacks manage their own transitions
    public override void Update(double delta)
    {
        base.Update(delta);
        attackTimer -= (float)delta;

        if (attackTimer <= 0) { owner.ChangeState(StateType.Idle); }
    }

    public override void Exit()
    {
    }
}
