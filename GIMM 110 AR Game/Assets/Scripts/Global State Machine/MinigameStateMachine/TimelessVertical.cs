using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelessVertical : IMinigameState
{
    private readonly MinigameStateMachine machine;

    public TimelessVertical(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered Timeless vertical");
        SceneManager.LoadScene("TimelessVertical");
    }
    public void Update()
    {

    }
    public void Exit()
    {

    }

}
