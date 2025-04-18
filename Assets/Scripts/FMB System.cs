using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FMBSystem : MonoBehaviour
{
    public bool Fix_Floor = false;
    [Header("Game Objects List")]
    public bool Fix_Obj_Spawning = false;
    public List<GameObject> targetSpawners = new List<GameObject>();
    public float yAdjust = 1.5f;
    [Header("Player Fixes")]
    public GameObject[] hands;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        floorFixer();
        spawnFixer();
        playerFixes();
    }

    void floorFixer()
    {
        GameObject targetObject = GameObject.Find("FLOOR");
        if (targetObject != null && Fix_Floor)
        {
            // If the object is found, add a BoxCollider to it
            BoxCollider boxCollider = targetObject.transform.GetChild(0).transform.GetChild(0).gameObject.AddComponent<BoxCollider>();

            Debug.Log($"BoxCollider added to {targetObject.name}");
            Fix_Floor = false;
        }
    }

    void spawnFixer()
    {
        if (Fix_Obj_Spawning && targetSpawners[0].transform.childCount != 0)
        {
            Debug.Log("truth detected");
            for (int i = 0; i < targetSpawners.Count; i++)
            {
                Debug.Log("entered first loop");
                Debug.Log(targetSpawners[i].transform.childCount);
                for (int j = 0; j < targetSpawners[i].transform.childCount; j++)
                {
                    float newX = targetSpawners[i].transform.GetChild(j).gameObject.transform.position.x;
                    float newY = targetSpawners[i].transform.GetChild(j).gameObject.transform.position.y + yAdjust;
                    float newZ = targetSpawners[i].transform.GetChild(j).gameObject.transform.position.z;
                    targetSpawners[i].transform.GetChild(j).gameObject.transform.position.Set(newX, newY, newZ);
                    Debug.Log("Positions adjusted to: " + targetSpawners[i].transform.GetChild(j).gameObject.transform.position);
                    Fix_Obj_Spawning = false;
                }
            }
        }
    }

    void playerFixes()
    {
        Debug.Log("RUNNING");

        if (hands.Length > 0)
        {

            foreach (GameObject hand in hands)
            {
                foreach (Transform child in hand.transform)
                {
                    if (child.name == "Capsules") // Check if the child's name matches "Capsule"
                    {
                        Debug.Log("Changing tag for: " + child.name);
                        child.gameObject.tag = "Player";

                        // If the Capsule has children, recursively change their tags
                        ChangeTagsRecursively(child.gameObject, "Player");
                    }
                }
            }
        }
        else
        {
            Debug.LogError("No Capsules found!");
        }
    }
    void ChangeTagsRecursively(GameObject obj, string tag)
    {
        Debug.Log("FOUND");
        // Change the tag of the current GameObject
        obj.tag = tag;

        // Iterate through each child and recursively change their tags
        foreach (Transform child in obj.transform)
        {
            ChangeTagsRecursively(child.gameObject, tag);
        }
    }
}
