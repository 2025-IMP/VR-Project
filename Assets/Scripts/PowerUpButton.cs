using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpButton : MonoBehaviour
{
    [SerializeField] private TMP_Text m_NameText;
    [SerializeField] private TMP_Text m_DescText;
    [SerializeField] private Image m_Icon;

    private AbilityType m_Type;
    public AbilityType Type => m_Type;

    public void Setup(AbilityType type)
    {
        m_Type = type;

        Dictionary<AbilityType, int> currAbilities = Player.PlayerInstance.Ability.Abilities;
        int currLevel = currAbilities.ContainsKey(m_Type) ? currAbilities[m_Type] : 0;

        CardData cData = AbilityManager.Instance.CardDataStorage.First(cardData => cardData.Type == type);

        m_NameText.text = cData.Name;
        m_DescText.text = cData.PowerUps[currLevel].Desc;
        m_Icon.sprite = cData.Icon;
    }
}
