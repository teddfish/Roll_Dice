using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    public enum ConditionType
    {
        Win,
        Nothing,
        Teleport,
        RotateAround,
        ToggleTiles,
        ReverseRotation,
    }

    public bool tileTouched;

    [SerializeField]
    FxSpawner fx;

    public ConditionType[] faceConditions;

    private void OnTriggerEnter(Collider other) 
    {        
        if(other.transform.GetComponentInParent<CC>() != null)
        {
            tileTouched = true;
        } 

    }
}
