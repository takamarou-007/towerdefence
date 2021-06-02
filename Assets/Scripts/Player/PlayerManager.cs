using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MLAPI.NetworkedBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Animator animator;
    private Vector3 PlayerPosition;
    float x = 0f;
    float z = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        PlayerPosition = GetComponent<Transform>().position;
    }

  
    void Update()
    {
        if (this.IsOwner)
        {
            x = Input.GetAxis("Horizontal") * speed;
            z = Input.GetAxis("Vertical") * speed;
            rb.velocity = new Vector3(x, 0, z);
            Vector3 direction = new Vector3(x, 0, z);

            Vector3 diff = transform.position - PlayerPosition;
            if (diff.magnitude > 0.1f)
            {
                transform.rotation = Quaternion.LookRotation(diff);
            }
            PlayerPosition = transform.position;

            //修正が必要 キーボードの問題
            if (speed > 0.1f && x != 0)
            {
                animator.SetFloat("Speed", speed);
            }
            else if (speed > 0.1f && z != 0)
            {
                animator.SetFloat("Speed", speed);
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }

            if (transform.position.y < -5)
            {
                SceneManager.LoadScene("SampleScene");
                Destroy(this.gameObject);
            }
        }
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(x, 0, z);
        
    }

}
