using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MinigameStateMachine : MonoBehaviour
{
    
    private IMinigameState currentState;

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
            SwitchState(new PlatformerMinigameState(this));
            Debug.Log("2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchState(new ShooterMinigameState(this));
            Debug.Log("3");
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
    }
}
  