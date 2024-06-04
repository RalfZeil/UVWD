using Godot;
using System.Collections.Generic;

public enum StateType
{
	Idle,
	Walk,
	Crouch,
	Jump,
	LightPunch,
	LightKick,
	Hadouken,
	Shoryuken,
	Grounded,
	Attack
}

public partial class StateMachine : Node2D
{
	[Export] public NodePath BlackboardPath;
	public Blackboard blackboard { get; private set; }

	private StateType _currentState;
	private StateType _previousState;
	private Dictionary<StateType, State> stateMap;

	private Transition[] transitions;

	public CommandBuffer commandBuffer = new CommandBuffer();

	public override void _Ready()
	{
		blackboard = GetNode<Blackboard>(BlackboardPath);

		SetupStates();
		SetupTransitions();

		ChangeState(StateType.Idle);
	}

	public void SetupStates()
	{
		stateMap = new Dictionary<StateType, State>
		{
			{ StateType.Idle, new IdleState(this) },
			{ StateType.Walk, new WalkState(this) },
			{ StateType.Crouch, new CrouchState(this) },
			{ StateType.LightPunch, new LightPunchState(this) },
			{ StateType.LightKick, new LightKickState(this) },
			//{ StateType.Hadouken, new HadoukenState(this) },
			{ StateType.Shoryuken, new ShoryukenState(this) },
		};
	}

	public void ChangeState(StateType newState)
	{
		if (_currentState != newState)
		{
			stateMap[_currentState]?.Exit();
			_previousState = _currentState;
			_currentState = newState;

			if (newState == StateType.Grounded)
			{
				_currentState = StateType.Idle; // Default to Idle when transitioning to Grounded
			}

			stateMap[_currentState].Enter();
		}
	}

	public override void _Process(double delta)
	{
		stateMap[_currentState].Update(delta);

		UpdateInput();

		// Check for transitions
		foreach (var transition in transitions)
		{
			if (transition.fromState == _currentState && transition.condition())
			{
				ChangeState(transition.toState);
			}
		}
	}
}
