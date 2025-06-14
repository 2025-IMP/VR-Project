using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GranadeController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Granade granade;
    void Awake()
    {
        // 본인 오브젝트에서 컴포넌트 가져오기
        grabInteractable = GetComponent<XRGrabInteractable>();
        granade = GetComponent<Granade>();

        // 이벤트에 함수 등록
        grabInteractable.selectExited.AddListener(OnReleased);
    }
    private void OnReleased(SelectExitEventArgs args)
    {
        // 놓았을 때 호출됨
        Debug.Log("수류탄 놓음!");
        granade.ExplosionTimer();  // 원하는 동작 실행
    }

    void OnDestroy()
    {
        // 이벤트 정리 (메모리 누수 방지)
        if (grabInteractable != null)
            grabInteractable.selectExited.RemoveListener(OnReleased);
    }
}