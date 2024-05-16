using Godot;
using System;

public partial class CrouchState : State
{
    public override void Enter()
    {
        GD.Print("Enter Crouch State");
    }

    public override void Update(double delta)
    {
        GD.Print("Updating Crouch State");
    }

    public override void Exit()
    {
        GD.Print("Exit Crouch State");
    }
}
