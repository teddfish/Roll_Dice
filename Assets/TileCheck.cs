using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheck : MonoBehaviour
{
    public bool blockMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, 1f))
        {
            blockMove = true;
        }
        else {
            blockMove = false;
        }
        print(blockMove);
    }

    public void DrawRayCheckTiles()
    {
        // Ray ray = new Ray(this.transform.position, Vector3.down);
        // RaycastHit hit;
        // if (Physics.Raycast(ray, out hit, 1f))
        // {
        //     tileAvailable = true;
        // }
        // print(tileAvailable);
    }

    private void OnDrawGizmos() 
    {
        if (blockMove)
        {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down);
        }
        else if (!blockMove) {
            Gizmos.color = Color.green;        
            Gizmos.DrawRay(transform.position, Vector3.down);

        }
    }
}
