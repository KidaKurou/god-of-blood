using UnityEngine;
using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject _UIName;
    public Transform cam;
    public Transform endPoint;
    public Transform startPointCam;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            StartCoroutine(MoveCamCoroutine());
            Debug.Log($"Show {_UIName}");
        }
    }

    IEnumerator MoveCamCoroutine()
    {
        cam.DOMove(endPoint.position, 1f);
        Tween myTween = cam.DORotate(new Vector3(endPoint.eulerAngles.x, endPoint.eulerAngles.y, endPoint.eulerAngles.z), 1f);
        yield return myTween.WaitForCompletion();

        //Debug.Log("Tween completed!");
        _UIName.SetActive(true);
        _UIName.transform.parent.GetChild(0).gameObject.SetActive(false);
    }

    public void HideUI()
    {
        _UIName.SetActive(false);
        cam.DOMove(startPointCam.position, 1f);
        cam.DORotate(new Vector3(startPointCam.eulerAngles.x, startPointCam.eulerAngles.y, startPointCam.eulerAngles.z), 1f);
        _UIName.transform.parent.GetChild(0).gameObject.SetActive(true);
    }

    
}
