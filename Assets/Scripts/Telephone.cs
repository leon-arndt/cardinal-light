using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// used to start missions
/// </summary>
public class Telephone : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            GameController.Instance.StartMission();
        }
    }
}
