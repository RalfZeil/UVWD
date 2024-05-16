using Godot;
using System;

public partial class IdleState : State
{
	public override void Enter()
	{
        GD.Print("Entering Idle State");
    }

	public override void Update(double delta)
	{
		GD.Print("Updating Idle State");
	}

	public override void Exit()
	{
        GD.Print("Exiting Idle State");
    }
}

