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

    public float timeScale;
    
    void Start()
    {
        dayTimer = targetLight.intensity;
    }
 
    void Update()
    {
        if (!isCycle)
        {
            targetLight.intensity = dayTimer -= Time.deltaTime * timeScale;
            if(dayTimer <= 0)
            {
                isCycle = true;
            }
        }
        else if(isCycle)
        {
            targetLight.intensity = dayTimer += Time.deltaTime * timeScale;

            if (dayTimer >= 1.5f)
            {
                isCycle = false;
            }
        }

        ChangeCycle();
    }


    void ChangeCycle()
    {
        if(dayTimer >= 0.125f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[0];
        }
        else if (dayTimer >= 0.1f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[1];
        }
        else if (dayTimer >= 0.75f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[2];
        }
        else if (dayTimer >= 0.5f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[3];
        }
        else if (dayTimer >= 0.25f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[4];
        }
        else if (dayTimer >= 0f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[5];
        }
    }
}
