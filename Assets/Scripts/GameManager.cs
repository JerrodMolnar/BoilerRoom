using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    AudioSource _resetLeverAudioSource;

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
        while (_resetLeverAudioSource.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene(0);
    }
}
