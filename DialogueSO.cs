using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Min Yoongi", menuName ="Dialogue")]
public class DialogueSO : ScriptableObject
{
    public string[] dialogue;
    public bool hasChoices = false;
    public ChoiceSO[] choices = new ChoiceSO[2];
}
