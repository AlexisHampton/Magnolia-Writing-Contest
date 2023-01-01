using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : Singleton<DialogueManager>
{
    [Header("Dialogue")]
    public DialogueSO beginningDialogue;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] bubbleSortDialogue;
    public string[] endDayDialogue;
    public string[] writingDialogue;
    public string[] parentGoToDialogue;

    [Header("Choices")]
    public GameObject choicePanel;
    public TextMeshProUGUI[] choiceButtons = new TextMeshProUGUI[2];

    DialogueSO currentDialogue;
    int index = 0;
    int activity;
    bool furnitureDialogue;
    bool single;
    bool canGO = true;
    Furniture furniture;

    public delegate void ChoiceAction(int i);
    public static event ChoiceAction OnChoice;

    public delegate void ProofAction(bool f);
    public static event ProofAction OnProof;

    private void Start()
    {
        IsOn(false);
        furnitureDialogue = false;
        single = false;
        canGO = true;
    }

    public void IsOn(string message, Furniture f)
    {
        IsOn(true);
        furnitureDialogue = true;
        furniture = f;
        LoadDialogue(message);
    }

    public void IsOn(string message)
    {
        IsOn(true);
        single = true;
        LoadDialogue(message);
    }
    public void IsOn(DialogueSO d)
    {
        currentDialogue = d;
        IsOn(true);
        LoadDialogue();
    }

    public void IsOn(bool isOn)
    {
        OnProof(!isOn);
        canGO = !isOn;
        single = false;
        furnitureDialogue = false;
        dialoguePanel.SetActive(isOn);
        choicePanel.SetActive(false);
        ResetDM();
    }

    void ResetDM()
    {
        index = 0;
        dialogueText.text = " ";
    }

    void LoadDialogue(string message)
    {
        dialogueText.text = message;
    }

    void LoadDialogue()
    {
        Debug.Log("index " + index + ":length " + currentDialogue.dialogue.Length);
        if (index < currentDialogue.dialogue.Length)
        {
            dialogueText.text = currentDialogue.dialogue[index];
        }
        else
        {
            if (currentDialogue.hasChoices)
            {
                for (int i = 0; i < currentDialogue.choices.Length; i++)
                    choiceButtons[i].text = currentDialogue.choices[i].choiceBlurb;
                choicePanel.SetActive(true);
            }
            else
                IsOn(false);
        }
    }

    public void Choose(int choiceIndex)
    {
        int activityNum = currentDialogue.choices[choiceIndex].activity;
        if (activityNum != 0)
        {
            activity = activityNum;
            if (activityNum == 1) IsOn(Text(bubbleSortDialogue));
            if (activityNum == 2) IsOn(Text(endDayDialogue));
            if (activityNum == 3) IsOn(Text(writingDialogue));
        }
        else
        {
            currentDialogue = currentDialogue.choices[choiceIndex].nextDialogue;
            ResetDM();
            LoadDialogue();
            choicePanel.SetActive(false);
        }

    }

    private string Text(string[] dialogue)
    {
        int rand = Random.Range(0, dialogue.Length - 1);
        return dialogue[rand];

    }

    public void Continue()
    {
        Debug.Log("cheese");
        index++;
        if (furnitureDialogue)
        {
            furnitureDialogue = false;
            IsOn(false);
            furniture.PassTime();
        }
        else if(single)
        {
            OnChoice(activity);
            IsOn(false);
        }
        else
            LoadDialogue();
    }

    public void ParentText()
    {
        canGO = true;
        IsOn(Text(parentGoToDialogue));
        Computer.Instance.TurnOffNotif();
    }

    public void StartGame()
    {
        IsOn(beginningDialogue);
    }
}
