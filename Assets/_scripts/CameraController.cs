using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [Range(5, 15)]
    public float playerCameraDistance = 10f;
    [Range(1, 5)]
    public int maxZoom = 5;
    [Range(15, 25)]
    public int minZoom = 20;
    [Range(2.5f,2.5f)]
    public float zoonFactor = 2.5f;
    public Transform cameraTarget;

    private float fieldOfView;

    Camera playerCamera;
    float zoomSpeed = 25f;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();
        fieldOfView = playerCamera.fieldOfView;
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            fieldOfView -= scroll * zoomSpeed;
            if(fieldOfView > minZoom * zoonFactor)
            {
                fieldOfView = minZoom * zoonFactor;
            }
            if(fieldOfView < maxZoom * zoonFactor)
            {
                fieldOfView = maxZoom * zoonFactor;
            }
            playerCamera.fieldOfView = fieldOfView;
        }

        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y + playerCameraDistance, cameraTarget.position.z + playerCameraDistance);
    }
}
