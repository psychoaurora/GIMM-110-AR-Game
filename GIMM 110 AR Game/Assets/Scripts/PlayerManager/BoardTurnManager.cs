using UnityEditor.Splines;
using UnityEngine;
using UnityEngine.UI;

public class BoardTurnManager : MonoBehaviour
{
    [Header("UI References")]
    public Button shopButton;
    public GameObject cardDisplay;

    [Header("Board References")]
    //public SplineGen splineGen; // Your board movement script

    [Header("Special Tiles")]
    public int gingerbreadManTile;
    public int candyCaneTile;
    public int gumdropTile;
    public int peanutTile;
    public int lollipopTile;
    public int iceCreamTile;
    public int winningTile;

    private bool turnInProgress = false;
    private bool waitingForMinigame = false;

    /*private void Start()
    {
        // Setup shop button
        if (shopButton != null)
        {
            shopButton.onClick.AddListener(OnShopButtonClicked);
            shopButton.gameObject.SetActive(false);
        }
    }
    */
    public void StartPlayerTurn()
    {
        if (turnInProgress) return;

        turnInProgress = true;
        waitingForMinigame = false;

        Debug.Log($"Player {ActivePlayerManager.Instance.activePlayerIndex + 1}'s turn starting");

        // Show shop button
        if (shopButton != null)
        {
            shopButton.gameObject.SetActive(true);
        }

        // Wait for player to either:
        // 1. Click shop button
        // 2. Pull a card and move (you'd call MovePlayer from your card system)
    }

    private void OnShopButtonClicked()
    {
        Debug.Log("Player wants to visit shop");
        shopButton.gameObject.SetActive(false);

        // Go to shop
        MinigameStateMachine.Instance.SwitchState(new ShopState(MinigameStateMachine.Instance));
    }

    /*public void MovePlayer(int spaces)
    {
        // Hide shop button once player commits to moving
        if (shopButton != null)
        {
            shopButton.gameObject.SetActive(false);
        }

        // Use your SplineGen to move the player
        if (splineGen != null)
        {
            splineGen.MovePlayer(spaces);
        }

        // After movement completes, check the tile
        // (You'd call this from SplineGen when movement finishes)
        // For now, simulate with a delay:
        Invoke(nameof(CheckLandedTile), 2f);
    }

    private void CheckLandedTile()
    {
        int currentTile = splineGen.currentTile; // Get from your SplineGen

        Debug.Log($"Player landed on tile {currentTile}");

        // Check for winning tile
        if (currentTile == winningTile)
        {
            Debug.Log("Player reached the winning tile!");
            // Handle win condition
            return;
        }

        // Check for special tiles
        if (currentTile == gingerbreadManTile ||
            currentTile == candyCaneTile ||
            currentTile == gumdropTile ||
            currentTile == peanutTile ||
            currentTile == lollipopTile ||
            currentTile == iceCreamTile)
        {
            Debug.Log("Special tile! Starting minigame...");
            StartMinigameFromTile(currentTile);
        }
        else
        {
            // Normal tile, end turn
            EndTurn();
        }
    }

    private void StartMinigameFromTile(int tileNumber)
    {
        waitingForMinigame = true;

        // Choose minigame based on tile
        // For example:
        if (tileNumber == gingerbreadManTile || tileNumber == candyCaneTile)
        {
            MinigameStateMachine.Instance.SwitchState(new PlatformerMinigameState(MinigameStateMachine.Instance));
        }
        else
        {
            MinigameStateMachine.Instance.SwitchState(new ShooterMinigameState(MinigameStateMachine.Instance));
        }
    }
    */

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            EndTurn();
        }
    }
    private void EndTurn()
    {
        Debug.Log("Turn ended");
        turnInProgress = false;

        // If we didn't go to a minigame, advance to next player
        if (!waitingForMinigame)
        {
            AdvanceToNextPlayer();
        }
        // If we did go to a minigame, BoardState.Enter() will handle advancing
    }

    private void AdvanceToNextPlayer()
    {
        if (ActivePlayerManager.Instance != null)
        {
            ActivePlayerManager.Instance.SwitchToNextPlayer();

            // Start the next player's turn
            Invoke(nameof(StartPlayerTurn), 0.5f); // Small delay for clarity
        }
    }
}