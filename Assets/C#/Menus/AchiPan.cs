using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AchiPan : MonoBehaviour
{
    private static GameObject pausePan,
        //scrollPan,
        achiPan;

    //public static void LoadList(GameObject pausePanObj, GameObject achiPanObj, GameObject scrollPanObj)
    public static void LoadList(GameObject pausePanObj, GameObject achiPanObj)
    {
        achiPan = achiPanObj;

        pausePan = pausePanObj;

        //scrollPan = scrollPanObj;
    }

    public void BackClick()
    {
        achiPan.SetActive(false);

        pausePan.SetActive(true);

        //scrollPan.SetActive(false);
    }
}
