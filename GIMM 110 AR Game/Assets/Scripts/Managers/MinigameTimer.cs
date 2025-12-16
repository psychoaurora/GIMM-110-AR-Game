using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameTimer : MonoBehaviour
{
    float timeRemaining;
    bool running;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void StartTimer(float duration)
    {
        timeRemaining = duration;
        running = true;
        Debug.Log("Timer started from MinigameTimer. duration:" + duration);
    }

    // Update is called once per frame
    void Update()
    {
        if (!running) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            running = false;
            EndMinigame();
        }
    }

    public void EndMinigame()
    {
        Debug.Log("Minigame ended, sent back to board scene");
        SceneManager.LoadScene("Board");
    }
}
