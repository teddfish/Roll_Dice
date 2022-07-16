using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidMoveDetection : MonoBehaviour
{
    [SerializeField] int offset = 1;
    GameObject[] tc;
    void Start()
    {
        tc = GameObject.FindGameObjectsWithTag("Checkers");

    }


    public void CheckMove(Vector3 direction)
    {
        Vector3 move = transform.position + (direction * offset);
        transform.position = move;

        // for (int i = 0; i < tc.Length; i++)
        // {
        //     tc[i].GetComponent<TileCheck>().DrawRayCheckTiles();
        // }
        //print("working");

    }

}
