using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //  gameObject.GetComponent<Renderer>().material.SetVector("_ObjectSource", new Vector3(500,0,500));
        
    }

    bool envHealthy = false;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.SetVector("_ObjectSource", new Vector4(500,500,500));


        if (Input.GetKeyDown(KeyCode.P))
        {

            if (envHealthy)
            {
                Shader.SetGlobalFloat("_levelstate", 0);
                envHealthy = false;
            }
            else
            {
                Shader.SetGlobalFloat("_levelstate", 1);
                envHealthy = true;
            }

        }
    }
}
