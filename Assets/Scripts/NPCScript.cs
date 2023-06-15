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
    private Canvas dialoguePrompt;
    private bool closeToNpc;
    private bool talkedTo = false;
    private int idleAnimation;
    public bool areTalking;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        interactPrompt = gameObject.transform.GetChild(0).GetComponent<Canvas>();
        dialoguePrompt = gameObject.transform.GetChild(2).GetComponent<Canvas>();
        interactPrompt.enabled = false;
        dialoguePrompt.enabled = false;
        idleAnimation = Animator.StringToHash("idle_npc");
    }

    // Update is called once per frame
    void Update()
    {
        areTalking = Dialogue.isTalking;

        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            animator.Play(idleAnimation, -1, 0f);

            // Remove the recorded 2 seconds.
            timer -= waitTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && closeToNpc && !areTalking) 
        {
            if (PlayerLevel.MaxLevel >= PlayerLevel.CurrentLevel) 
            {
                dialoguePrompt.enabled = true;
                gameObject.transform.GetChild(2).GetChild(0).GetComponent<Dialogue>().StartDialogue();
                interactPrompt.enabled = false;
                talkedTo = true;

                if (!talkedTo)
                {
                    PlayerLevel.CurrentLevel++;
                    PlayerScript.speed += 2f;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && closeToNpc) 
        {
            interactPrompt.enabled = true;
            dialoguePrompt.enabled = false;
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
            dialoguePrompt.enabled = false;
        }
    }
}

