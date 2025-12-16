using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorizontalScroller : IMinigameState
{
    private readonly MinigameStateMachine machine;

    GameObject timerManager;

    public HorizontalScroller(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered Horizontal scroller");
        SceneManager.LoadScene("HorizontalScroller", LoadSceneMode.Additive);

        IMinigameState horizontalScroller = this;

        timerManager = GameObject.Find("TimerManager");

        timerManager.GetComponent<TimerManager>().StartSceneTimer(15f, horizontalScroller);
    }
    public void Update()
    {

    }
    public void Exit()
    {
        SceneManager.UnloadSceneAsync("HorizontalScroller");
    }
}
