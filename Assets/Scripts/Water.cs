using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Health recovered");
            other.transform.GetComponent<PlayerController>().RecoverHealth(10f * Time.deltaTime);
        }
    }
}
