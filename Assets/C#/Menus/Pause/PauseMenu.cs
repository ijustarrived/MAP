using Assets.C_.Ball.Models;
using Assets.C_.Ball.Services;
using Assets.C_.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static Ball _ball; //Used to get the max speed once app is killed

    private static Button musicBtn,
    soundBtn;

    private static GameWrapper wrapper;

    private static GameObject pausePan,
        //scrollPan,
        achiPan;

    public void ResumeClick()
    {
        //Resume time
        Time.timeScale = 1f;

        pausePan.SetActive(false);
    }

    /// <summary>
    /// This is the only way to call this class so it works like a constructor
    /// </summary>
    /// <param name="ball"></param>
    /// <param name="pausePanObj"></param>
    //public static void PauseClick(Ball ball, GameObject pausePanObj, GameObject achiPanObj, GameObject scrollPanObj)
    public static void PauseClick(Ball ball, GameObject pausePanObj, GameObject achiPanObj)
    {
        _ball = ball;

        wrapper = BallMain.GetGameWrapper();

        pausePan = pausePanObj;

        musicBtn = pausePan.GetComponentsInChildren<Button>()[1];

        soundBtn = pausePan.GetComponentsInChildren<Button>()[2];

        //Pause time
        Time.timeScale = 0f;

        pausePan.SetActive(true);

        achiPan = achiPanObj;
    }

    /// <summary>
    /// Very similar to musicclick but with sound. This cause it won't play or stop cause fx play once
    /// </summary>
    public void SoundClick()
    {
        wrapper.IsSoundOn = !wrapper.IsSoundOn;

        Text txt = soundBtn.GetComponentInChildren<Text>();

        if(wrapper.IsSoundOn)
        {
            if (txt.text.Contains("Off"))
                txt.text = txt.text.Replace("Off", "On");
        }

        else
        {
            if (txt.text.Contains("On"))
                txt.text = txt.text.Replace("On", "Off");
        }

        BallMain.SetGameWrapper(wrapper);

    }

    /// <summary>
    /// Get Audio src for music, play it according to flag and set text according to play flag
    /// </summary>
    public void MusicClick()
    {
        wrapper.isMusicOn = !wrapper.isMusicOn;

        AudioSource src = BallMain.GetMusicAudioSrc();

        Text txt = musicBtn.GetComponentInChildren<Text>();

        if (wrapper.isMusicOn)
        {
            if (!src.isPlaying)
            {
                if (txt.text.Contains("Off"))
                    txt.text = txt.text.Replace("Off", "On");

                src.Play();
            }
        }

        else
        {
            if (txt.text.Contains("On"))
                txt.text = txt.text.Replace("On", "Off");

            src.Pause();
        }

        BallMain.SetGameWrapper(wrapper);
    }

    /// <summary>
    /// Kills the app
    /// </summary>
    public void QuitClick()
    {
        FileManager.Write(_ball.Force.MaxSpeed.ToString(), "MaxSpeed");

        Application.Quit();
    }

    public void AchiClick()
    {
        pausePan.SetActive(false);

        achiPan.SetActive(true);

        //scrollPan.SetActive(true);

        AchiPan.LoadList(pausePan, achiPan);

        //AchiPan.LoadList(pausePan, achiPan, scrollPan);
    }
}
