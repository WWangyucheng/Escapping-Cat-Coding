using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class bus : MonoBehaviour
{
    public GameObject   Bus;
    public GameObject Bus1;
    
    
    public int speed;
    Animator anim;
    Rigidbody2D rb;

    public Transform target;
    
    public Transform end;

  

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponentInChildren<Rigidbody2D>();
        Bus1.SetActive(false);
        anim.enabled = true ;



    }

    // Update is called once per frame

    void Update()
    {
       
        Bus.transform.position = Vector2.MoveTowards(Bus.transform.position, target.position, speed * Time.deltaTime);
        
        Debug.Log("stop car");

        Invoke(nameof(Restart), 13f);

    }

    public void Restart()
    {
        Bus.SetActive(false);
        Bus1.SetActive(true);
        Debug.Log( "restart car" );
        Bus1.transform.position = Vector2.MoveTowards(Bus1.transform.position, end.position, speed * Time.deltaTime);


    }

    }
