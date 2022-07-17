using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    CC cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Restart());
        }

        if (cc.hasWon)
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator Restart(){
        yield return new WaitForSeconds (0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

        IEnumerator NextLevel(){
        yield return new WaitForSeconds (1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
