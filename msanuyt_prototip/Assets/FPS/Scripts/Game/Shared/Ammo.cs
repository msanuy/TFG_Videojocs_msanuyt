using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.FPS.Game;

namespace Unity.FPS.Game
{
    public class Ammo : MonoBehaviour
    {

        [Tooltip("Maximum amount of Pistol bullets")]
        public int MaxPistolBullets = 500;
        [Tooltip("Starting amount of Pistol bullets")]
        public int StartingPistolBullets = 200;

        [Tooltip("Maximum amount of Shotgun bullets")]
        public int MaxShotgunBullets = 500;
        [Tooltip("Starting amount of Shotgun bullets")]
        public int StartingShotgunBullets = 200;

        [Tooltip("Maximum amount of Rifle bullets")]
        public int MaxRifleBullets = 1000;
        [Tooltip("Starting amount of Rifle bullets")]
        public int StartingRifleBullets = 600;

        [Tooltip("Maximum amount of Big bullets")]
        public int MaxBigBullets = 200;
        [Tooltip("Starting amount of Big bullets")]
        public int StartingBigBullets = 20;

        private int PistolBullets, ShotgunBullets, RifleBullets, BigBullets;

        // Start is called before the first frame update
        void Start()
        {
            PistolBullets = Mathf.Min(MaxPistolBullets, StartingPistolBullets);
            ShotgunBullets = Mathf.Min(MaxShotgunBullets, StartingShotgunBullets);
            RifleBullets = Mathf.Min(MaxRifleBullets, StartingRifleBullets);
            BigBullets = Mathf.Min(MaxBigBullets, StartingBigBullets);
        }

        public int bulletsLeft(WeaponAmmoType type){
            int ret = 0;
            switch (type){
                case WeaponAmmoType.Pistol:
                ret = PistolBullets;
                break;
                case WeaponAmmoType.Shotgun:
                ret = ShotgunBullets;
                break;
                case WeaponAmmoType.Rifle:
                ret = RifleBullets;
                break;
                case WeaponAmmoType.Big:
                ret = BigBullets;
                break;
            }
            return ret;
        }

        //Depletes a determined ammo type
        //Returns the specified ammount if possible
        //Else returns as much as its left
        public int retrieveAmmo(WeaponAmmoType type, int ammount){
            int ret = 0;
            switch (type){
                case WeaponAmmoType.Pistol:
                ret = Mathf.Min(ammount, PistolBullets);
                PistolBullets -= ret;
                break;
                case WeaponAmmoType.Shotgun:
                ret = Mathf.Min(ammount, ShotgunBullets);
                ShotgunBullets -= ret;
                break;
                case WeaponAmmoType.Rifle:
                ret = Mathf.Min(ammount, RifleBullets);
                RifleBullets -= ret;
                break;
                case WeaponAmmoType.Big:
                ret = Mathf.Min(ammount, BigBullets);
                BigBullets -= ret;
                break;
            }
            return ret;

        }


        //Add the required ammount to a determined ammo pool
        public void giveAmmo(WeaponAmmoType type, int ammount){
            switch (type){
                case WeaponAmmoType.Pistol:
                PistolBullets = Mathf.Min(MaxPistolBullets, PistolBullets+ammount);
                break;
                case WeaponAmmoType.Shotgun:
                ShotgunBullets = Mathf.Min(MaxShotgunBullets, ShotgunBullets+ammount);
                break;
                case WeaponAmmoType.Rifle:
                RifleBullets = Mathf.Min(MaxRifleBullets, RifleBullets+ammount);
                break;
                case WeaponAmmoType.Big:
                BigBullets = Mathf.Min(MaxBigBullets, BigBullets+ammount);
                break;
            }
        }
    }
}
