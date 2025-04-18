using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterOnSceneLoad : MonoBehaviour
{
    public OVRCameraRig cameraRig;

    void Start()
    {
        StartCoroutine(RecenterWhenReady());
    }

    IEnumerator RecenterWhenReady()
    {
        // Wait for headset pose to be valid (just give it a few frames)
        yield return new WaitForSeconds(0.5f);

        // Then recenter
        Recenter();
    }

    void Recenter()
    {
        Transform head = cameraRig.centerEyeAnchor;

        // Get current yaw (Y rotation) of the headset
        float currentYaw = head.eulerAngles.y;

        // Rotate the rig to offset this yaw
        //cameraRig.transform.Rotate(0, -currentYaw, 0);
        cameraRig.transform.Rotate(0, 0, 0);
        

        // Optional: zero out position offset from head
        Vector3 offset = new Vector3(head.localPosition.x, 0, head.localPosition.z);
        cameraRig.transform.position -= offset;

        Debug.Log("✅ Recentered rig (without deprecated methods)");
    }
}
