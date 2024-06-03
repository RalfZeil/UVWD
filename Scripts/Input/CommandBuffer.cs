using System.Collections.Generic;

public class CommandBuffer
{
    private Queue<InputCommand> commandBuffer;
    private const int maxBufferSize = 20;

    public CommandBuffer()
    {
        commandBuffer = new Queue<InputCommand>();
    }

    public void AddCommand(InputCommand command)
    {
        commandBuffer.Enqueue(command);
        if (commandBuffer.Count > maxBufferSize)
        {
            commandBuffer.Dequeue();
        }
    }

    public bool CheckSequence(params InputCommand[] sequence)
    {
        if (sequence.Length > commandBuffer.Count)
        {
            return false;
        }

        var bufferArray = commandBuffer.ToArray();
        for (int i = 0; i < sequence.Length; i++)
        {
            if (bufferArray[bufferArray.Length - sequence.Length + i] != sequence[i])
            {
                return false;
            }
        }

        return true;
    }

    public void Clear()
    {
        commandBuffer.Clear();
    }
}
