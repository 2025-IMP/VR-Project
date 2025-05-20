using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable), typeof(AudioSource))]
public class GunShooter : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] ParticleSystem muzzleFx;
    [SerializeField] float fireRate = 0.25f;
    [SerializeField] float maxDist = 50f;
    [SerializeField] int damage = 10;

    XRGrabInteractable grab;
    [SerializeField] InputActionProperty activate;   // 트리거 액션
    float nextFire;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        // activate is now assigned via Inspector
    }

    void Update()
    {
        if (grab.isSelected) {
            if (activate.action.IsPressed() && Time.time > nextFire) {
                Shoot();
                nextFire = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        if (muzzleFx) { muzzleFx.Play(); }
        GetComponent<AudioSource>().Play();

        if (Physics.Raycast(muzzle.position, muzzle.forward,
                            out var hit, maxDist)) {
            if (hit.collider.TryGetComponent(out Enemy e)) {
                e.TakeDamage(damage);
            }
        }
    }
}
