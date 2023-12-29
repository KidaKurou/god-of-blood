using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 finalPos;
    private Vector3 initialPos;
    [SerializeField] private Vector3 initialRot;

    private void Awake()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPos, 0.1f);
        transform.rotation = Quaternion.Euler(initialRot);
    }

    private void OnDisable()
    {
        transform.position = initialPos;
    }
}
