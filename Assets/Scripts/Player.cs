using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool canFly;
    public bool canClimb;
    public bool canJump;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (canFly)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                rb.AddForce(20f * Vector3.up);
            }
        }
	}
}
