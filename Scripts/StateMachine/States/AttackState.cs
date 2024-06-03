public partial class AttackState : State
{

    protected float attackTime;
    protected float attackTimer = 0.0f;

    public AttackState(StateMachine _owner, float _attackTime) : base(_owner) { this.attackTime = _attackTime; }

    public override void Enter()
    {
        attackTimer = attackTime;
    }

    public override void Update(double delta)
    {
        base.Update(delta);
    }

    public override void Exit()
    {
    }
}