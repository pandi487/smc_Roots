using GameManagerSystem;
using GamevrestUtils;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

public class VideoHandle : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public SceneReference game;
    private void Start()
    {
        videoPlayer.loopPointReached += VideoFinished;
    }

    private void VideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("GameMain");
    }
}