using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class TextMessage : Singleton<TextMessage>
{

    [Header("Message Basics")]
    public GameObject phonePanel;
    public TextMeshProUGUI nameText;
    public RectTransform startBubble;

    [Header("Message Intricacies")]
    public GameObject personPanel;
    public GameObject leftP;
    public GameObject rightP;
    public RectTransform leftOffset;
    public RectTransform rightOffset;
    public RectTransform bubbleParent;
    //scroll will be the parent

    ObstacleEventSO obstacle;
    RectTransform lastBubble;
    int index = 0;
    int bubbles = 0;

    public void AddText()
    {
        //add message to the person panel
        /*
         * add with offset first
         * read in from dialogue, starting dialogue has name, start with the dialogue 
         * then hand over to dialogue so
         * instantiate a bubble prefab
         * on choice--> bubble prefab is the right,
         * everything else is the left
         * so it feeds into the left dialogue after instantiate. 
         * Instantiate(left, new V2(prev.x, prev.y + offset --> 103, parent);
         * have to get it's text comp 
         * GetComponentInChildren<TMP>.text = "";
         */
        //set first one
       // startBubble.GetComponentInChildren<TextMeshProUGUI>().text = obstacle.dialogueSO.dialogue[0];
        //instantiate the next
    }

    /*void ReadDialogue()
    {
        if(index < obstacle.dialogueSO.dialogue.Length)
        {
            MakeBubble(leftP, leftOffset);

        }
        else
        {
            if(obstacle.dialogueSO.hasChoices)
            {
                MakeBubble(rightP, rightOffset);
                ReadDialogue();
            }
        }
    }

    void MakeBubble(GameObject b, RectTransform offset)
    {
        bubbles++;
        float newY = offset.localPosition.y + lastBubble.localPosition.y;
        Vector3 newPos = new Vector3(offset.localPosition.x, newY, offset.localPosition.z);
        GameObject bubble = Instantiate(b, newPos, Quaternion.identity);
        bubble.transform.SetParent(bubbleParent, false);
        //bubble.GetComponentInChildren<TextMeshProUGUI>().text = obstacle.dialogueSO.dialogue[index];
    }*/
}

