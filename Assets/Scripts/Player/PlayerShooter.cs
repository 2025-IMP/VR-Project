using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private InputActionAsset m_InputAction;
    private InputAction m_TriggerAction;

    [SerializeField] private RailGun m_Gun;

    private IAttackStrategy m_CurrAttackStrategy;

    private void Awake()
    {
        m_TriggerAction = m_InputAction.FindActionMap("XRI Right Interaction").FindAction("Activate");
    }

    private void Start()
    {
        SetAttackStrategy(m_Gun);
    }

    private void Update()
    {
        if (m_TriggerAction.WasPressedThisFrame())
        {
            m_CurrAttackStrategy?.Execute();
        }
    }

    public void SetAttackStrategy(IAttackStrategy attackStrategy)
    {
        m_CurrAttackStrategy = attackStrategy;
    }
}
