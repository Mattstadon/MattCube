using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator Loadlevel(int levelIndex)
    {
        //Play Anim
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Loadscene
        SceneManager.LoadScene(levelIndex);
    }
}
