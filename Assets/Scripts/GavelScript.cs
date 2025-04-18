using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavelScript : MonoBehaviour
{
    public GameObject particle;
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
        //Debug.Log(other.tag);
        //if (other.gameObject.CompareTag("Player"))
        {
            particle.GetComponent<ParticleSystem>().Play();
        }
    }
}
