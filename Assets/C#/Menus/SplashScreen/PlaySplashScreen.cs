using Assets.C_.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlaySplashScreen : MonoBehaviour
{

    private VideoPlayer vidPlayer;

    private void Awake()
    {
        vidPlayer = GetComponent<VideoPlayer>();

        vidPlayer.loopPointReached += StopVid;
    }

    // Update is called once per frame
    void Update ()
    {
        //if (Input.GetMouseButton((int)GameWrapper.MouseButtons.Left))
        //{
        //    SceneManager.LoadScene((int)GameWrapper.Scenes.Main);
        //}
    }

    private void StopVid(VideoPlayer vPlayer)
    {
        SceneManager.LoadScene((int)GameWrapper.Scenes.Main);
    }
}
