using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Vuforia;

public class SplineGen : MonoBehaviour
{
    [Header("Color Tile Targets")]
    public GameObject RedTile;
    public GameObject PurpleTile;
    public GameObject YellowTile;
    public GameObject BlueTile;
    public GameObject OrangeTile;
    public GameObject GreenTile;
    public GameObject DoubleRedTile;
    public GameObject DoublePurpleTile;
    public GameObject DoubleYellowTile;
    public GameObject DoubleBlueTile;
    public GameObject DoubleOrangeTile;
    public GameObject DoubleGreenTile;

    [Header("Board Tiles")]
    public GameObject[] boardTiles;

    [Header("Tile Index Groups")]
    public int[] redTiles;
    public int[] purpleTiles;
    public int[] yellowTiles;
    public int[] blueTiles;
    public int[] orangeTiles;
    public int[] greenTiles;

    private SplineContainer splineContainer;

    [Header("Tile Tracking")]
    public int currentTile;
    public int currentTracker;
    public int currentTracker2;
    public int destination;

    [Header("Character Tiles")]
    public int gingerbreadMan = 9;
    public int candyCane = 20;
    public int gumdrop = 42;
    public int peanut = 69;
    public int lollipop = 92;
    public int iceCream = 102;

    [Header("Special Tiles")]
    public int[] licoriceTiles = { 46, 86, 117 };
    public int winTile = 134;

    public int bridgeStart1 = 5;
    public int bridgeEnd1 = 59;

    public int bridgeStart2 = 35;
    public int bridgeEnd2 = 45;

    [Header("Turn Blocking")]
    public bool locked;
    public bool lockedLastTurn;

    void Start()
    {
        splineContainer = GetComponent<SplineContainer>();
    }

    void Update()
    {
        HandleMovementKeys();
        HandleCardInput();
        HandleSpecialTiles();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartplayermoveandSpline());
        }
    }

    // -------------------------------------------------------------
    // MOVEMENT INPUT
    // -------------------------------------------------------------
    void HandleMovementKeys()
    { // Draw spline path from current → destination
      if (Input.GetKeyDown(KeyCode.E)) { if (destination >= 0 && destination < boardTiles.Length) 
            { 
                for (int i = currentTile; i <= destination; i++) AddSplinePoint(i); 
            } 
        } 
      // Clear spline + update trackers
      if (Input.GetKeyDown(KeyCode.Q)) 
        { 
            currentTracker = destination; 
            currentTile = destination; 
            currentTracker2 = destination; 
            splineContainer.Spline.Clear(); 
        } 
    }

        // -------------------------------------------------------------
        // CARD INPUT
        // -------------------------------------------------------------
        void HandleCardInput()
    {
        // Character tile keys
        //if (Input.GetKeyDown(KeyCode.R)) destination = gingerbreadMan;
        //else if (Input.GetKeyDown(KeyCode.T)) destination = candyCane;
        //else if (Input.GetKeyDown(KeyCode.Z)) destination = gumdrop;
        //else if (Input.GetKeyDown(KeyCode.X)) destination = peanut;
        //else if (Input.GetKeyDown(KeyCode.J)) destination = lollipop;
        //else if (Input.GetKeyDown(KeyCode.K)) destination = iceCream;
        //// Single color via Vuforia tracking
        //else if (RedTile.GetComponent<ImageTargetBehaviour>()) FindSingleTile(redTiles);
        ////StartCoroutine(SplineCreator()); 
        //else if (PurpleTile.GetComponent<ImageTargetBehaviour>()) FindSingleTile(purpleTiles);
        //// StartCoroutine(SplineCreator());
        //else if (YellowTile.GetComponent<ImageTargetBehaviour>()) FindSingleTile(yellowTiles);
        //// StartCoroutine(SplineCreator());
        //else if (BlueTile.GetComponent<ImageTargetBehaviour>()) FindSingleTile(blueTiles);
        //// StartCoroutine(SplineCreator());
        //else if (OrangeTile.GetComponent<ImageTargetBehaviour>()) FindSingleTile(orangeTiles);
        //// StartCoroutine(SplineCreator());
        //else if (GreenTile.GetComponent<ImageTargetBehaviour>()) FindSingleTile(greenTiles);


        // StartCoroutine(SplineCreator());

        // Double cards via keyboard
        //else if (Input.GetKeyDown(KeyCode.V)) FindDoubleTile(redTiles);
        //else if (Input.GetKeyDown(KeyCode.C)) FindDoubleTile(purpleTiles);
        //else if (Input.GetKeyDown(KeyCode.P)) FindDoubleTile(yellowTiles);
        //else if (Input.GetKeyDown(KeyCode.O)) FindDoubleTile(blueTiles);
        //else if (Input.GetKeyDown(KeyCode.I)) FindDoubleTile(orangeTiles);
        //else if (Input.GetKeyDown(KeyCode.U)) FindDoubleTile(greenTiles);
    }

    // -------------------------------------------------------------
    // SPECIAL TILE LOGIC
    // -------------------------------------------------------------
    void HandleSpecialTiles()
    {
        // Win
        if (currentTracker2 == winTile)
            Debug.Log("WIN");

        // Licorice (lose turn)
        if (!locked && !lockedLastTurn && System.Array.Exists(licoriceTiles, x => x == currentTracker2))
        {
            locked = true;
            lockedLastTurn = true;
        }

        // Bridges
        if (currentTracker2 == bridgeStart1)
            ApplyBridge(bridgeStart1, bridgeEnd1);

        if (currentTracker2 == bridgeStart2)
            ApplyBridge(bridgeStart2, bridgeEnd2);
    }

    public void CharacterCard()
    {
        destination = gingerbreadMan;

    }

    // -------------------------------------------------------------
    // HELPER METHODS
    // -------------------------------------------------------------
    void AddSplinePoint(int index)
    {
        if (index < 0 || index >= boardTiles.Length) return;

        Vector3 pos = boardTiles[index].transform.position;
        splineContainer.Spline.Add(new Vector3(pos.x, pos.y, pos.z));
    }

    // Single tile: go to the next tile of that color
    public void FindSingleTile(int[] tiles)
    {
        Debug.Log(tiles);
        foreach (int tile in tiles)
        {
            if (tile > currentTracker)
            {
                destination = tile;
                return;
            }
        }
    }

    // Double tile: go to the second next tile of that color
   public void FindDoubleTile(int[] tiles)
    {
        bool foundFirst = false; bool foundSecond = false; foreach (int tile in tiles)
        {
            if (tile > currentTracker)
            {
                if (!foundFirst)
                {
                    foundFirst = true; // skip first
                }
                else if(!foundSecond) 
                {
                    foundSecond = true;
                    destination = tile; // second tile return;
                }
                else
                {

                }
            }
        }
    }

    public void Gingerbreadman()
    {
        destination = gingerbreadMan;
    }
    public void CandyCane()
    {
        destination = candyCane;
    }
    public void Gumdrop()
    {
        destination = gumdrop;
    }
    public void PeaNut()
    {
        destination = peanut;
    }
    public void LolliPop()
    {
        destination = lollipop;
    }
    public void IceCream()
    {
        destination = iceCream;
    }

    void ApplyBridge(int start, int end)
    {
        AddSplinePoint(start);
        AddSplinePoint(end);

        currentTracker = end;
        currentTracker2 = end;
        currentTile = end;
    }

    private IEnumerator StartplayermoveandSpline()
    {

        if (destination >= 0 && destination < boardTiles.Length)
        {
            for (int i = currentTile; i <= destination; i++) AddSplinePoint(i);
        }

        SplineAnimate activePlayer = GameManager.Instance.GetSplineAnimate();

        activePlayer.Restart(true);

        yield return new WaitForSecondsRealtime(5);

        currentTracker = destination;
        currentTile = destination;
        currentTracker2 = destination;
        splineContainer.Spline.Clear();

    }
}