using UnityEngine;

public class CarsonScript : MonoBehaviour
{
    public Transform Rotationlock;

    [SerializeField] float rotationlockx;
    [SerializeField] float rotationlocky;
    [SerializeField] float rotationlockz;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rotationlock = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotationlock.transform.rotation = new Quaternion(rotationlockx, rotationlocky, rotationlockz, 1);
    }
}
