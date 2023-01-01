using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 6f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Mouse X");
        float moveVal = deltaX * speed * Time.deltaTime;
        Vector3 movement = new Vector3(0, Mathf.Clamp(moveVal, -6, 6), 0);
        Camera.main.transform.Rotate(movement);
    }

}
