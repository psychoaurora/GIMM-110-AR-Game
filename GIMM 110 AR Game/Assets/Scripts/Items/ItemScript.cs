using UnityEngine;

public class ItemScript : MonoBehaviour
{
    /*If we want the coins to come back after a certain amount of time (like in the super simple platformer minigame),
     * then we add this line:
     * GameObject timermanager;
     */
    public ItemEffect itemEffect; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*Add this line:
         * timermanager = GameObject.Find("TimerManager")
         * if want coins to come back after a certain time
         */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Would need to add more code here (that Rose has) if want coins to come back after a time. 
        
        itemEffect.Apply(collision.gameObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
