using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public float speed = 5;
    public GameObject zidan;
    public float fireRate = 10;

 
    private Animator animator;
    public bool death = false;
    public delegate void deathNotify();
    public event deathNotify OnDeth;
    private Vector3 initps;
    public UnityAction<int> scoreAction;
    private bool isShift;
   

    void Start()
    {

        initps = transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Ldie();



    }

    // Update is called once per frame
    void Update()
    {
        if (this.death)
            return;
        Vector2 pos = this.transform.position;
        pos.x += Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        pos.y += Input.GetAxis("Vertical")*Time.deltaTime*speed;
        this.transform.position = pos;

        fireTimer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
          
            Fire();

        }
    }
    float fireTimer = 0;
   
    private void Fire()
    {
        if (fireTimer > 1 / fireRate)
        {
            GameObject zd = Instantiate(zidan);
            zd.transform.position = this.transform.position;
            fireTimer = 0f;
        }
        

    }
    public void Init()
    {
        transform.position = initps;
        Ldie();
        death = false;
    }
    public void Ldie()
    {
        rigidbody2D.Sleep();
        rigidbody2D.simulated=false;
        animator.SetTrigger("ldie");
    }
    public void Fly()
    {
        rigidbody2D.WakeUp();

        rigidbody2D.simulated=true;

        animator.SetTrigger("fly");

    }
    public void Flydown()
    {
        animator.SetTrigger("flydown");
    }

    private void Die()
    {
        this.death = true;
        if (OnDeth != null)
        {
            OnDeth();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        //Die();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "scoreArea")
        {

        }
        // else
       //  Die();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
      
        if (scoreAction!=null)
        
            scoreAction(1);
        
    }
    

}
