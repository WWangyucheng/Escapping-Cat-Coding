using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class womantrigger : MonoBehaviour
{
    public GameObject woman;


    // Start is called before the first frame update
    void Start()
    {

        woman.SetActive(false);
       

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("woman start");
            woman.SetActive(true);
            GetComponentInChildren<Collider2D>().enabled = false;
            

        }
    }
}