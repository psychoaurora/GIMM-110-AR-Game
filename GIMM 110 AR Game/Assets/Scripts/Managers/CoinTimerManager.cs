using UnityEngine;
using System.Collections;

public class CoinTimerManager : MonoBehaviour
{

    public void DeactivateAndActivate(GameObject target, float inactiveTime)
    {
        StartCoroutine(deactivationPeriod(target, inactiveTime));
    }
    IEnumerator deactivationPeriod(GameObject target, float inactiveTime)
    {
        target.SetActive(false);
        yield return new WaitForSeconds(3f);
        target.SetActive(true);
    }
    //This code is from CoPilot after many failed attempts at figuring out CoRoutines
}
