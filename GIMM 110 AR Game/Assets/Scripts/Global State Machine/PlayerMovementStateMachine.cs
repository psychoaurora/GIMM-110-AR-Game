using UnityEngine;

public class PlayerMovementStateMachine : MonoBehaviour
{
    private IPlayerMovementState currentState;
    public bool enabledByScene = false;
    public PlayerMovement player;
    public float walkSpeed = 8;
    public float jumpForce = 8;
    public int maxJumps = 1;
    public int currentJumps;

    private void Awake()
    {

        Debug.Log("[PlayerMovementStateMachine] Awake called");

        player = GetComponent<PlayerMovement>();
        currentJumps = maxJumps;

        if (player == null)
        {
            Debug.LogError("[PlayerMovementStateMachine] PlayerMovement component not found!");
        }

    }

    private void OnDisable()
    {
        Debug.Log("[PlayerMovementStateMachine] OnDisable called");

        // Safely unsubscribe
        if (MinigameStateMachine.Instance != null)
        {
            MinigameStateMachine.Instance.OnStateChanged -= HandleSceneStateChange;
        }
    }

    // Call this if MinigameStateMachine loads after PlayerMovementStateMachine
    private void Start()
    {
        // Double-check sync in case Instance wasn't available in OnEnable
        if (MinigameStateMachine.Instance != null && currentState == null)
        {
            Debug.Log("[PlayerMovementStateMachine] Syncing in Start (backup)");
            MinigameStateMachine.Instance.OnStateChanged += HandleSceneStateChange;

            SyncWithCurrentMinigameState();
        }
        else if (MinigameStateMachine.Instance == null)
        {
            Debug.LogError("[PlayerMovementStateMachine] MinigameStateMachine.Instance is STILL NULL in Start!");
        }
    }

    public void Update()
    {
        if (!enabledByScene)
        {
            return;
        }
        currentState?.Update();
    }

    public void SwitchState(IPlayerMovementState newState)
    {
        Debug.Log($"[PlayerMovementStateMachine] Switching state from {currentState?.GetType().Name ?? "null"} to {newState?.GetType().Name ?? "null"}");

        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    private void HandleSceneStateChange(IMinigameState state)
    {
        Debug.Log($"[PlayerMovementStateMachine] HandleSceneStateChange called with: {state?.GetType().Name ?? "null"}");

        if (state is PlatformerMinigameState || state is ShooterMinigameState || state is HorizontalScroller || state is SingleRoomPlatformer || state is VerticalScroller || state is TimelessHorizontal)
        {
            enabledByScene = true;
            SwitchState(new IdleState(this));
            Debug.Log("[PlayerMovementStateMachine] Player movement ENABLED - switched to IdleState");
        }
        else
        {
            enabledByScene = false;
            SwitchState(null);
            Debug.Log($"[PlayerMovementStateMachine] Player movement DISABLED for {state?.GetType().Name ?? "null"}");

        }
    }

    // Sync with whatever state the MinigameStateMachine is currently in
    private void SyncWithCurrentMinigameState()
    {
        Debug.Log("[PlayerMovementStateMachine] SyncWithCurrentMinigameState called");

        IMinigameState currentMinigameState = MinigameStateMachine.Instance.GetCurrentState();

        if (currentMinigameState != null)
        {
            Debug.Log($"[PlayerMovementStateMachine] Current minigame state is: {currentMinigameState.GetType().Name}");
            HandleSceneStateChange(currentMinigameState);
        }
        else
        {
            Debug.LogWarning("[PlayerMovementStateMachine] Current minigame state is NULL");
        }
    }
}