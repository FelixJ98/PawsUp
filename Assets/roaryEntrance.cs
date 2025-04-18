using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roaryEntrance : MonoBehaviour
{
    [SerializeField] private GameObject roary;

    private void OnTriggerEnter(Collider other)
    {
        if (roary != null)
        {
            roary.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Roary not assigned!");
        }
    }
}
