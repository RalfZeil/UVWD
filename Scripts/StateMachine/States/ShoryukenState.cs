public partial class ShoryukenState : AttackState
{
    private static float shoryukenTime = 0.8f;

    public ShoryukenState(StateMachine _owner) : base(_owner, shoryukenTime) { }

    public override void Enter()
    {
        base.Enter();

        owner.blackboard._animationPlayer.Play("Shoryuken");
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
