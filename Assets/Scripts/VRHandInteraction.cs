using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRHandInteraction : MonoBehaviour
{
    public GameObject button;
    private EventSystem eventSystem;
    private PointerEventData pointerEventData;
    private int count = 0;
    private bool counting = false;
    // Start is called before the first frame update
    void Start()
    {
        // Ensure EventSystem is set up
        eventSystem = EventSystem.current;
        pointerEventData = new PointerEventData(eventSystem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Hit");
        SimulateMouseHover();
        StartCoroutine(StopAndCount());
    }

    private void OnTriggerExit(Collider other)
    {
        SimulateMouseExit();
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

    IEnumerator StopAndCount()
    {
        if (!counting)
        {
            counting = true;
            if (count < 3)
            {
                yield return new WaitForSeconds(1);
                Debug.Log(count);
                count++;
                counting = false;
            }
            else
            {
                LoadNextScene();
                counting = false;
            }
        }
    }
    private void LoadNextScene()
    {
        if(button.TryGetComponent<SceneLoader>(out SceneLoader sl))
        {
            sl.StartSceneTransition();
        }
    }
}
