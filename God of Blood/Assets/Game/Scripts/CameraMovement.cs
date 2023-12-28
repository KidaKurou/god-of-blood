using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _movementTime;
    [SerializeField] private Vector3 _zoomAmount;

    private Vector3 _position;
    private Vector3 _zoom;

    private void Awake()
    {
        _position = transform.position;
        _zoom = transform.localScale;
        
    }

    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _position += transform.forward * _movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _position += transform.forward * -_movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _position += transform.right * _movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _position += transform.right * -_movementSpeed;
        }

        float mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw == 0.1f)
        {
            _zoom += _zoomAmount;
        }
        if (mw == -0.1f)
        {
            _zoom -= _zoomAmount;
        }

        transform.position = Vector3.Lerp(transform.position, _position, _movementSpeed * Time.deltaTime);
        _cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition, _zoom, _movementTime * Time.deltaTime);
    }
}
