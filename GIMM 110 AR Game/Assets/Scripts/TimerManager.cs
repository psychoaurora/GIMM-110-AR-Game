using System.Collections;
using UnityEngine;

public class TimerManager : MonoBehaviour //Should this class be a child of the minigamestatemachine?
{
    //Remember to add the timer in here for the temporary coins in the one room minigame. 

    public void StartSceneTimer(float SceneTimeLength) /*With the State machine, on enter calls this method. 
                                                        * This parameter will be the minigameTime in the PlayerInfo class.
                                                        */ 
    {
        StartCoroutine(SceneTime(SceneTimeLength));

    }

    IEnumerator SceneTime(float SceneTimeLength)
    {
        //Probably need to add mroe here to switch between scenes, but this is it for now.
        yield return new WaitForSeconds(SceneTimeLength);
        //Calling the exit method here in whatever scene. Probably add another parameter in StartSceneTimer()
    }
}
