using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            GameController.Instance.StopMission();
        }
    }
}
