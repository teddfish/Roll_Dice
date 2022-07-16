using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidMoveDetection : MonoBehaviour
{
    [SerializeField] int offset = 1;


    public void CheckMove(Vector3 direction)
    {
        Vector3 move = transform.position + (direction * offset);
        transform.position = move;

    }

}
