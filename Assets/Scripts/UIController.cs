using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {
    public Text timeText;
    public static UIController Instance;

    private void Awake()
    {
        Instance = this;
    }
}
