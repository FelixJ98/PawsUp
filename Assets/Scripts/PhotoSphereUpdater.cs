using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoSphereUpdater : MonoBehaviour
{
    public Material[] photoSpheres;
    public GameObject photoSphere;
    public bool forward = true;
    public static int cIndex = 0;
    [SerializeField] private Collider collider;
    private bool resetRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        cIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (forward)
        {
            if (cIndex + 1 < photoSpheres.Length)
            {
                cIndex++;
            }
            else
            {
                cIndex = 0;
            }
            photoSphere.GetComponent<MeshRenderer>().material = photoSpheres[cIndex];
            collider.enabled = false;
            StartCoroutine(resetButton());
        }
        else
        {
            if (cIndex - 1 >= 0)
            {
                cIndex--;
            }
            else
            {
                cIndex = photoSpheres.Length - 1;
            }
            photoSphere.GetComponent<MeshRenderer>().material = photoSpheres[cIndex];
            collider.enabled = false;
            StartCoroutine(resetButton());
        }
    }

    IEnumerator resetButton()
    {
        if (!resetRunning)
        {
            resetRunning = true;
            yield return new WaitForSeconds(.75f);
            collider.enabled = true;
            resetRunning = false;
        }
    }
}
