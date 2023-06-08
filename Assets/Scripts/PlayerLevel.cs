using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLevel : MonoBehaviour
{
    private int MaxLevel = 5;
    public int CurrentLevel = 0;
    private Light2D li;
    public float lightSize = 0.5;

    // Start is called before the first frame update
    void Start()
    {
        li = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        li.pointLightOuterRadius = lightSize;

        if (CurrentLevel <= MaxLevel) 
        {
            CurrentLevel++;
        }
    }
}
