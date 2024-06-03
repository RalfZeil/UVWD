using Godot;
using System;

public partial class GroundedState : State
{
    public GroundedState(StateMachine _owner) : base(_owner) { }

    public override void Enter()
    {
    }

    public override void Update(double delta)
    {
        base.Update(delta);
    }

    public override void Exit()
    {
    }
}