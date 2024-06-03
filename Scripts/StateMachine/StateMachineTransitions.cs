using Godot;

public partial class StateMachine
{
    public void SetupTransitions()
    {
        transitions = new Transition[]
        {
            // From Idle to Others
            new Transition(StateType.Idle, StateType.Walk, () => Input.IsActionJustPressed("Right") || Input.IsActionJustPressed("Left")),
            new Transition(StateType.Idle, StateType.Crouch, () => Input.IsActionJustPressed("Down")),
            
            // Back to Idle
            new Transition(StateType.Walk, StateType.Idle, () => !Input.IsActionPressed("Right") && !Input.IsActionPressed("Left")),
            new Transition(StateType.Crouch, StateType.Idle, () => !Input.IsActionPressed("Down")),

            // From Idle to Attacks
            new Transition(StateType.Idle, StateType.LightPunch, () => Input.IsActionJustPressed("LightPunch")),
            new Transition(StateType.Idle, StateType.LightKick, () => Input.IsActionJustPressed("LightKick")),

            // Frow Crouch to Attacks
            new Transition(StateType.Crouch, StateType.LightPunch, () => Input.IsActionJustPressed("LightPunch")),
            new Transition(StateType.Crouch, StateType.LightKick, () => Input.IsActionJustPressed("LightKick")),
            
            //// From Grounded to Idle
            //new Transition(StateType.Grounded, StateType.Idle, () => true),
        };
    }
}
