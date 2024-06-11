using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueText;
    public UnityEvent triggerOnCollision;
    public UnityEvent triggerOnCollide;
    public UnityEvent onSceneEnter;
    private bool onSign;
    public KeyCode interact;
    private void Awake()
    {
        onSceneEnter.Invoke();
    }
    public void Update()
    {
        if (Input.GetKeyDown(interact))
        {
            TriggerDialogue();
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        onSign = true;
    }

    public void OnTriggerExit(Collider other)
    {
        onSign = false;
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueText);
    }
}
