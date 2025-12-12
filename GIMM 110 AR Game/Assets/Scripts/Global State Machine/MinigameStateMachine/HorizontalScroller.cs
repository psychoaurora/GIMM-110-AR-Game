using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorizontalScroller : IMinigameState
{
    private readonly MinigameStateMachine machine;

    public HorizontalScroller(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered Horizontal scroller");
        SceneManager.LoadScene("HorizontalScroller");
    }
    public void Update()
    {

    }
    public void Exit()
    {

    }
}
