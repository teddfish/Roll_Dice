using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    //basic movement
    [SerializeField] float rollSpeed = 5;
    [SerializeField] float offset = 0.5f;
    [SerializeField] CameraShake camShaker;
    [SerializeField] GameObject disappearingTiles;
    bool rolling;

    //tracks which face is facing the tiles
    public int currentFace;

    //move counter
    public int moveCounter;

    //detecting valid move
    Transform validMoveGO;
    ValidMoveDetection valMove;
    [SerializeField] TileCheck leftC;
    [SerializeField] TileCheck rightC;
    [SerializeField] TileCheck forwardC;
    [SerializeField] TileCheck backC;

    Conditions conditions;

    //reverse rotation condition
    bool alternateMovement;

    //double move condition
    bool rotate90;

    //toggle tiles condition
    bool toggleTiles;

    //reset condition
    bool canTeleport;
    Vector3 startPosition;

    private void Start()
    {
        validMoveGO = GameObject.Find("Valid_Move_Detection").transform;
        valMove = GameObject.Find("Valid_Move_Detection").GetComponent<ValidMoveDetection>();
        conditions = GameObject.Find("Special_Tile").GetComponent<Conditions>();

        startPosition = transform.position;
        
    }


    void Update()
    {
        if (rolling)
        {
            return;
        }

        //rotate 90 condition
        if (rotate90)
        {
            RotateCube();
            rotate90 = false;
        }

        //tiles on and off condition
        if (toggleTiles)
        {
            if (disappearingTiles.activeInHierarchy)
            {
                disappearingTiles.SetActive(false);
                toggleTiles = false;
            }
            else {
                disappearingTiles.SetActive(true);
                toggleTiles = false;
            }

        }

        if (canTeleport)
        {
            transform.position = startPosition;
            validMoveGO.position = startPosition;
            canTeleport = false;
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !leftC.blockMove)
        {
            //reverse movement
            if (alternateMovement == true)
            {
                AltMove(Vector3.right);
                valMove.CheckMove(Vector3.left);
                return;
            }

            //normal movement 
            Move(Vector3.left);
            valMove.CheckMove(Vector3.left);

        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !rightC.blockMove)
        {
            //reverse movement
            if (alternateMovement == true)
            {
                AltMove(Vector3.left);
                valMove.CheckMove(Vector3.right);
                return;
            }

            //normal movement
            Move(Vector3.right);
            valMove.CheckMove(Vector3.right);

        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !forwardC.blockMove)
        {            
            //reverse movement
            if (alternateMovement == true)
            {
                AltMove(Vector3.back);
                valMove.CheckMove(Vector3.forward);
                return;
            }

            //normal movement
            Move(Vector3.forward);
            valMove.CheckMove(Vector3.forward);
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !backC.blockMove)
        {
            //reverse movement
            if (alternateMovement == true)
            {
                AltMove(Vector3.forward);
                valMove.CheckMove(Vector3.back);
                return;
            }

            //normal movement
            Move(Vector3.back);
            valMove.CheckMove(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.P) && !backC.blockMove)
        {
            RotateCube();
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
                conditions.tileTouched = false;

                if (conditions.faceConditions[currentFace - 1] == Conditions.ConditionType.Win)
                {
                    print("You win");
                }
                else if (conditions.faceConditions[currentFace - 1] == Conditions.ConditionType.Nothing)
                {
                    print("Doing nothing");
                }
                else if (conditions.faceConditions[currentFace - 1] == Conditions.ConditionType.ReverseRotation)
                {   
                    if (!alternateMovement)
                    {
                        alternateMovement = true;
                    }
                    else {
                        alternateMovement = false;
                    }
                }
                else if (conditions.faceConditions[currentFace - 1] == Conditions.ConditionType.RotateAround)
                {
                    if (!rotate90)
                    {
                        rotate90 = true;
                    }
                    else {
                        rotate90 = false;
                    }
                }                
                else if (conditions.faceConditions[currentFace - 1] == Conditions.ConditionType.ToggleTiles)
                {
                    if (!toggleTiles)
                    {
                        toggleTiles = true;
                    }
                    else {
                        toggleTiles = false;
                    }
                }
                else if (conditions.faceConditions[currentFace - 1] == Conditions.ConditionType.Teleport)
                {
                    if (!canTeleport)
                    {
                        canTeleport = true;
                    }
                    else {
                        canTeleport = false;
                    }
                }

            }

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

    public void AltMove(Vector3 direction)
    {
        Vector3 reverseRollEdge = transform.position - (direction + Vector3.down) * offset;
        Vector3 axis = Vector3.Cross(Vector3.up, direction);

        camShaker.StartShake(direction);
        StartCoroutine(ReverseRoll(reverseRollEdge, axis));
        moveCounter += 1;
    }

    public void RotateCube()
    {
        Vector3 rotatePoint = this.transform.position;
        Vector3 rotateAxis = Vector3.up;

        StartCoroutine(Rotate(rotatePoint, rotateAxis));
        moveCounter += 1;

    }

    IEnumerator ReverseRoll(Vector3 reverseRollEdge, Vector3 axis)
    {
        rolling = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(reverseRollEdge, axis, rollSpeed);
            //transform.position = transform.position + direction;

            yield return new WaitForSeconds(0.01f);
        }

        rolling = false;
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

    IEnumerator Rotate(Vector3 rollEdge, Vector3 axis)
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
