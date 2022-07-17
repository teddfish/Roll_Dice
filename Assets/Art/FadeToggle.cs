using UnityEngine;
using System;

public class FadeToggle : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] float fadeSpeed = 1;
    private MeshRenderer mesh;

    private float opacity;
    // Start is called before the first frame update
    void Start()
    {
        mesh = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int conditionSign = Convert.ToInt32(boxCollider.enabled) * 2 - 1;
        AdjustOpacity(Time.deltaTime * fadeSpeed * conditionSign);
    }

    void AdjustOpacity(float amount)
    {
        opacity = opacity + amount;
        opacity = Mathf.Clamp(opacity, 0, 1);
        foreach (var mat in mesh.materials)
        {
            var col = mat.color;
            col = new Color(col.r, col.g, col.b, opacity);
            mat.color = col;
        }
    }
}
