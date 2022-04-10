using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyCar : MonoBehaviour
{
    [SerializeField]

    Rigidbody2D rb;

    public GameObject Enermycar;

    

    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<Rigidbody2D>();
        
    }



    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-7, 0);
        


    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        

        if (coll.gameObject.tag == "stoptrigger")
        {
            Debug.Log("stop");
            

            Rigidbody2D rigidbody = transform.GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            rigidbody.constraints = RigidbodyConstraints2D.None;

        }
      
        
    }
    
}


       
    