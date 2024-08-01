using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TrashCan : MonoBehaviour
{
    List <GameObject> _gameObjects = new List<GameObject>();
    List<Vector3> _startPositions = new List<Vector3>();
    XRSocketInteractor _socketInteractor;
    AudioSource _audioSource;
    private WaitForSeconds _sleep = new WaitForSeconds(0.5f);

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> objectList = new List<GameObject>();
        GameObject.Find("Objectives").GetChildGameObjects(objectList);
        foreach (GameObject gameObject in objectList)
        {
            if (gameObject.GetComponent<XRGrabInteractable>() != null)
            {
                _gameObjects.Add(gameObject);
                _startPositions.Add(gameObject.transform.position);
            }
        }
        _socketInteractor = GetComponent<XRSocketInteractor>();
        if ( _socketInteractor == null )
        {
            Debug.LogError("Socket Interactor is null on Trashcan on " +  gameObject.name);
        }

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("Audio source is null on Trashcan on " + name);
        }
    }

    public void DestroyObject()
    {
        GameObject socketedObject = _socketInteractor.GetOldestInteractableSelected().transform.gameObject;
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            if (_gameObjects[i] == socketedObject)
            {
                _audioSource.Play();
                StartCoroutine(MoveObject(i, socketedObject));
                return;
            }
        }
    }

    private IEnumerator MoveObject(int i, GameObject socketedObject)
    {
        while (_audioSource.isPlaying)
        {
            if (_audioSource.time > 2.5f)
            {
                _socketInteractor.interactionManager.SelectExit(_socketInteractor, _socketInteractor.GetOldestInteractableSelected());
                socketedObject.transform.position = _startPositions[i];                
            }
            yield return _sleep;
        }
    }

}
