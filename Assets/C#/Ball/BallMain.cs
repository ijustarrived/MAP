using Assets.C_.Ball;
using Assets.C_.Ball.Models;
using Assets.C_.Ball.Services;
using Assets.C_.Ball.Services.FXs;
using Assets.C_.Game;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class BallMain : MonoBehaviour
{
    private Ball ball;

    private static List<AudioSource> audioSrcs;

    private static AudioSource musicSrc;

    private Text maxSpeedlbl,
        currentSpeedLbl;

    private FXs fxs;

    private static GameWrapper wrapper = null;

    private GameObject pausePan,
        //scrollPan,
        achiPan;

    // Use this for initialization
    void Awake ()
    {
        #region Initiations

        #region Ball

        ball = new Ball()
        {
            Body = GetComponent<Rigidbody2D>(),

            Force = new Force()
            {
                X = Force.LOWEST_FORCE,

                Y = Force.LOWEST_FORCE,

                MaxSpeed = string.IsNullOrEmpty(FileManager.Read("MaxSpeed")) ? 9 
                : System.Convert.ToInt32(FileManager.Read("MaxSpeed"))
            }
        }; 

        ball.Body.AddForce(new Vector2(ball.Force.X, ball.Force.Y));

        #endregion

        #region FXs

        audioSrcs = new List<AudioSource>(GetComponents<AudioSource>());

        musicSrc = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();

        fxs = new FXs();

        fxs.FxDic.Add(audioSrcs.ElementAt((int)FXs.Clips.FLAME1).clip, audioSrcs.ElementAt((int)FXs.Clips.FLAME1));

        fxs.FxDic.Add(audioSrcs.ElementAt((int)FXs.Clips.FLAME2).clip, audioSrcs.ElementAt((int)FXs.Clips.FLAME2));

        fxs.FxDic.Add(audioSrcs.ElementAt((int)FXs.Clips.FLAME3).clip, audioSrcs.ElementAt((int)FXs.Clips.FLAME3));

        fxs.FxDic.Add(audioSrcs.ElementAt((int)FXs.Clips.FLAME4).clip, audioSrcs.ElementAt((int)FXs.Clips.FLAME4));

        fxs.FxDic.Add(audioSrcs.ElementAt((int)FXs.Clips.FLAME5).clip, audioSrcs.ElementAt((int)FXs.Clips.FLAME5));

        fxs.FxDic.Add(audioSrcs.ElementAt((int)FXs.Clips.BALL).clip, audioSrcs.ElementAt((int)FXs.Clips.BALL)); 

        #endregion

        //This is how you call other game objects 
        maxSpeedlbl = GameObject.Find("/Canvas/MaxSpeedLbl").GetComponent<Text>();

        maxSpeedlbl.text = string.Format("Max Speed \n {0} mph", ball.Force.MaxSpeed);

        currentSpeedLbl = GameObject.Find("/Canvas/CurrentSpeedLbl").GetComponent<Text>();

        #region Set references for menus

        //When they become invs they aren't accesable so made this to get a reference before they become inaccesable
        pausePan = GameObject.Find("/PauseCanvas/PausePan");

        pausePan.SetActive(false);

        achiPan = GameObject.Find("/AchiCanvas/AchiPan");

        achiPan.SetActive(false);

        //scrollPan = GameObject.Find("/AchiCanvas/AchiPan/ScrollListPan");

        //scrollPan.SetActive(false);

        #endregion

        #endregion
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (MainMenuCanvas.GetWrapper().HasStarted)
        {
            //Initialize here cause I want evrything up to date
            if(wrapper == null)
                wrapper = MainMenuCanvas.GetWrapper();

            OnBackBtnPressed();

            //Convert m/s to mph
            ball.Force.MPH = (int)(ball.Body.velocity.magnitude * Force.MPH_MULTIPLIER);

            #region Play flame fx according to what speed it's going and set it's reached flag

            switch (ball.Force.MPH)
            {
                case Force.SPEED1:

                    if (!ball.Force.ReachedSpeed1)
                    {
                        if(wrapper.IsSoundOn)
                            fxs.FxDic.ElementAt((int)FXs.Clips.FLAME1).Value.PlayOneShot(fxs.FxDic.ElementAt((int)FXs.Clips.FLAME1).Key);

                        ball.Force.ReachedSpeed1 = true;
                    }

                    else
                    {
                        if (ball.PreviousVelocityFrame < Force.SPEED1)
                            ball.Force.ReachedSpeed1 = false;
                    }

                    break;

                case Force.SPEED2:

                    if (!ball.Force.ReachedSpeed2)
                    {
                        if (wrapper.IsSoundOn)
                            fxs.FxDic.ElementAt((int)FXs.Clips.FLAME2).Value.PlayOneShot(fxs.FxDic.ElementAt((int)FXs.Clips.FLAME2).Key);

                        ball.Force.ReachedSpeed2 = true;
                    }

                    else
                    {
                        if (ball.PreviousVelocityFrame < Force.SPEED2)
                            ball.Force.ReachedSpeed2 = false;
                    }

                    break;

                case Force.SPEED3:

                    if (!ball.Force.ReachedSpeed3)
                    {
                        if (wrapper.IsSoundOn)
                            fxs.FxDic.ElementAt((int)FXs.Clips.FLAME3).Value.PlayOneShot(fxs.FxDic.ElementAt((int)FXs.Clips.FLAME4).Key);

                        ball.Force.ReachedSpeed3 = true;
                    }

                    else
                    {
                        if (ball.PreviousVelocityFrame < Force.SPEED3)
                            ball.Force.ReachedSpeed3 = false;
                    }

                    break;

                case Force.SPEED4:

                    if (!ball.Force.ReachedSpeed4)
                    {
                        if (wrapper.IsSoundOn)
                            fxs.FxDic.ElementAt((int)FXs.Clips.FLAME4).Value.PlayOneShot(fxs.FxDic.ElementAt((int)FXs.Clips.FLAME4).Key);

                        ball.Force.ReachedSpeed4 = true;
                    }

                    else
                    {
                        if (ball.PreviousVelocityFrame < Force.SPEED4)
                            ball.Force.ReachedSpeed4 = false;
                    }

                    break;

                case Force.SPEED5:

                    if (!ball.Force.ReachedSpeed5)
                    {
                        if (wrapper.IsSoundOn)
                            fxs.FxDic.ElementAt((int)FXs.Clips.FLAME5).Value.PlayOneShot(fxs.FxDic.ElementAt((int)FXs.Clips.FLAME5).Key);

                        ball.Force.ReachedSpeed5 = true;
                    }

                    else
                    {
                        if (ball.PreviousVelocityFrame < Force.SPEED5)
                            ball.Force.ReachedSpeed5 = false;
                    }

                    break;
            }

            #endregion

            if (ball.Force.MPH > ball.Force.MaxSpeed)
                ball.Force.MaxSpeed = ball.Force.MPH;

            ball.PreviousVelocityFrame = ball.Force.MPH;

            #region Check frame counter 

            //Increase counter so that velocity can stay constant for a longer period of time
            if (ball.FrameCount < Ball.FPS_COUNT_RESET)
                ball.FrameCount++;

            //Reset counter and lower speed
            else
            {
                ball.FrameCount = 0;

                if (ball.Force.MPH > Force.LOWEST_MPH)
                    ball.Body.velocity = Force.DecreaseVelocity(1, ball.Body);
            }

            #endregion

            maxSpeedlbl.text = string.Format("Max Speed \n {0} mph", ball.Force.MaxSpeed);

            currentSpeedLbl.text = string.Format("{0} mph", ball.Force.MPH);
        }
    }

    //Play ball bounce fx
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "LBound":

                if (wrapper.IsSoundOn || wrapper == null)
                    fxs.FxDic.ElementAt((int)FXs.Clips.BALL).Value.PlayOneShot(fxs.FxDic.ElementAt((int)FXs.Clips.BALL).Key, FXs.GetRandomVol());

                break;

            case "RBound":

                if (wrapper.IsSoundOn || wrapper == null)
                    fxs.FxDic.ElementAt((int)FXs.Clips.BALL).Value.PlayOneShot(fxs.FxDic.ElementAt((int)FXs.Clips.BALL).Key, FXs.GetRandomVol());

                break;

            case "UBound":

                if (wrapper.IsSoundOn || wrapper == null)
                    fxs.FxDic.ElementAt((int)FXs.Clips.BALL).Value.PlayOneShot(fxs.FxDic.ElementAt((int)FXs.Clips.BALL).Key, FXs.GetRandomVol());

                break;

            case "BBound":

                if (wrapper.IsSoundOn || wrapper == null)
                    fxs.FxDic.ElementAt((int)FXs.Clips.BALL).Value.PlayOneShot(fxs.FxDic.ElementAt((int)FXs.Clips.BALL).Key, FXs.GetRandomVol());

                break;
        }
    }

    private void OnMouseDown()
    {
        const int SPEED_INCREMENTOR = 1;

        ball.Body.velocity = Force.VelocityInverter(ball.Body, SPEED_INCREMENTOR);

        //Reset frame count
        ball.FrameCount = 0;
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
            FileManager.Write(ball.Force.MaxSpeed.ToString(), "MaxSpeed");
    }

    public static List<AudioSource> GetFXAudioSrcs()
    {
        return audioSrcs;
    }

    public static void SetFXAudioSrc(List<AudioSource> srcs)
    {
        audioSrcs = srcs;
    }

    public static AudioSource GetMusicAudioSrc()
    {
        return musicSrc;
    }

    public static void SetMusicAudioSrc(AudioSource src)
    {
        musicSrc = src;
    }

    public static GameWrapper GetGameWrapper()
    {
        return wrapper;
    }

    public static void SetGameWrapper(GameWrapper w)
    {
        wrapper = w;
    }

    /// <summary>
    /// Kill the app on back pressed
    /// </summary>
    private void OnBackBtnPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Open the pause menu
            PauseMenu.PauseClick(ball, pausePan, achiPan);
            //PauseMenu.PauseClick(ball, pausePan, achiPan, scrollPan);
        }
    }

}
