using UnityEngine;

public class EndCanvas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().enabled = false;
        }
    }
}
