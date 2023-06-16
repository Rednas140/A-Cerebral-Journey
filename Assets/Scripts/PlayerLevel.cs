using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLevel : MonoBehaviour
{
    public static int MaxLevel = 4;
    public static int CurrentLevel = 1;
    private Light2D li;
    public int lightSize = 2;

    // Start is called before the first frame update
    void Start()
    {
        li = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        li.pointLightOuterRadius = CurrentLevel * lightSize;
    }
}
