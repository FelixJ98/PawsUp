using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShowInfo : MonoBehaviour
{
    public GameObject button;
    public GameObject photosphere;
    private EventSystem eventSystem;
    private PointerEventData pointerEventData;
    public GameObject infoCanvas;
    public Dictionary<Material, string> splashTexts;
    public Material[] sphereMaterials;
    public string[] flavorTexts;
    public TextMeshProUGUI textObject;
    // Start is called before the first frame update
    //keep map of all the splash text for different photospheres in some data structure
    void Start()
    {
        // Ensure EventSystem is set up
        eventSystem = EventSystem.current;
        pointerEventData = new PointerEventData(eventSystem);
        for(int i = 0; i < sphereMaterials.Length; i++) {
            if(i < flavorTexts.Length) {
                splashTexts.Add(sphereMaterials[i], flavorTexts[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Hit");
        SimulateMouseHover();
        ShowInfoCanvas();
    }  

    private void OnTriggerExit(Collider other)
    {
        SimulateMouseExit();
    }

    private void ShowInfoCanvas(){
        //retrieve the current material of this photosphere
        Material currMat = photosphere.GetComponent<MeshRenderer>().material;
        //get the splashtext from the dict
        string currText;
        if(splashTexts.ContainsKey(currMat)) {
            bool success = splashTexts.TryGetValue(currMat, out currText);
        } else {
            currText = "";
            Debug.Log("Material " + currMat + " not found in splash texts.");
        }
        //set it to the text of the textmeshpro object
        textObject.text = currText;
        //set text to active
        infoCanvas.SetActive(true);
    }

    private void SimulateMouseHover()
    {
        if (button != null)
        {
            // Set the pointer's position (you can adjust the position if needed)
            pointerEventData.position = button.transform.position;
            // Simulate the "pointerEnter" event (hovering over)
            ExecuteEvents.Execute(button, pointerEventData, ExecuteEvents.pointerEnterHandler);
        }
    }

    private void SimulateMouseExit()
    {
        if (button != null)
        {
            // Set the pointer's position (you can adjust the position if needed)
            pointerEventData.position = button.transform.position;

            // Simulate the "pointerExit" event (leaving the hover)
            ExecuteEvents.Execute(button, pointerEventData, ExecuteEvents.pointerExitHandler);
        }
    }
}
