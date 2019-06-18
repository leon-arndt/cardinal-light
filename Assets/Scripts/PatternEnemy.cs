using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternEnemy : MonoBehaviour
{
    public float m_speed = 5f;
    public Vector3 m_moveVector;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //0 and 5
        transform.position = new Vector3(
            startPosition.x + Mathf.PingPong(Time.time * m_speed, m_moveVector.x),
            startPosition.y + Mathf.PingPong(Time.time * m_speed, m_moveVector.y),
            startPosition.z + Mathf.PingPong(Time.time * m_speed, m_moveVector.z)
            );
    }
}
