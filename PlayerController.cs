using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour


{
    
    public float moveSpeed;
    public float jumpForce;
    //public float seftDestructionHeight = -0.01f;
    
    [SerializeField]

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    PolygonCollider2D pc;
    public LayerMask whatIsGround;
    public GameObject DeathEffect;
    public GameObject Enermycar;
    public GameObject Bottom;
    public GameObject BloodBar5;
    public GameObject BloodBar4;
    public GameObject BloodBar3;
    public GameObject BloodBar2;
    public GameObject BloodBar1;
    public GameObject BloodBar0;
    public GameObject speedup;
    public GameObject food;
    public Transform playerRevivePos;
   

    

    public int blood=5;
    public float SpeedUp=1;
    private bool isGround;
    private Rigidbody2D myRigidbody2D;
    


    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
        pc = GetComponentInChildren<PolygonCollider2D>();




        BloodBar5.GetComponent<SpriteRenderer>().enabled = true;
        BloodBar4.GetComponent<SpriteRenderer>().enabled = false;
        BloodBar3.GetComponent<SpriteRenderer>().enabled = false;
        BloodBar2.GetComponent<SpriteRenderer>().enabled = false;
        BloodBar1.GetComponent<SpriteRenderer>().enabled = false;
        BloodBar0.GetComponent<SpriteRenderer>().enabled = false;
        speedup .GetComponent<SpriteRenderer>().enabled = false;

    }
   
    // Update is called once per frame
    void Update()
    {
        //moving
        float h = Input.GetAxisRaw("Horizontal");
        { 
            rb.velocity = new Vector2(SpeedUp *h * moveSpeed, rb.velocity.y);
        }

       

        //face direction
        if (h != 0)
        {
            transform.localScale = new Vector3(5 * h, 5, 5);
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y <= -1f)//IsGround()//transform.position.y<=0.4f
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //animation
        anim.SetFloat("catmoving", Mathf.Abs(h));
        anim.SetBool("isGround",transform .position .y<=-0.8f);


       
       
    }

   

    public void Revive()
    {

        rb.velocity = Vector2.zero;
        sr.enabled = true;
    }
    

    bool IsGround()
        {
        
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2.5f, Vector2.down, 2.5f, whatIsGround);
            return hit;
       
        }
   

    //hit game objects 

    IEnumerator OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == "enermycar" )
        {
            Debug.Log("crash");

            GameObject dfx = Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(dfx, 1f);
            Debug.Log("player is destroyed");
           
            PlayerDamage();
            //Reborn();
        }
        if (coll.gameObject.tag == "Bottom")
        {
            Debug.Log("fall into water");

            GameObject dfx = Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(dfx, 1f);
            Debug.Log("player is destroyed");
            
            PlayerDamage();
            //Reborn();
        }
        if (coll.gameObject.tag == "fish")
        {
            Debug.Log("speed up");
            //food.GetComponentInChildren<SpriteRenderer>().enabled = false;
            //Destroy(fish);
            SpeedUp = SpeedUp + 0.15f;
            speedup.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(1.5f);
            speedup.GetComponent<SpriteRenderer>().enabled = false;

        }
       
    }

    //blood

    public void PlayerDamage()
    {
        blood--;

        if (blood == 4)
        {
            Debug.Log("4 blood left");
            BloodBar4.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (blood == 3)
        {
            Debug.Log("3 blood left");
            BloodBar3.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (blood == 2)
        {
            Debug.Log("2 blood left");
            BloodBar2.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (blood == 1)
        {
            Debug.Log("1 blood left");
            BloodBar1.GetComponent<SpriteRenderer>().enabled = true;
        }
        
        if (blood <= 0)
        {
            Debug.Log("dead");
            BloodBar0.GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            StartCoroutine(PlayerRevive());
        }

    }
    IEnumerator PlayerRevive()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponentInChildren<SpriteRenderer>().enabled = true;
        FindObjectOfType<PlayerController>().transform.position = playerRevivePos.position;
        FindObjectOfType<PlayerController>().Revive();
        blood = 5;
    }


}

