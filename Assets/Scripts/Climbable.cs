using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : MonoBehaviour {

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision.gameObject.GetComponent<Player>().canClimb)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(20f * Vector3.up);
            }
        }
    }
}
