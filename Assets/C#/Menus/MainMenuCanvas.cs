using Assets.C_.Game;
using Assets.C_.Game.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    //public static bool hasStarted = false;

    private static GameWrapper gw = new GameWrapper();

    private Animatron anim,
        lblAnim;

    private int frameCount;

    private GameObject MainMenuPanel;

    private Image img;

    private Text lbl;

    private void Awake()
    {
         MainMenuPanel = GameObject.Find("/MainMenuCanvas/MainMenuPanel");

        lbl = GameObject.Find("/MainMenuCanvas/MainMenuPanel/Title3Lbl").GetComponent<Text>();

         img = MainMenuPanel.GetComponent<Image>();

        anim = new Animatron();

        lblAnim = new Animatron()
        {
            InitialAlpha = 1f,

            Red = lbl.color.r,

            Green = lbl.color.g,

            Blue = lbl.color.b
        };
    }

    private void Update()
    {
        if (anim.AnimationEnded && !anim.AnimationRunning)
        {
            if (!gw.HasStarted)
            {
                gw.HasStarted = true;

                MainMenuPanel.SetActive(false);
            }
        }

        else if(!anim.AnimationEnded && anim.AnimationRunning)
        {
            img.color = anim.FadeOutObject(frameCount++, img.color);

            lbl.color = lblAnim.FadeOutObject(frameCount, lbl.color, 0.100f);
        }

        //When mouse pressed animation is flag as running. On every loop check if animation has ended
        //If ended don't render panel 
        if (Input.GetMouseButtonDown(0))
        {
            if (!anim.AnimationRunning)
            {
                anim.Start();

                lblAnim.Start();
            }
        }
    }

    public static GameWrapper GetWrapper()
    {
        return gw;
    }
}
