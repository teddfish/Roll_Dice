using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxSpawner : MonoBehaviour
{
    [SerializeField] GameObject winFx;
    [SerializeField] Vector3 diceSpawnOffset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.A))
        //     SpawnWinFx(this.transform.position);
    }

    void SpawnWinFx(Vector3 dicePosition)
    {
        var fx = GameObject.Instantiate(winFx, dicePosition + diceSpawnOffset, Quaternion.identity);
        GameObject.Destroy(fx, 1.5f);
    }
}
