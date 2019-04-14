using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    public enum PowerType
    {
        Fly, Jump, Climbing
    }

    public PowerType powerType;

    private void OnTriggerEnter(Collider other)
    {
        if (powerType == PowerType.Fly)
        {
            if (other.GetComponent<AbilityManager>() != null)
            {
                other.GetComponent<AbilityManager>().canFly = true;
                Destroy(gameObject);
            }
        }

        if (powerType == PowerType.Jump)
        {
            if (other.GetComponent<AbilityManager>() != null)
            {
                other.GetComponent<AbilityManager>().canJump = true;
                other.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_JumpPower = 12f;
                Destroy(gameObject);
            }
        }

        if (powerType == PowerType.Climbing)
        {
            if (other.GetComponent<AbilityManager>() != null)
            {
                other.GetComponent<AbilityManager>().canClimb = true;
                Destroy(gameObject);
            }
        }
    }
}
