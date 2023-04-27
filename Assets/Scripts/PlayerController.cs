using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10;
    public static float vertical, horizontal;
    
    void Update()
    {
        horizontal = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(vertical, 0, 0);
        vertical = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, horizontal);
    }
}
