using System;
using GameManagerSystem;
using GamevrestUtils;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

public class VideoHandle : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    
    private void Start()
    {
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"Video.mp4");
        videoPlayer.Play();
        videoPlayer.loopPointReached += VideoFinished;
    }

    private void VideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("GameMain");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("GameMain");
    }
}