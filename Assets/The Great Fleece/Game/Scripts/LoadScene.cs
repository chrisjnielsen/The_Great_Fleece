using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //reference progress bar
    public Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        // call coroutine to load the main scene  
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        //create an async operation = loadSceneAsync("Main")
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");
        //While operation isn't finished
        while (operation.isDone == false)
        {
            progressBar.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
        }
        //progress bar fill amount = operations progress
        //yield waitforendofframe
        
    }
}
