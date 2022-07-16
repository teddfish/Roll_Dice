using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    CC cc;
    int face;

    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.Find("Cube").GetComponent<CC>();
    }

    // Update is called once per frame
    void Update()
    {
        face = cc.currentFace;
    }

    private void OnCollisionEnter(Collision other) 
    {
   
    }
    private void OnTriggerEnter(Collider other) 
    {        
        if(other.transform.CompareTag("One"))
        {
            print("win");
        } 
        
    }
}
