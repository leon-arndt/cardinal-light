using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    Camera cam;
	
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

        //orbit rotation
        float horInput = Input.GetAxis("Mouse X");
        transform.Rotate(horInput * Vector3.up, Space.World);
    }
}
