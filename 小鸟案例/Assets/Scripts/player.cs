using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public float upforce = 100;
    public float downforce = 4;
    public float slowforce = 100;

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
        isShift = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetMouseButtonDown(0))
        {
            if (isShift)
            {
                rigidbody2D.velocity = Vector2.zero;
                rigidbody2D.AddForce(new Vector2(0, slowforce), ForceMode2D.Force);
            }
            else
            {
                rigidbody2D.velocity = Vector2.zero;
                rigidbody2D.AddForce(new Vector2(0, upforce), ForceMode2D.Force);
            }
            
            
        }
         if (Input.GetMouseButtonDown(1))
        {
            Flydown();
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(new Vector2(0, -downforce), ForceMode2D.Force);
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
      
        this.death = true;
        if (OnDeth!=null)
        {
            OnDeth();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
      
        if (scoreAction!=null)
        
            scoreAction(1);
        
    }
    

}
