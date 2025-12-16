using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class TimerManager : MonoBehaviour 
{


    public void StartSceneTimer(float SceneTimeLength, IMinigameState currentState) 
    {
        StartCoroutine(SceneTime(SceneTimeLength, currentState));

    }

    IEnumerator SceneTime(float SceneTimeLength, IMinigameState currentState)
    {
        yield return new WaitForSeconds(SceneTimeLength);

        //Calling the exit method here in whatever scene. Probably add another parameter in StartSceneTimer()
        Debug.Log("Scene Time Ended");
        MinigameStateMachine.Instance.StopMinigameTimer();
    }

    public void DeactivateAndActivate(GameObject target, float delay)
    {
        StartCoroutine(DeactivateAndActivateCoroutine(target, delay));
    }

    private IEnumerator DeactivateAndActivateCoroutine(GameObject target, float delay)
    {
        target.SetActive(false);
        yield return new WaitForSeconds(delay);
        target.SetActive(true);
    }
}
