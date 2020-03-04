using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Button to start the game
    public void PlayButt()
    {
        // loading
        StartCoroutine(LoadASynchronously());
    }

    IEnumerator LoadASynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        while(!operation.isDone)
        {
            // Clamps value between 0 and 1 and returns value(because the progress stop at .9)
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);

            yield return null;
        }
    }
}
