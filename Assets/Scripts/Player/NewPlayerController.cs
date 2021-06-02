using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//オンライン適応前のPlayer操作用
[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(MobAttack))]
public class NewPlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    public float speed;
    //public int attack;
    private Rigidbody rb;
    private Animator ani;
    private Vector3 PlayerPos;
    float x = 0f;
    float z = 0f;
    
    //
    [SerializeField] private GameObject attackdetector;

    //private PlayerStatus _status;
    private MobAttack _attack;

    [SerializeField] private float rotateAngle = 45f;
    [SerializeField] private float rotateSpeed = 12.5f;
    private Quaternion rotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        PlayerPos = GetComponent<Transform>().position;

        playerStatus = GetComponent<PlayerStatus>();
        speed = playerStatus.speed;
        //attack = playerStatus.attack;

        //_status = GetComponent<PlayerStatus>();
        _attack = GetComponent<MobAttack>();

        rotation = transform.rotation;
    }

    private void Update()
    {
        speed = playerStatus.speed;

        x = Input.GetAxis("Horizontal") * speed;
        z = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector3(x, 0, z);
        Vector3 direction = new Vector3(x, 0, z);

        Vector3 diff = transform.position - PlayerPos;
        if (diff.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
        PlayerPos = transform.position;

        if (speed > 0.1f && x != 0)
        {
            ani.SetFloat("Speed", speed);
        }
        else if (speed >0.1f && z != 0)
        {
            ani.SetFloat("Speed", speed);
        }
        else
        {
            ani.SetFloat("Speed", 0f);
        }

        if (Input.GetMouseButton(0))
        {
            attackdetector.SetActive(true);
            _attack.AttackIfPossible();
        }

    }

    private void FixedUpdate()
    {
        rotation = Quaternion.Euler(0f, transform.eulerAngles.y + Input.GetAxis("Horizontal") * rotateAngle, 0f); 
        rb.velocity = new Vector3(x, 0, z);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

    }

}
