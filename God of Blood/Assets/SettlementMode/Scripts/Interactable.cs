using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public Text pressF;
    public SwitchCam switchCam;
    private bool isPlayerNear;
    private GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerNear)
        {
            if (this.name == "Headquarters")
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene(this.name);
            }
            if (this.name == "Warriors")
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                switchCam.SwitchCameras(1);
                player.transform.parent.gameObject.SetActive(false);
            }   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //pressF.enabled = true;
            pressF.gameObject.SetActive(true);
            isPlayerNear = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //pressF.enabled = false;
        pressF.gameObject.SetActive(false);
        isPlayerNear = false;
        player = null;
    }
}
