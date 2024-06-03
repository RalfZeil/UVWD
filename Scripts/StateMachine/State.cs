using Godot;
using System;

public partial class State : Node2D
{
	protected StateMachine owner;

	public State(StateMachine _owner)
	{
		owner = _owner;
	}

	public virtual void Enter() { }
	public virtual void Update(double delta) { }
	public virtual void Exit() { }
}
