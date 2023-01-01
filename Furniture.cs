using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    public string[] dialogue;
    public int hoursTaken;

    public MeshRenderer mesh;
    public Material tempMat;

    Material mat;

    private void Start()
    {
        mat = mesh.material;
    }
    private void OnMouseOver()
    {
        mesh.material = tempMat;
    }
    private void OnMouseExit()
    {
        mesh.material = mat;
    }

    private void OnMouseDown()
    {
        int index = Random.Range(0, dialogue.Length-1);
        DialogueManager.Instance.IsOn(dialogue[index], this);
    }

    public void PassTime()
    {
        Clock.Instance.PassTime(hoursTaken);
    }
}
