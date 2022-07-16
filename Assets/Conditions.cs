using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    CC cc;
    int face;

    public bool tileTouched;

    [SerializeField]
    FxSpawner fx;

    public int win;
    [SerializeField] int nothing;
    [SerializeField] int doubleMove;
    [SerializeField] int reverseMovementRotation;
    [SerializeField] int toggleTiles;
    [SerializeField] int teleport;

    void Start()
    {
        cc = GameObject.Find("Cube").GetComponent<CC>();
    }

    // Update is called once per frame
    void Update()
    {
        face = cc.currentFace;
        //print(face);

        // if (face == win)
        // {
        //     print("trigger win screen");
        //     fx.SpawnWinFx(this.transform.position);
        // }
        // else if (face == nothing) 
        // {
        //     print("do nothing");
        // }
        // else if (face == doubleMove)
        // {
        //     print("use the move code twice");
        // }
        // else if (face == reverseMovementRotation)
        // {
        //     print("change movement rotation");
        // }
        // else if (face == toggleTiles)
        // {
        //     print("switch off white tiles");
        // }
        // else if (face == teleport)
        // {
        //     print("initiate teleport");
        // }
    }

    // private void OnCollisionEnter(Collision other) 
    // {
   
    // }
    private void OnTriggerEnter(Collider other) 
    {        
        if(other.transform.GetComponentInParent<CC>() != null)
        {
            tileTouched = true;
            // int current = other.transform.GetComponentInParent<CC>().currentFace;
            // print("detected");
            // print(current);
            // if (current == win)
            // {
            //     print("win");
            // }

        } 

    }
}
