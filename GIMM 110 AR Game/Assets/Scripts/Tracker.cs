using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Tracker : MonoBehaviour
{  


    // private int tiletracker;
    public int GambleResult = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            GambleResult = UnityEngine.Random.Range(1, 6);
            if (GambleResult == 1)
            {
                Debug.Log("result 1");
                GambleResult = 0;
            }
            if (GambleResult == 2)
            {
                Debug.Log("result 2");
                GambleResult = 0;
            }
            if (GambleResult == 3)
            {
                Debug.Log("result 3");
                GambleResult = 0;
            }
            if (GambleResult == 4)
            {
                Debug.Log("result 4");
                GambleResult = 0;
            }
            if (GambleResult == 5)
            {
                Debug.Log("result 5");
                GambleResult = 0;
            }
            if (GambleResult == 6)
            {
                Debug.Log("result 6");
                GambleResult = 0;
            }
            //Mover.specialtilecard = tiletracker -1;
            //  SplineGen.tileSnumber = tiletracker - 1;
        }
       
    }
    
}
