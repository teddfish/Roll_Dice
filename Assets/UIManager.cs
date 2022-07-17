using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool isMenu = false;
    CC cc;
    [SerializeField] GameObject lvlClr;
    // Start is called before the first frame update
    void Start()
    {
        if (!isMenu)
        {
            cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CC>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && isMenu)
        {
            SceneManager.LoadScene(1);
        }

        if (isMenu)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Restart());
        }



        if (cc.hasWon || Input.GetKeyDown(KeyCode.L))
        {
            if (SceneManager.GetActiveScene().buildIndex < 15)
                StartCoroutine(NextLevel());
            else
                StartCoroutine(BackToMenu());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator NextLevel()
    {

        lvlClr.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

        IEnumerator BackToMenu()
    {

        lvlClr.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);


    }
}
