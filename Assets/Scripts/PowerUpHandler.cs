using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] private GameObject m_CanvasObj;
    [SerializeField] private Transform m_ButtonRoot;

    private PowerUpButton[] m_PowerUpButtons;

    void Awake()
    {
        m_CanvasObj.SetActive(false);
        m_PowerUpButtons = m_ButtonRoot.GetComponentsInChildren<PowerUpButton>(true);
    }

    void OnEnable()
    {
        PlayerLevel.OnLevelUp += SetPowerUpCards;
    }
    void OnDisable()
    {
        PlayerLevel.OnLevelUp -= SetPowerUpCards;
    }

    public void SetPowerUpCards()
    {
        m_CanvasObj.SetActive(true);

        List<AbilityType> availableAbilities = Enum.GetValues(typeof(AbilityType)).Cast<AbilityType>().ToList();
        Dictionary<AbilityType, int> currAbilities = Player.PlayerInstance.Ability.Abilities;

        foreach (var currAbility in currAbilities)
        {
            AbilityType type = currAbility.Key;
            int level = currAbility.Value;

            CardData cData = AbilityManager.Instance.CardDataStorage.First(cardData => cardData.Type == type);
            if (level >= cData.MaxLevel)
                availableAbilities.Remove(type);
        }

        System.Random rand = new System.Random();
        List<AbilityType> shAbilities = availableAbilities.OrderBy(_ => rand.Next()).ToList();

        for (int i = 0; i < m_PowerUpButtons.Length; i++)
        {
            m_PowerUpButtons[i].Setup(shAbilities[i]);
        }
    }

    public void OnPowerUpPressed(int index)
    {
        PowerUpButton pressedButton = m_PowerUpButtons[index];
        Player.PlayerInstance.Ability.PowerUpAbility(pressedButton.Type);

        m_CanvasObj.SetActive(false);
    }
}
