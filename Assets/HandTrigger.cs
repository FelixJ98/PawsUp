using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    public GameObject dialogBoxPrefab;
    //private GameObject activeDialog;
    //private EventSystem eventSystem;
    //pointerEventData = new PointerEventData(eventSystem);
    
    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject);
        //if (other.gameObject.name.Contains("Hand"))
        if (other.gameObject.CompareTag("Player"))
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

        //pointerEventData = new PointerEventData(eventSystem);

    }

    void OnTriggerExit(Collider other)
    {
        dialogBoxPrefab.SetActive(false);
    }

    // private void SimulateMouse() {
    //     pointerEventData.position = this.gameObject.transform.position;

        
    // }
}
