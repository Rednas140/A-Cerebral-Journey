using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{
    public float TimeDelay;
    private Animator animator;

    private readonly float waitTime = 2.0f;
    private float timer = 0.0f;
    private Canvas interactPrompt;
    private bool closeToNpc;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        interactPrompt = gameObject.transform.GetChild(0).GetComponent<Canvas>(); ;
        interactPrompt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            animator.Play("idle_npc", -1, 0f);

            // Remove the recorded 2 seconds.
            timer = timer - waitTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && closeToNpc) 
        {
            if (PlayerLevel.MaxLevel >= PlayerLevel.CurrentLevel) 
            {
                PlayerLevel.CurrentLevel++;
                PlayerScript.speed = PlayerScript.speed + 2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactPrompt.enabled = true;
            closeToNpc = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactPrompt.enabled = false;
            closeToNpc = false;
        }
    }
}

