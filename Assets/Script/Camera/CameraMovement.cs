using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public Player player;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hp > 0)
        {
            transform.position -= new Vector3(0, cameraSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.SetPositionAndRotation(initialPosition, transform.rotation);
        }
    }
}
