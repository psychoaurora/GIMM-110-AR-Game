using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroVideo : MonoBehaviour
{

    public VideoPlayer VideoPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VideoPlayer.loopPointReached += OnVideoEnd;
    }

    // Update is called once per frame
    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video ended with OnVideoEnd");
        SceneManager.LoadScene("Board");
    }
}
