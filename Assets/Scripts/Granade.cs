using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class Granade : MonoBehaviour
{
    private GameObject dome;
    private float domeScale = 0f;
    private bool expState = false;
    private bool expPossible = false;

    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        dome = transform.Find("Dome").gameObject;
        //GranedeExplosion();
    }
    public void GranedeExplosion()
    {
        dome.SetActive(true);
        StartCoroutine(UpdateDomeScaleCoroutine());

        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.isKinematic = true;

        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy") && collider.TryGetComponent(out EnemyController enemy))
            {
                enemy.TakeDamage((int)(10f * Player.PlayerInstance.PowerRatio));
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (expPossible && collision.transform.CompareTag("Enemy"))
        {
            expState = true;
            GranedeExplosion();
        }
    }
    private void DestroySelf()
    {
        dome.SetActive(false);
        gameObject.SetActive(false);
    }
    public void ExplosionTimer()
    {
        if (!expState)
        {
            Invoke("GranedeExplosion", 5f);
            expPossible = true;
        }
    }

    IEnumerator UpdateDomeScaleCoroutine()
    {
        if (domeScale > 0.1f)
        {
            DestroySelf();
        }
        dome.transform.localScale = Vector3.one * domeScale;
        domeScale += 0.0033f;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(UpdateDomeScaleCoroutine());
    }
}
