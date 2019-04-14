using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController Instance;
    private float timeLeft;

    private void Start()
    {
        Instance = this;
    }

    public void StartMission()
    {
        timeLeft = 10f;
    }

    public void StopMission()
    {
        timeLeft = -1f;
    }

    private void Update()
    {
       if (timeLeft > 0)
       {
           timeLeft -= Time.deltaTime;
           UIController.Instance.timeText.text = "Time Left: " + Mathf.Round(timeLeft).ToString();
       } 
    }
}
