using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject MainMenuCam;
    public GameObject GamePlayCam;
    void Awake()
    {
        MainMenuCam.SetActive(true);
        GamePlayCam.SetActive(false);
    }
    public void ChangeCamPlay()
    {
        MainMenuCam.SetActive(false);
        GamePlayCam.SetActive(true);
    }
    public void ChangeCamMenu()
    {
        MainMenuCam.SetActive(true);
        GamePlayCam.SetActive(false);
    }

}
