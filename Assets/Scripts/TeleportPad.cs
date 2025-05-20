using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportPad : MonoBehaviour
{
    [SerializeField] Transform targetPad;      // Inspector에 연결

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("MainCamera"))
        {
            XROrigin rig = col.GetComponentInParent<XROrigin>();
            if (rig && targetPad)
            {
                Vector3 camOffset = col.transform.position - rig.transform.position;
                rig.transform.position = targetPad.position - camOffset;
            }
        }
    }
}
