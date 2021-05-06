using TMPro;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class AmmoCounter : MonoBehaviour
    {
        [Tooltip("CanvasGroup to fade the ammo UI")]
        public CanvasGroup CanvasGroup;

        [Tooltip("Image for the weapon icon")] public Image WeaponImage;

        [Tooltip("Text for Weapon index")] 
        public TextMeshProUGUI WeaponIndexText;

        [Tooltip("Text for Bullet Counter")] 
        public TextMeshProUGUI BulletCounter;

        [Tooltip("Text for the total ammo Counter")]
        public TextMeshProUGUI TotalAmmo;

        [Header("Selection")] [Range(0, 1)] [Tooltip("Opacity when weapon not selected")]
        public float UnselectedOpacity = 0.5f;

        [Tooltip("Scale when weapon not selected")]
        public Vector3 UnselectedScale = Vector3.one * 0.8f;

        [Tooltip("Root for the control keys")] public GameObject ControlKeysRoot;

        public int WeaponCounterIndex { get; set; }

        PlayerWeaponsManager m_PlayerWeaponsManager;
        Ammo m_Ammo;
        WeaponController m_Weapon;

        void Awake()
        {
            EventManager.AddListener<AmmoPickupEvent>(OnAmmoPickup);
        }

        void OnAmmoPickup(AmmoPickupEvent evt)
        {
            if (evt.Weapon == m_Weapon)
            {
                BulletCounter.text = m_Weapon.AmmoLeft().ToString();
            }
        }

        public void Initialize(WeaponController weapon, int weaponIndex)
        {
            m_Weapon = weapon;
            WeaponCounterIndex = weaponIndex;
            WeaponImage.sprite = weapon.WeaponIcon;
            BulletCounter.text = m_Weapon.AmmoLeft().ToString();

            m_Ammo = FindObjectOfType<Ammo>();
            TotalAmmo.text = m_Ammo.bulletsLeft(m_Weapon.AmmoType).ToString();

            m_PlayerWeaponsManager = FindObjectOfType<PlayerWeaponsManager>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerWeaponsManager, AmmoCounter>(m_PlayerWeaponsManager, this);

            WeaponIndexText.text = (WeaponCounterIndex + 1).ToString();

            //FillBarColorChange.Initialize(1f, m_Weapon.GetAmmoNeededToShoot());
        }

        void Update()
        {
            BulletCounter.text = m_Weapon.AmmoLeft().ToString();
            TotalAmmo.text = m_Ammo.bulletsLeft(m_Weapon.AmmoType).ToString();

            bool isActiveWeapon = m_Weapon == m_PlayerWeaponsManager.GetActiveWeapon();

            CanvasGroup.alpha = Mathf.Lerp(CanvasGroup.alpha, isActiveWeapon ? 1f : UnselectedOpacity,
                Time.deltaTime * 10);
            transform.localScale = Vector3.Lerp(transform.localScale, isActiveWeapon ? Vector3.one : UnselectedScale,
                Time.deltaTime * 10);
            ControlKeysRoot.SetActive(!isActiveWeapon);
        }

        void Destroy()
        {
            EventManager.RemoveListener<AmmoPickupEvent>(OnAmmoPickup);
        }
    }
}