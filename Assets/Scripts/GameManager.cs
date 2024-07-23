using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    AudioSource _resetLeverAudioSource;
    WaitForSeconds _sleep = new WaitForSeconds(.5f);

    private void Start()
    {
        if (_resetLeverAudioSource == null)
        {
            Debug.LogError("Reset lever audio source not found on GameManager.");
        }
    }

    public void RestartScene()
    {
        StartCoroutine(SceneRestart());
    }

    private IEnumerator SceneRestart()
    {
        _resetLeverAudioSource.Play();
        while (_resetLeverAudioSource.isPlaying)
        {
            yield return _sleep;
        }
        SceneManager.LoadScene(0);
    }        

    public void QuitGame()
    {
        
        Application.Quit();
    }
}
