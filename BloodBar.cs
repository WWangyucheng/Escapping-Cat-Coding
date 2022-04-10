using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBar : MonoBehaviour
{
    public Transform Cameratransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Cameratransform.position.x, 0, 0);
    }
}
