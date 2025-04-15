using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    public GameObject dialogBoxPrefab;
    //private GameObject activeDialog;
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("Hand"))
        {
            if(dialogBoxPrefab == null) {
                Debug.Log("Dialog box null check");
            } else {
                Debug.Log("Triggered by: " + other.gameObject.name);
                //Instantiate(dialogBoxPrefab, new Vector3(0,0.5f,0), Quaternion.identity);
                Debug.Log(dialogBoxPrefab.activeSelf);
                dialogBoxPrefab.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        dialogBoxPrefab.SetActive(false);
    }
}
