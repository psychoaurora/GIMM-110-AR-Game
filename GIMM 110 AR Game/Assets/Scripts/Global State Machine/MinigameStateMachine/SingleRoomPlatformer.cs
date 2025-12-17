using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleRoomPlatformer : IMinigameState
{
    private readonly MinigameStateMachine machine;

    GameObject timerManager;
    GameObject arCamera;

    public SingleRoomPlatformer(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entering Single Room Platformer");
        SceneManager.LoadScene("SingleRoomPlatformer", LoadSceneMode.Additive);

        IMinigameState singleRoomPlatformer = this;

        timerManager = GameObject.Find("TimerManager");
        timerManager.GetComponent<TimerManager>().StartSceneTimer(15f, singleRoomPlatformer);

        arCamera = GameObject.Find("ARCamera");

        if (arCamera != null)
        {
            arCamera.SetActive(false);
        }

        //scenePlayerInfo.Instance.UpdatePlayerVisuals();
    }

    

    public void Update()
    {
        
    }

    public void Exit()
    {
        Debug.Log("Exiting Single Room Platformer");
        SceneManager.UnloadSceneAsync("SingleRoomPlatformer");

        if (arCamera != null)
        {
            arCamera.SetActive(true);
        }
        GameManager.Instance.SwitchToNextPlayer();
    }
}
