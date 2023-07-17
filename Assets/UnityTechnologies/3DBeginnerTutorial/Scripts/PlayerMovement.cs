using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 이동을 담당
public class PlayerMovement : MonoBehaviour
{
    public float speed = 30.0f;
    public float turnSpeed = 20.0f;

    public Vector3 movement;
    Quaternion rotation = Quaternion.identity;

    Animator anim;
    Rigidbody rb;

    AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        movement.Set(horizontal, 0f, vertical);
        movement = movement.normalized * speed * Time.deltaTime;

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        anim.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
            audioSource.Stop();

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + movement * anim.deltaPosition.magnitude);
        rb.MoveRotation(rotation);
    }
}