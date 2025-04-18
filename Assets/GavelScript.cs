using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gavel")){
            Debug.Log("hit");
            this.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }
}
