using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelsFollowYou : MonoBehaviour
{
    private Transform mainCamera;

    void Start()
    {
        if (Camera.main != null)
            mainCamera = Camera.main.transform;
    }

    void Update()
    {
        if (mainCamera == null) return;

        foreach (Transform child in transform)
        {
            Vector3 lookDirection = mainCamera.position - child.position;
            lookDirection.y = 0;

            if (lookDirection != Vector3.zero)
                child.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}
