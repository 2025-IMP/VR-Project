using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;   
    [SerializeField] private RailGun railgun;
    private InputAction gunAction;
    void Awake()
    {
        if(inputActions != null)
        {
            gunAction = inputActions.FindActionMap("XRI Right Interaction").FindAction("Select"); // get the right-hand select action
        }

    }


    void Update()
    {
        if (gunAction.WasPressedThisFrame())
        {
            railgun.Shoot();
        }
    }
}
