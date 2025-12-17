using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class tilescript : MonoBehaviour
{
    public string color;
    public SplineGen SplineGen;

    public void DetectObject()
    {
        Debug.Log(color);
    }

    public void setTile()
    {
        Debug.Log("Image Detected");
        switch (color)
        {
            case "Blue":
                SplineGen.FindSingleTile(SplineGen.blueTiles);
                break;
            case "Red":
                SplineGen.FindSingleTile(SplineGen.redTiles);
                break;
            case "Green":
                SplineGen.FindSingleTile(SplineGen.greenTiles);
                break;
            case "Yellow":
                SplineGen.FindSingleTile(SplineGen.yellowTiles);
                break;
            case "Orange":
                SplineGen.FindSingleTile(SplineGen.orangeTiles);
                break;
            case "Purple":
                SplineGen.FindSingleTile(SplineGen.purpleTiles);
                break;
            case "DoubleBlue":
                SplineGen.FindDoubleTile(SplineGen.blueTiles);
                break;
            case "DoubleRed":
                SplineGen.FindDoubleTile(SplineGen.redTiles);
                break;
            case "DoubleGreen":
                SplineGen.FindDoubleTile(SplineGen.greenTiles);
                break;
            case "DoubleYellow":
                SplineGen.FindDoubleTile(SplineGen.yellowTiles);
                break;
            case "DoubleOrange":
                SplineGen.FindDoubleTile(SplineGen.orangeTiles);
                break;
            case "DoublePurple":
                SplineGen.FindDoubleTile(SplineGen.purpleTiles);
                break;
            case "gingerbreadMan":
                SplineGen.Gingerbreadman();
                break;
            case "CandyCane":
                SplineGen.CandyCane();
                break;
            case "gumdrop":
                SplineGen.Gumdrop();
                break;
            case "peanut":
                SplineGen.PeaNut();
                break;
            case "lollipop":
                SplineGen.LolliPop();
                break;
            case "iceCream":
                SplineGen.IceCream();
                break;
        }
    }
}

