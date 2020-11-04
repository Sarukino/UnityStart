using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed;
    private int count;
    private Rigidbody Rb;

    // Use this for initialization
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        moveSpeed = 10f;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;

        }
    }


    void FixedUpdate()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}