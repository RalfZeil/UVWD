using Godot;

public enum InputCommand
{
    Neutral,
    Up,
    Down,
    Left,
    Right,
    UpLeft,
    UpRight,
    DownLeft,
    DownRight,
    LightPunch,
    LightKick,
}

public partial class StateMachine
{
    private void UpdateInput()
    {
        if (Input.IsActionPressed("Up"))
        {
            if (Input.IsActionPressed("Left"))
            {
                commandBuffer.AddCommand(InputCommand.UpLeft);
            }
            else if (Input.IsActionPressed("Right"))
            {
                commandBuffer.AddCommand(InputCommand.UpRight);
            }
            else
            {
                commandBuffer.AddCommand(InputCommand.Up);
            }
        }
        else if (Input.IsActionPressed("Down"))
        {
            if (Input.IsActionPressed("Left"))
            {
                commandBuffer.AddCommand(InputCommand.DownLeft);
            }
            else if (Input.IsActionPressed("Right"))
            {
                commandBuffer.AddCommand(InputCommand.DownRight);
            }
            else
            {
                commandBuffer.AddCommand(InputCommand.Down);
            }
        }
        else if (Input.IsActionPressed("Left"))
        {
            commandBuffer.AddCommand(InputCommand.Left);
        }
        else if (Input.IsActionPressed("Right"))
        {
            commandBuffer.AddCommand(InputCommand.Right);
        }
        else
        {
            commandBuffer.AddCommand(InputCommand.Neutral);
        }

        if (Input.IsActionJustPressed("LightPunch"))
        {
            commandBuffer.AddCommand(InputCommand.LightPunch);
        }
        else if (Input.IsActionJustPressed("LightKick"))
        {
            commandBuffer.AddCommand(InputCommand.LightKick);
        }
    }
}

