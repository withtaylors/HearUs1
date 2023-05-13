using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator crossFade;
    public float transitionTime = 1f;

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
/*    public void MoveToScene()
    {
        StartCoroutine(LoadMap(SceneManager.GetActiveScene().buildIndex+1));
    }*/

/*    IEnumerator LoadMap(int levelIndex)
    {
        crossFade.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.MoveToScene(levelIndex);
    }*/
}
