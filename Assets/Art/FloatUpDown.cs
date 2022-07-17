using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    [SerializeField] private float floatSpeedMin = 9.5f;
    [SerializeField] private float floatSpeedMax = 1f;
    [SerializeField] private float movementAmountMin = 0.1f;
    [SerializeField] private float movementAmountMax = 0.15f;

    private float[] randomFloatSpeed;
    private float[] randomMove;
    private float[] startingY;

    private Transform[] children;

    void Start()
    {
        var childTransforms = GetComponentsInChildren<Transform>();
        children = new Transform[childTransforms.Length - 1];
        randomFloatSpeed = new float[children.Length];
        randomMove = new float[children.Length];
        startingY = new float[children.Length];

        for (int i = 0; i < children.Length; i++)
        {
            children[i] = childTransforms[i + 1];
            randomFloatSpeed[i] = Random.Range(floatSpeedMin, floatSpeedMax);
            randomMove[i] = Random.Range(movementAmountMin, movementAmountMax);
            startingY[i] = this.transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < children.Length; i++)
        {
            var time = Time.timeSinceLevelLoad;
            var sine = Mathf.Sin(time * randomFloatSpeed[i]) * randomMove[i];

            var pos = children[i].position;
            pos.y = startingY[i] + sine;
            children[i].position = pos;
        }
    }
}

