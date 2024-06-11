using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TMP_Text dialogueText;
    public TMPro.TMP_Text characterName;
    public Image icon;
    public Image dialogueBox;
    public KeyCode dialogueContinue;
    public KeyCode dialogueSkip;
    public bool dialogueOpen = false;
    public GameObject dialogue;
    public bool isCreepy;
    public bool hasPause;
    
    public UnityEvent endDialogue;
    
    //public Animator dialogueAnimator;

    private Queue<DialoguePiece> conversation;
   
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(dialogueContinue) == true)
        {
            DisplayNextSentence();
        }
        if (Input.GetKeyDown(dialogueSkip) == true)
        {
            this.EndDialogue();
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        dialogueOpen = true;
        Time.timeScale = 0; 
        conversation = new Queue<DialoguePiece>();
        foreach (DialoguePiece DP in dialogue.conversation)
        {
            conversation.Enqueue(DP);
        }
        DisplayNextSentence();
        
    }

    public void DisplayNextSentence ()
    {
        if (conversation.Count == 0)
        {
            if (isCreepy == true)
            {
                //FindObjectOfType<SoundManager>().BringSoundBack();
            }
            EndDialogue();
            return;
        }
        if (conversation.Count == 2 && isCreepy == true)
        {
            //FindObjectOfType<SoundManager>().CutSound();
        }
        DialoguePiece thisDialogue = conversation.Dequeue();
        characterName.text = thisDialogue.name;
        string sentence = thisDialogue.sentence;
        icon.sprite = thisDialogue.icon;
        dialogueBox.sprite = thisDialogue.dialogueBox;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        if (hasPause == true)
        {
            //PauseMenu.dialogueBoxes.Remove(dialogue);
        }
        Time.timeScale = 1;
        dialogueOpen = false;
        endDialogue.Invoke();
    }
}
