using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool m_pacified;
    private bool m_chasingPlayer;
    private bool m_followingPlayer;

    private float m_triggerDistance = 25f;
    private float m_moveSpeed = 2f;
    private float m_health = 100f;
    private uint m_danceCounter = 0;
    private uint m_danceAppetite = 3;
    private uint m_followerID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = PlayerController.Instance.transform.position;

        if (!m_followingPlayer)
        {
            //consider chasing the player
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
        else
        {
            //follow the player's followers or the player
            Vector3 targetPos;
            if (m_followerID > 1)
            {
                //follow pacified enemy
                targetPos = PlayerController.Instance.followers[(int)m_followerID-2].position;
            }
            else
            {
                //follow player
                targetPos = playerPos;
            }

            //step towards target
            if (Vector3.Distance(transform.position, targetPos) > 2f)
            {
                float step = m_moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            }
        }
	}

    //hurt the player
    private void OnCollisionStay(Collision collision)
    {
        if (!m_pacified)
        {
            if (collision.transform.GetComponent<PlayerController>() != null)
            {
                collision.transform.GetComponent<PlayerController>().TakeDamage(10f * Time.deltaTime);
            }
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

    public void IncreaseDanceCounter()
    {
        m_danceCounter++;
        if (m_danceCounter > m_danceAppetite)
        {
            if (!m_pacified)
            {
                Pacify();
            }
        }
    }

    private void Pacify()
    {
        m_pacified = true;
        m_followingPlayer = true;
        m_chasingPlayer = false;
        PlayerController.Instance.followers.Add(transform);
        m_followerID = (uint)PlayerController.Instance.followers.Count;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
