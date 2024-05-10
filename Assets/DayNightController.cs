using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    public Light targetLight;
    public GameObject targetMainCamera;
    public Material[] skys;
    public float dayTimer;
    public bool isCycle;
    
    void Start()
    {
        dayTimer = targetLight.intensity;
    }
 
    void Update()
    {
        if (!isCycle)
        {
            targetLight.intensity = dayTimer -= Time.deltaTime * 0.3f;
            if(dayTimer <= 0)
            {
                isCycle = true;
            }
        }

            else if(isCycle)

        {
            targetLight.intensity = dayTimer += Time.deltaTime * 0.3f;

            if (dayTimer >= 1)
            {
                isCycle = false;
            }
        }

        ChangeCycle();
    }


    void ChangeCycle()
    {
        if(dayTimer >= 0.9f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[0];
        }
    }
}
