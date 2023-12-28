using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarCamRotate : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, transform.position.y + 180f, transform.position.z) + Camera.main.transform.position);
    }
}
