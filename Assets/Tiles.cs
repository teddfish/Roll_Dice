using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("running");
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.transform.tag == "One")
        {
            Debug.Log("One");
        }
        else if (other.transform.tag == "Two")
        {
            Debug.Log("Two");
        }
        else if (other.transform.tag == "Three")
        {
            Debug.Log("Three");
        }
        else if (other.transform.tag == "Four")
        {
            Debug.Log("Four");
        }
        else if (other.transform.tag == "Five")
        {
            Debug.Log("Five");
        }
        else
        {
            Debug.Log("Six");
        }
    }
}
