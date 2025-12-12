
using UnityEngine;
using UnityEngine.Splines;

public class Mover : MonoBehaviour
{
   // public static int TitleNumber;
   // public static int specialtilecard;
  //  private int specialtilecard2;
 // public GameObject[] Tiles;
 // public GameObject[] tileLoctation;
   private SplineAnimate SplineAnimate;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        SplineAnimate = GetComponent<SplineAnimate>();
    }

    // Update is called once per frame
    void Update()
    {

       // if (Input.GetKeyDown(KeyCode.W))
        //{
         //   SplineAnimate.Play();
       // }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SplineAnimate.Restart(true);
        }

       // if (Input.GetKeyDown(KeyCode.D))
        //{
         //   SplineAnimate.Restart(true);
       // }
        // specialtilecard2 = specialtilecard - 1;
        //  if (specialtilecard > 0)
        //    {    

        // transform.position = new Vector3(Tiles[specialtilecard2].transform.position.x, Tiles[specialtilecard2].transform.position.y, Tiles[specialtilecard2].transform.position.z);          
        //  }
    }
}
