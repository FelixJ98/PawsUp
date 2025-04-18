using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummonPortalOnTouch : MonoBehaviour
{
    [SerializeField] private GameObject portalObject;

 
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("collision recognized");
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("identified player");
            if (portalObject == null)
            {
                Debug.Log("Portal not found");
            }
            else
            {
                portalObject.SetActive(true);
            }
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        portalObject.SetActive(false);

    }

}