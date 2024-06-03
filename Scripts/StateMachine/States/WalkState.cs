using Godot;
using System;

public partial class WalkState : GroundedState
{
    public WalkState(StateMachine _owner) : base(_owner) { }

    public override void Enter()
    {
        owner.blackboard._animationPlayer.Play("WalkForward");
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        if (Input.IsActionPressed("Left"))
        {
            owner.blackboard._characterBody2D.Velocity = (new Vector2(-1, 0) * owner.blackboard.moveSpeed);
        }
        else if (Input.IsActionPressed("Right"))
        {
            owner.blackboard._characterBody2D.Velocity = (new Vector2(1, 0) * owner.blackboard.moveSpeed);
        }

        owner.blackboard._characterBody2D.MoveAndSlide();
    }

    public override void Exit()
    {
    }
}
