using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject MainMenuCam;
    public GameObject GamePlayCam;
    public GameObject GamePlayUI;
    public GameObject MainMenuUI;
    void Awake()
    {
        MainMenuCam.SetActive(true);
        GamePlayCam.SetActive(false);
        GamePlayUI.SetActive(false);
        MainMenuUI.SetActive(true);

    }
    public void ChangeCam()
    {
        MainMenuCam.SetActive(false);
        GamePlayCam.SetActive(true);
        GamePlayUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

}
