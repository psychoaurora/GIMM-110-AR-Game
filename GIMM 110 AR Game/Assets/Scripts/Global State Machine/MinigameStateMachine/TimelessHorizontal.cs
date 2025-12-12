using UnityEngine;

public class TimelessHorizontal : IMinigameState
{
    private readonly MinigameStateMachine machine;

    public TimelessHorizontal(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered Timeless horizontal");
    } 
    public void Update()
    {

    }
    public void Exit()
    {

    }
   
}
