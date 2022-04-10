using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woman : MonoBehaviour
{
    public Transform  thiswoman;
    public Transform start;
    public Transform  end;
    public int speed;
    
    Animator anim;
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
     
        anim.Play("womanwalking");

    }
    void Update()
    {
        
    }

    IEnumerator OnTriggerStay2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "start")
        {
            transform.localScale = new Vector2(5, 5);
            thiswoman.transform.position = Vector2.MoveTowards(thiswoman.transform.position, end.transform.position, speed * Time.deltaTime);
            anim.Play("womanwalking");
            if (thiswoman.transform.position == end.transform.position)
            {
                anim.Play("womanstanding");
                yield return new WaitForSeconds(5);
                anim.Play("womanwalking");
                thiswoman.transform.position = Vector2.MoveTowards(thiswoman .transform.position, start.transform.position, speed * Time.deltaTime);
                transform.localScale = new Vector2(-5, 5);
            }


        }
        if (coll.gameObject.tag == "end")
        {
            transform.localScale = new Vector2(-5, 5);
            thiswoman.transform.position = Vector2.MoveTowards(thiswoman .transform.position, start.transform.position, speed * Time.deltaTime);
            anim.Play("womanwalking");
            if (thiswoman.transform.position == start.transform.position)
            {
                anim.Play("womanstanidng");
                yield return new WaitForSeconds(5);
                anim.Play("womanwalking");
                thiswoman.transform.position = Vector2.MoveTowards(thiswoman .transform.position, end.transform .position, speed * Time.deltaTime);
                transform.localScale = new Vector2(5, 5);

            }


        }
        else
        {
            thiswoman.transform.position = Vector2.MoveTowards(thiswoman.transform.position, end.transform.position, speed * Time.deltaTime);
        }
    }
}
    

