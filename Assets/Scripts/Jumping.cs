using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private bool isGrounded;

    /// <summary>
    /// Персонаж находится на земле
    /// <summary>
    void OnCollisionEnter() 
    {
        isGrounded = true;
    }

    /// <summary>
    /// Производим проверку, если персонаж находится на земле, то он может использовать прыжок
    /// <summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            isGrounded = false;
            GetComponent<Rigidbody>().AddForce (new Vector3(0, 500, 0));
        }
    }
}
