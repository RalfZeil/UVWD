using Godot;
using System;
using System.Collections.Generic;

public enum StateType
{
	Idle,
	Walk,
	Crouch,
	Jump
}

public partial class StateMachine : Node2D
{
	private State _currentState;
	private State _previousState;
	private List<State> states;

	public override void _Ready()
	{
		// Add all the states to the list



		states = new List<State>(
			new IdleState(),
			new CrouchState()
		);

		ChangeState<IdleState>();
	}

	public void ChangeState<T>() where T : State
	{
		_previousState = _currentState;
		_currentState.Exit();
		_currentState = states.Find(state => state.GetType() == typeof(T));
		_currentState.Enter();
	}

	public override void _Process(double delta)
	{
		_currentState.Update(delta);
	}
}
