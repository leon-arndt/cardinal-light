using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    [SerializeField]
    Transform playerTransform;

    private Camera cam;
    public Vector3 offset; //0, 1.32, -1.41
    public float cameraSpeed;
    public float minDistance;
    public float hoverDistance;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        //position
        if (Vector3.Distance(transform.position, playerTransform.position) > minDistance)
        {
            //this factor makes sure that the lerp slows down as the camera gets closer to stopping completly
            float desiredTravelFactor = Mathf.Min(cameraSpeed, Vector3.Distance(transform.position, playerTransform.position) - minDistance);

            Vector3 desiredPos = playerTransform.position - hoverDistance * playerTransform.forward + offset;

            transform.position = Vector3.Lerp(transform.position, desiredPos, desiredTravelFactor * Time.deltaTime);
        }

        //orbit

        //rotation
        transform.LookAt(playerTransform.transform.position + hoverDistance * playerTransform.transform.forward);
    }
}
