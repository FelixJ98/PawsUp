using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class GLScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the Green Library zone");
            script.text = "The green library is the biggest building in FIU. " +
                          "As you go up the building each floor becomes more quiet.";
        }
    }
}
    
