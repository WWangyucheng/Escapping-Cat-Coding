using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour

{
    public GameObject enermycar;
    

    // Start is called before the first frame update
    void Start()
    {
       
        enermycar.SetActive(false);
       
       
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("taxi start");
            enermycar.SetActive(true);
            GetComponentInChildren<Collider2D>().enabled = false;
            
          
        }
    }
    

        

    }

    
/*
    IEnumerator loopcar()
    {
        while (GetComponentInChildren<Collider2D>().enabled == false)
        {
            yield return new WaitForSeconds(1.5f);
            GetComponentInChildren<Collider2D>().enabled = true;
        }

    }
*/

