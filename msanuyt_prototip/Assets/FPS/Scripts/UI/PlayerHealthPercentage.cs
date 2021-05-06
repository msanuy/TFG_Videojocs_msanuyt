using TMPro;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI{
    public class PlayerHealthPercentage : MonoBehaviour
    {
        [Tooltip("Text for Health percentage")] 
            public TextMeshProUGUI PercentageText;
            Health m_PlayerHealth;

            void Start()
            {
                PlayerCharacterController playerCharacterController =
                    GameObject.FindObjectOfType<PlayerCharacterController>();
                DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(
                    playerCharacterController, this);

                m_PlayerHealth = playerCharacterController.GetComponent<Health>();
                DebugUtility.HandleErrorIfNullGetComponent<Health, PlayerHealthBar>(m_PlayerHealth, this,
                    playerCharacterController.gameObject);
            }

            void Update()
            {
                PercentageText.text = (m_PlayerHealth.CurrentHealth *100f/ m_PlayerHealth.MaxHealth).ToString() + " %";
            }
    }
}
