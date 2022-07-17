using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    public enum ConditionType
    {
        Win,
        Nothing,
        RotateAround,
        Teleport,
        ToggleTiles,
        ReverseRotation,
    }

    public bool tileTouched;

    [SerializeField]
    public FxSpawner fx;

    public ConditionType[] faceConditions;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponentInParent<CC>() != null)
        {
            tileTouched = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponentInParent<CC>() != null)
        {
            tileTouched = false;
        }
    }
}
