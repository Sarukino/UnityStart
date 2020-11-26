using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _jumpforce = 300f;
    private bool CanJump;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    // Update is called once per frame
    private void Update()
    {
        if (CanJump ==false)
        {
            CanJump = Input.GetKeyDown(KeyCode.Space);
        }
    }

    private void FixedUppdate()
    {
        if(CanJump)
        {
            _rigidbody.AddForce(_jumpforce * Vector3.up);
        }
    }
}
