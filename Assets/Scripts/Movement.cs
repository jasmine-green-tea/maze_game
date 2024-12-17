using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    float speed = 11f;

    Vector2 horizontalInput;

    public void ReceiveInput(Vector2 input)
    {
        horizontalInput = input;
    }

    private void Update()
    {
        Vector3 horizontalVelocity = (Vector3.right * horizontalInput.x + Vector3.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);
    }
}
