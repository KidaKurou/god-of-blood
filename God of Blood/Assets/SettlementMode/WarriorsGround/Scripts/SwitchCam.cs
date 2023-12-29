using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public GameObject player;
    public GameObject freeLookCam;
    public GameObject warriorCam;
    public GameObject warriorHolder;


    public GameObject uiPlayer;
    public GameObject uiWarrior;

    public void SwitchCameras(int cam)
    {
        DeactivateAllCam();
        switch (cam)
        {
            case 0:
                warriorHolder.SetActive(false);
                uiPlayer.SetActive(true);
                freeLookCam.SetActive(true);
                player.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case 1:
                warriorHolder.SetActive(true);
                warriorCam.SetActive(true);
                uiWarrior.SetActive(true);
                break;
        }
    }

    private void DeactivateAllCam()
    {
        warriorHolder.SetActive(false);
        freeLookCam.SetActive(false);
        warriorCam.SetActive(false);
        uiPlayer.SetActive(false);
        uiWarrior.SetActive(false);
    }
}
