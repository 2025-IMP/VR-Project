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
    void Awake()
    {
        dome = transform.Find("Dome").gameObject;
        //GranedeExplosion();
    }
    public void GranedeExplosion()
    {
        dome.SetActive(true);
        StartCoroutine(UpdateDomeScaleCoroutine());
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
