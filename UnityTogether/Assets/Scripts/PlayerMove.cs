using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{

    public float moveSpeed;
    private int count;
    private Rigidbody Rb;
    public bool hasAkey;
    public GameObject Key;
    public GameObject Gate;
    public Text countText;
    public Text WinText;
    private bool isOpen;
    private float gatemoving;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        SetCountText();
        count = 0;
        Rb = GetComponent<Rigidbody>();
        moveSpeed = 10f;
        Key.gameObject.SetActive(false);
        WinText.text = "";
        hasAkey = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

        }
        else if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            hasAkey = true;
        }
        if (hasAkey)
        {
            if (other.gameObject.CompareTag("Gate"))
            {
               
                //other.gameObject.SetActive(false);
                isOpen = true;

            }
        }
    }
    void SetCountText()
    {
        countText.text = "Count " + count.ToString();
        if (count == 6)
        {
            Key.gameObject.SetActive(true);
        }
        if (count == 10)
        {
            WinText.text = "YOU WIN!";
        }
    }
    void Update()
    {
        if (isOpen)
        {
            if (gatemoving <= 1)
            {
                Gate.gameObject.transform.Translate(new Vector3(0, 5, 0) * Time.deltaTime);
                gatemoving += Time.deltaTime;
            }

        }
    }


    void FixedUpdate()
    {
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        transform.Rotate(0f, 120 * Input.GetAxis("Horizontal") * Time.deltaTime, 0f);
        if (Input.GetAxis("Vertical") > -0.1)
        {
            transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        }
        else
        {
            transform.Translate(0f, 0f, (moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime)/2);
        }


    }
}