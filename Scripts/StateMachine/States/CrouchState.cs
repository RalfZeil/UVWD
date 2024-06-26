using Godot;
using System;

public partial class CrouchState : GroundedState
{
    public CrouchState(StateMachine _owner) : base(_owner) { }

    public override void Enter()
    {
        owner.blackboard._animationPlayer.Play("Crouching");
    }

    public override void Update(double delta)
    {
        base.Update(delta);
    }

    public override void Exit()
    {
    }
}
