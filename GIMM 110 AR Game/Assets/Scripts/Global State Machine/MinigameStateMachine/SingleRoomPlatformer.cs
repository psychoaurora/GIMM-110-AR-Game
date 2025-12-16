using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleRoomPlatformer : IMinigameState
{
    private readonly MinigameStateMachine machine;

    GameObject timerManager;

    public SingleRoomPlatformer(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entering Single Room Platformer");
        SceneManager.LoadScene("SingleRoomPlatformer", LoadSceneMode.Additive);

        //machine.StartMinigameTimer();

        IMinigameState singleRoomPlatformer = this;

        timerManager = GameObject.Find("TimerManager");

        timerManager.GetComponent<TimerManager>().StartSceneTimer(15f, singleRoomPlatformer);
    }

    public void Update()
    {
        
    }

    public void Exit()
    {
        Debug.Log("Exiting Single Room Platformer");
        SceneManager.UnloadSceneAsync("SingleRoomPlatformer");
    }
}
