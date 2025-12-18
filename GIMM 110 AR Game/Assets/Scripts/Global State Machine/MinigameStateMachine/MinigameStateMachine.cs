using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MinigameStateMachine : MonoBehaviour
{

    public static MinigameStateMachine Instance; /*Singleton reference. This means that there will be one instance of this 
                                                  * gameobject across the whole game. It's to ensure that there isn't chaotic
                                                  * behavior from having mutliple of these objects.*/
                                                  
    public delegate void MinigameStateChanged(IMinigameState newState); /*Delegate is a keyword that defines what type of method this is.
                                                                         *It is just saying that the state changed with whatever new state it is. */
                                                                         
    public event MinigameStateChanged OnStateChanged; //This line is the one actually telling other scripts who have subscribed the information.

    public PlayerData activePlayerInfo;

    private IMinigameState currentState;

    public int GambleResult = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (FindObjectsByType<MinigameStateMachine>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        SwitchState(new BoardState(this));
    }
    
    void Update()
    {
        HandleInput();
        currentState?.Update();

        /*if (minigameTimer <= 0f)
        {
            EndMinigame();
            timerActive = false;
        }*/
    }

    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchState(new BoardState(this));
            Debug.Log("1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchState(new SingleRoomPlatformer(this));
            Debug.Log("2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchState(new HorizontalScroller(this));
            Debug.Log("3");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GambleResult = UnityEngine.Random.Range(1, 3);
            if (GambleResult == 1)
            {
                Debug.Log("result 1");
                SwitchState(new SingleRoomPlatformer(this));
                GambleResult = 0;
            }
            else if (GambleResult == 2)
            {
                Debug.Log("result 2");
                SwitchState(new HorizontalScroller(this));
                GambleResult = 0;
            }
        }
    }

    public void RandomMinigame()
    {
        GambleResult = UnityEngine.Random.Range(1, 3);
        if (GambleResult == 1)
        {
            Debug.Log("result 1");
            SwitchState(new SingleRoomPlatformer(this));
            GambleResult = 0;
        }
        else if (GambleResult == 2)
        {
            Debug.Log("result 2");
            SwitchState(new HorizontalScroller(this));
            GambleResult = 0;
        }
    }

    public void SwitchState(IMinigameState newState)
    {
        Debug.Log("Switching to " + newState.GetType().Name + " from scene " + SceneManager.GetActiveScene().name);
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();

        OnStateChanged?.Invoke(newState);
    }

    public IMinigameState GetCurrentState()
    {
        return currentState;
    }

    public void StopMinigameTimer()
    {
        EndMinigame();
    }
    

    private void EndMinigame()
    {
        Debug.Log("🏁 EndMinigame() called");

        if (scenePlayerInfo.Instance != null)
        {
            scenePlayerInfo.Instance.EndMinigame();  
        }
        else
        {
            Debug.LogWarning("MinigameSession.Instance is NULL, going to board anyway");
            SwitchState(new BoardState(this));
        }
    }
}

  