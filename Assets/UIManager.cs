using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart(){
        yield return new WaitForSeconds (0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
