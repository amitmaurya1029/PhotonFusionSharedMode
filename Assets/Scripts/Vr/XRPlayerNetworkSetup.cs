using System.Threading.Tasks;
using Fusion;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class XRNetworkPlayerSetup : NetworkBehaviour
{
    public Camera xrCamera;
    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;

    void Start()
    {

        bool isLocal = Object.HasInputAuthority;


        xrCamera.enabled = isLocal;

        SetTrackedPoseDriverEnabled(head, isLocal);
        SetTrackedPoseDriverEnabled(leftHand, isLocal);
        SetTrackedPoseDriverEnabled(rightHand, isLocal);
    }

    void SetTrackedPoseDriverEnabled(GameObject obj, bool enabled)
    {



        Component[] components  = obj.GetComponents<Component>();
        foreach (Component comp in components)
        {
            if (comp is UnityEngine.InputSystem.XR.TrackedPoseDriver driver)
            {
                driver.enabled = enabled;
                Debug.Log("TrackedPoseDriver enabled: " + enabled);
            }
            else if (comp is XRInteractionGroup controller)
            {
                controller.enabled = enabled;
                Debug.Log("XRController enabled: " + enabled);
            }
            else if (comp is HapticImpulsePlayer rayInteractor)
            {
                rayInteractor.enabled = enabled;
                Debug.Log("HapticImpulsePlayer enabled: " + enabled);
            }
             else if (comp is ControllerInputActionManager controllerInputActionManager)
            {
                controllerInputActionManager.enabled = enabled;
                Debug.Log("ControllerInputActionManager enabled: " + enabled);
            }
          
          
        }
    }

    

   
}
