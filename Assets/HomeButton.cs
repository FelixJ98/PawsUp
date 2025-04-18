using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    [SerializeField] private GameObject portalObject;

    private void OnTriggerEnter(Collider other)
    {
        if (portalObject != null)
        {
            bool isActive = portalObject.activeSelf;
            portalObject.SetActive(!isActive);
        }
        else
        {
            Debug.LogWarning("Portal Object is not assigned!");
        }
    }
}
