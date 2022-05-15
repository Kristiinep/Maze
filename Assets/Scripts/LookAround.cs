using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Camera playerCamera;
    private float mouseSensitivity;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = 100f;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        player.transform.Rotate(0.0f, mouseX, 0.0f);
        //player.Rotate(Vector3.up * mouseX);
    }
}
