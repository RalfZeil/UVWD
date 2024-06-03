public partial class LightPunchState : AttackState
{
    private static float punchTime = 0.5f;

    public LightPunchState(StateMachine _owner) : base(_owner, punchTime) { }

    public override void Enter()
    {
        base.Enter();
        
        owner.blackboard._animationPlayer.Play("Punch");
        owner.blackboard._soundPlayer.Play();
    }

    // Attacks manage their own transitions
    public override void Update(double delta)
    {
        base.Update(delta);
        attackTimer -= (float)delta; 

        if(attackTimer <= 0 ) { owner.ChangeState(StateType.Idle); }
    }

    public override void Exit()
    {
        
    }
}
