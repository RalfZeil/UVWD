using Godot;
using System;

public class Transition
{
	public StateType fromState;
	public StateType toState;

	public Func<bool> condition;

	public Transition(StateType _from, StateType _to, Func<bool> _condition)
	{
		fromState = _from;
		toState = _to;
		condition = _condition;
	}

	public bool Evaluate()
	{
		return condition();
	}
}
