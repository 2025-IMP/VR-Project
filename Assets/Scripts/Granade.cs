using System.Collections;
using UnityEngine;

public class Granade : MonoBehaviour
{
    private GameObject dome;
    private float domeScale = 0f;
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

    private void DestroySelf()
    {
        dome.SetActive(false);
        gameObject.SetActive(false);
    }

    IEnumerator UpdateDomeScaleCoroutine()
    {
        if (domeScale > 1f)
        {
            DestroySelf();
        }
        dome.transform.localScale = Vector3.one * domeScale;
        domeScale += 0.033f;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(UpdateDomeScaleCoroutine());
    }
}
