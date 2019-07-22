using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    public enum PowerType
    {
        Fly, Jump, Climbing, Running
    }

    public PowerType powerType;

    private void OnTriggerEnter(Collider other)
    {
            if (other.GetComponent<AbilityManager>() != null)
            {
            switch (powerType)
            {
                case PowerType.Fly:
                    other.GetComponent<AbilityManager>().canFly = true;
                    break;
                case PowerType.Jump:
                    other.GetComponent<AbilityManager>().canJump = true;
                    break;
                case PowerType.Running:
                    other.GetComponent<AbilityManager>().canRun = true;
                    break;
            }

            //destroy self
            Destroy(gameObject);
            }
    }
}
