using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    [SerializeField] float rollSpeed = 5;
    [SerializeField] float offset = 0.5f;
    bool rolling;


    void Update()
    {
        if (rolling)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Vector3.back);
        }

        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.5f))
        {

            Debug.Log(hit.transform.gameObject.name);

        }

    }

    public void Move(Vector3 direction)
    {
        Vector3 rollEdge = transform.position + (direction + Vector3.down) * offset;
        Vector3 axis = Vector3.Cross(Vector3.up, direction);

        StartCoroutine(Roll(rollEdge, axis));
    }


    IEnumerator Roll(Vector3 rollEdge, Vector3 axis)
    {
        rolling = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(rollEdge, axis, rollSpeed);

            yield return new WaitForSeconds(0.01f);
        }

        rolling = false;
    }
}
