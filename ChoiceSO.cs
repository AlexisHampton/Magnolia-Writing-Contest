using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Jung Hoseok", menuName ="Choices")]
public class ChoiceSO : ScriptableObject
{
    public string choiceBlurb;
    public int activity;
    public DialogueSO nextDialogue;
}
