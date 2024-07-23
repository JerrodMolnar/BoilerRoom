using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrashCan : MonoBehaviour
{
    List <GameObject> _gameObjects = new List<GameObject>();
    List<Vector3> _startPositions = new List<Vector3>();
    XRSocketInteractor _socketInteractor;

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
    }

    public void DestroyObject()
    {
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            if (_gameObjects[i] ==(GameObject) _socketInteractor.GetOldestInteractableSelected().transform.gameObject)
            {
                _gameObjects[i].transform.position = _startPositions[i];
            }
        }
    }

}
