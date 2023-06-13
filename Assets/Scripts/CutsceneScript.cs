using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{
    private Canvas cutscene;
    public bool showCutscene;

    // Start is called before the first frame update
    void Start()
    {
        cutscene = gameObject.transform.GetChild(0).GetComponent<Canvas>(); ;
        cutscene.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (showCutscene)
        {
            cutscene.enabled = true;
        }

        if (!showCutscene)
        {
            cutscene.enabled = false;
        }
    }
}
