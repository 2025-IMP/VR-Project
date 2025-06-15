using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private InputActionAsset m_InputAction;
    private InputAction m_TriggerAction;

    private ContinuousMoveProvider m_MoveProvider;
    public ContinuousMoveProvider MoveProvider => m_MoveProvider;

    [SerializeField] private RailGun m_Gun;
    public RailGun Gun => m_Gun;

    private IAttackStrategy m_CurrAttackStrategy;

    private void Awake()
    {
        m_TriggerAction = m_InputAction.FindActionMap("XRI Right Interaction").FindAction("Activate");
        m_MoveProvider = GetComponent<ContinuousMoveProvider>();
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
