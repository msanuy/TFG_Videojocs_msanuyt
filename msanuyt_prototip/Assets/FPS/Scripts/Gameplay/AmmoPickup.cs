using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class AmmoPickup : Pickup
    {
        [Tooltip("Number of pistol bullets the player gets")]
        public int pistolBullets = 0;

        [Tooltip("Number of shotgun bullets the player gets")]
        public int shotgunBullets = 0;

        [Tooltip("Number of rifle bullets the player gets")]
        public int rifleBullets = 0;

        private int diff;
        private int ret;
        private bool picked;
        protected override void OnPicked(PlayerCharacterController player)
        {
            Ammo playerAmmo = player.GetComponent<Ammo>();
            picked = false;

            diff = playerAmmo.MaxPistolBullets - playerAmmo.StartingPistolBullets;
            if (diff != 0 && pistolBullets > 0){
                picked = true;
                ret = Mathf.Min(diff, pistolBullets);
                playerAmmo.giveAmmo(WeaponAmmoType.Pistol, ret);
                pistolBullets -= ret;
            }

            diff = playerAmmo.MaxShotgunBullets - playerAmmo.StartingShotgunBullets;
            if (diff != 0 && shotgunBullets > 0){
                picked = true;
                ret = Mathf.Min(diff, shotgunBullets);
                playerAmmo.giveAmmo(WeaponAmmoType.Shotgun, ret);
                shotgunBullets -= ret;
            }

            diff = playerAmmo.MaxRifleBullets - playerAmmo.StartingRifleBullets;
            if (diff != 0 && rifleBullets > 0){
                picked = true;
                ret = Mathf.Min(diff, rifleBullets);
                playerAmmo.giveAmmo(WeaponAmmoType.Rifle, ret);
                rifleBullets -= ret;
            }

            if (picked) PlayPickupFeedback();
            if (pistolBullets == 0 && shotgunBullets == 0 && rifleBullets == 0) Destroy(gameObject);
            
        }
        
    }
}
