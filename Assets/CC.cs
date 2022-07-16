using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    //basic movement
    [SerializeField] float rollSpeed = 5;
    [SerializeField] float offset = 0.5f;
    [SerializeField] CameraShake camShaker;
    bool rolling;

    //tracks which face is facing the tiles
    public int currentFace;

    //move counter
    public int moveCounter;

    //detecting valid move
    ValidMoveDetection valMove;
    [SerializeField] TileCheck leftC;
    [SerializeField] TileCheck rightC;
    [SerializeField] TileCheck forwardC;
    [SerializeField] TileCheck backC;

    Conditions conditions;

    private void Start() 
    {
        valMove = GameObject.Find("Valid_Move_Detection").GetComponent<ValidMoveDetection>();   
        conditions = GameObject.Find("Special_Tile").GetComponent<Conditions>(); 
    }


    void Update()
    {
        if (rolling)
        {
            return;
        }


        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !leftC.blockMove)
        {
            Move(Vector3.left);
            valMove.CheckMove(Vector3.left);
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !rightC.blockMove)
        {
            Move(Vector3.right);
            valMove.CheckMove(Vector3.right);

        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !forwardC.blockMove)
        {
            Move(Vector3.forward);            
            valMove.CheckMove(Vector3.forward);
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !backC.blockMove)
        {
            Move(Vector3.back);            
            valMove.CheckMove(Vector3.back);
        }

        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.5f))
        {
            if (hit.transform.tag == "One")
            {
                currentFace = 1;
            }
            else if (hit.transform.tag == "Two")
            {
                currentFace = 2;
            }
            else if (hit.transform.tag == "Three")
            {
                currentFace = 3;
            }
            else if (hit.transform.tag == "Four")
            {
                currentFace = 4;
            }
            else if (hit.transform.tag == "Five")
            {
                currentFace = 5;
            }
            else if (hit.transform.tag == "Six")
            {
                currentFace = 6;
            }

            //print(currentFace);

            if (conditions.tileTouched)
            {
                if (currentFace == conditions.win)
                {
                    print("yes");
                    conditions.tileTouched = false;
                }

                
            }
            //print (moveCounter);
            //Debug.Log(hit.transform.gameObject.name);

        }

    }

    public void Move(Vector3 direction)
    {
        Vector3 rollEdge = transform.position + (direction + Vector3.down) * offset;
        Vector3 axis = Vector3.Cross(Vector3.up, direction);

        camShaker.StartShake(direction);
        StartCoroutine(Roll(rollEdge, axis));

        moveCounter += 1;
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
