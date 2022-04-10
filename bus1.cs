using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bus1 : MonoBehaviour
{

    public GameObject thisbus;
    Rigidbody2D rb;
    Animator anim;

    public Transform end;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        anim.Play("bus");
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        thisbus .transform.position += new Vector3(0.2f, 0, 0);


    }
}

