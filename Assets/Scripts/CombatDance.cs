using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().IncreaseDanceCounter();
        }
    }
}
