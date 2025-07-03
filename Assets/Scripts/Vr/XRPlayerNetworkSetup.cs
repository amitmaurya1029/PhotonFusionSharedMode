using Fusion;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRNetworkPlayerSetup : NetworkBehaviour
{
    public Camera xrCamera;
    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;

    void Start()
    {
        // Only the local player should control this rig
        bool isLocal = Object.HasInputAuthority;

        // Enable input + camera only for local player
        xrCamera.enabled = isLocal;

        // Disable TrackedPoseDrivers for remote players
        SetTrackedPoseDriverEnabled(head, isLocal);
        SetTrackedPoseDriverEnabled(leftHand, isLocal);
        SetTrackedPoseDriverEnabled(rightHand, isLocal);
    }

    void SetTrackedPoseDriverEnabled(GameObject obj, bool enabled)
    {
        var driver = obj.GetComponent<UnityEngine.InputSystem.XR.TrackedPoseDriver>();
        if (driver != null)
        {
            driver.enabled = enabled;
        }
    }

   
}
