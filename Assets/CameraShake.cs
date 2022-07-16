using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] AnimationCurve shakeCurve;
    [SerializeField] float shakeMultiplier = 5f;
    [SerializeField] float shakeSpeed = 0.1f;

    private float shakeTimer;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 offsetPosition;

    void Start()
    {
        shakeTimer = 1;
        initialPosition = this.transform.position;
        initialRotation = this.transform.rotation;
    }

    void Update()
    {
        shakeTimer = shakeTimer + Time.deltaTime * shakeSpeed;
        shakeTimer = Mathf.Min(shakeTimer, 1);

        var offset = shakeMultiplier * shakeCurve.Evaluate(shakeTimer) * offsetPosition;
        this.transform.position = initialPosition + offset;

        Debug.Log(shakeTimer);
    }

    public void StartShake(Vector3 direction)
    {
        shakeTimer = 0;
        offsetPosition = direction;
    }
}
