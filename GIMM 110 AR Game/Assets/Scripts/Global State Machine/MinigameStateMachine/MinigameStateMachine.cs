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

    public float minigameTimer;
    public bool timerActive = false;

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
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchState(new ShopState(this));
            Debug.Log("4");
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

    public void StartMinigameTimer()
    {
        PlayerData activePlayerData = GameManager.Instance.GetActivePlayerData();

        if (activePlayerInfo != null)
        {
            minigameTimer = activePlayerData.minigameTimeLimit;
            timerActive = true;
            Debug.Log($"Minigame timer started: {minigameTimer} seconds");
        }
    }
    public void StopMinigameTimer()
    {
                timerActive = false;
        Debug.Log("Minigame timer stopped");
    }
}

  