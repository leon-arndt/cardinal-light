﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    public static FollowCam Instance;

    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    Camera cam;

    private float horInputAdjustFactor = 0.63f;
    private float horInputWarmth = 0f;
    private float normalFov;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        normalFov = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update () {
        //position on player
        transform.position = playerTransform.position;

        //lerp behind player
        //if (Vector3.Distance(transform.position, playerTransform.position) > minDistance)
        //{
        //    //this factor makes sure that the lerp slows down as the camera gets closer to stopping completly
        //    float desiredTravelFactor = Mathf.Min(cameraSpeed, Vector3.Distance(transform.position, playerTransform.position) - minDistance);
        //
        //    Vector3 desiredPos = playerTransform.position - hoverDistance * playerTransform.forward + offset;
        //
        //    transform.position = Vector3.Lerp(transform.position, desiredPos, desiredTravelFactor * Time.deltaTime);
        //}

        //rotate camera slowly when the player walks sideways
        float horInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horInput) > 0.1f)
        {
            horInputWarmth = Mathf.Min(1, horInputWarmth + Time.deltaTime);
        }
        else
        {
            horInputWarmth = Mathf.Max(0, horInputWarmth - Time.deltaTime);
        }

        if (horInputWarmth > 0.9f)
        {
            transform.Rotate(horInputAdjustFactor * horInput * Vector3.up, Space.World);
        }

        //orbit rotation
        float mouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(mouseXInput * Vector3.up, Space.World);

        //pitch rotation
        float mouseYInput = Input.GetAxis("Mouse Y");
        float desiredYRot = transform.rotation.x + mouseYInput;
            transform.Rotate(mouseYInput * Vector3.right, Space.Self);
        //desiredYRot = Mathf.Clamp(desiredYRot, 0, 60);
        //transform.rotation = Quaternion.Euler(new Vector3(desiredYRot, transform.rotation.y, transform.rotation.z));
    }

    public void UpdateFieldOfView(float playerSpeed)
    {
        float desiredFov = normalFov + playerSpeed;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, desiredFov, Time.deltaTime);
    }
}
