using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private bool m_chasingPlayer;

    private float m_triggerDistance = 25f;
    private float m_moveSpeed = 2f;
    private float m_health = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = PlayerController.Instance.transform.position;

        if (!m_chasingPlayer)
        {
            if (Vector3.SqrMagnitude(playerPos - transform.position) < m_triggerDistance)
            {
                m_chasingPlayer = true;
            }
        }
        else
        {
            //chase the player
            transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * m_moveSpeed);
        }
	}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.GetComponent<PlayerController>() != null)
        {
            collision.transform.GetComponent<PlayerController>().TakeDamage(10f * Time.deltaTime);
        }
    }

    public void Damage(float damageToInflict)
    {
        m_health -= damageToInflict;
        if (m_health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
