using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public GameObject colliderAttack;

    float horizontal;
    float vertical;

    Vector3 movement;

    Rigidbody rb;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        Animating();
        Attack();

        /*transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);*/

        //transform.Translate(movement * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);
        movement.Normalize();
    }
    void Move()
    {
        rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    }

    void Animating()
    {
        if(horizontal !=0 || vertical != 0)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0) && horizontal == 0 && vertical == 0)
        {
            anim.SetTrigger("Attack");
        }

        if(colliderAttack )
    }

    public void EnableColliderAttack()
    {
        colliderAttack.SetActive(true);
        Invoke("DisableCollider", 0.2f);
    }

    void DisableCollider()
    {
        colliderAttack.SetActive(false);
    }

}
