using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void RestartScene()
    {
        StartCoroutine(SceneRestart());
    }

    private IEnumerator SceneRestart()
    {
        yield return new WaitForSeconds(7.5f);
        SceneManager.LoadScene(0);
    }
}
