using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Computer : Singleton<Computer>
{
    public GameObject computerPanel;

    [Header("Writing")]
    [TextArea(10, 15)] public string writing;
    public TextMeshProUGUI writingText;
    public DialogueSO[] computerDialogue;

    string[] lines;
    int index;

    public TextMeshProUGUI topText;

    [Header("Obstacles")]
    public GameObject notifPanel;
    public TextMeshProUGUI notfiNameText;

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
    //scroll will be the parent

    GameObject lastBubble;
    ObstacleEventSO obstacleEvent;
    int person;
    int offset = 128;
    // Start is called before the first frame update
    void Start()
    {
        lines = UnpackWriting();
        index = 0;
        person = 0;
        computerPanel.SetActive(false);
        mat = mesh.material;
    }

    string[] UnpackWriting()
    {
        return writing.Split(';');
    }

    public void WriteMore()
    {
        writingText.text += lines[index++];
        Points.Instance.IncreaseProgress();
    }

    public void NewNotification(ObstacleEventSO obstacle)
    {
        notifPanel.SetActive(true);
        nameText.text = obstacle.dialogue[Random.Range(0, obstacle.dialogue.Length - 1)];
        HandleObstacle();
    }

    public void HandleObstacle()
    {
        switch(obstacleEvent.obstacleType)
        {
            case ObstacleType.PARENT:
                DialogueManager.Instance.ParentText();
                break;
            case ObstacleType.MESSAGE:
                nameText.text = obstacleEvent.name;
                phonePanel.SetActive(true);
                break;
        }
    }

    public void UpdateUI(string buttonName)
    {
        topText.text = buttonName;
    }

    private void OnMouseDown()
    {
        if(index < computerDialogue.Length)
         DialogueManager.Instance.IsOn(computerDialogue[index]);
    }

    public void TurnOn()
    {
        computerPanel.SetActive(true);
    }

    public IEnumerator TurnOffNotif()
    {
        yield return new WaitForSeconds(2f);
        notifPanel.SetActive(false);
        StopAllCoroutines();
    }

    public void FinishWriting()
    {
        Calender.Instance.NextDay();
    }

    public MeshRenderer mesh;
    public Material tempMat;

    Material mat;

    private void OnMouseOver()
    {
        mesh.material = tempMat;
    }
    private void OnMouseExit()
    {
        mesh.material = mat;
    }
}
