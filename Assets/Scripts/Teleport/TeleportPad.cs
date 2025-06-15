using UnityEngine;
using Unity.XR.CoreUtils;

[RequireComponent(typeof(BoxCollider))]
public class TeleportPad : MonoBehaviour
{
    [Tooltip("밟으면 이동할 목적지 Pad")]
    public TeleportPad destination;

    [Tooltip("왕복 무한루프 방지를 위한 쿨타임")]
    public float cooldown = 10f;

    static bool lockFlag;

    void Awake()
    {
        var col = GetComponent<BoxCollider>();
        col.isTrigger = true;
        col.center    = Vector3.up * .05f;
        col.size      = new Vector3(1f, .1f, 1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (lockFlag || destination == null) return;
        if (!other.CompareTag("Player")) return;

        var rig = other.GetComponentInParent<XROrigin>();
        if (!rig) return;

        AudioManager.Instance.PlayAudio(AudioType.SFX, AudioManager.Instance.teleportSFX);

        // ★ 안정 이동
        rig.MoveCameraToWorldLocation(destination.transform.position);

        StartCoroutine(UnlockAfter());
    }

    System.Collections.IEnumerator UnlockAfter()
    {
        lockFlag = true;
        yield return new WaitForSeconds(cooldown);
        lockFlag = false;
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (!destination) return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position + Vector3.up * .02f,
                        destination.transform.position + Vector3.up * .02f);
        Gizmos.DrawSphere(destination.transform.position + Vector3.up * .02f, .06f);
    }
#endif
}
