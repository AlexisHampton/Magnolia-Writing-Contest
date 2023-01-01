using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType { PARENT, MESSAGE}

[CreateAssetMenu(fileName = "Kim Namjoon", menuName = "Obstacle")]
public class ObstacleEventSO : ScriptableObject
{
    // public DialogueSO dialogueSO;
    public string[] dialogue;
    public ObstacleType obstacleType;
}
