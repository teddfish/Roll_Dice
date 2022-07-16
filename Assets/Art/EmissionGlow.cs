using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionGlow : MonoBehaviour
{
    [SerializeField] private Material glowMaterial;
    [SerializeField] private float glowSpeed = 1f;
    [SerializeField] private Color glowMax;
    [SerializeField] private Color glowMin;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.timeSinceLevelLoad;
        var sine = (Mathf.Sin(time * glowSpeed) + 1) / 2;
        var col = Color.Lerp(glowMin, glowMax, sine);

        glowMaterial.SetColor("_EmissionColor", col);
    }
}
