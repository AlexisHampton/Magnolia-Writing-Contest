using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Collider[] objs;

    private void Awake()
    {
        DialogueManager.OnProof += BulletProof;
    }

    public void Begin()
    {
        
        DialogueManager.Instance.StartGame();

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void BulletProof(bool setactive)
    {
        foreach(Collider c in objs)
        {
            c.enabled = setactive;
        }
    }

}
