using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


namespace Weapons
{

    public enum WeaponType
    {
        None,
        Pistol,
        MachineGun
    }

    [Serializable]
    public struct WeaponStats
    {
        public WeaponType WeaponType;
        public string WeaponName;
        public float Damage;
        public int BulletsInClip;
        public int ClipSize;
        public int BulletsAvailable;
        public float FireStartDelay;
        public float FireRate;
        public float FireDistance;
        public bool Repeating;
        public LayerMask WeaponHitLayers;
    }

    public class PrimaryWeapon : MonoBehaviour
    {
       public float Damage = 10.0f;
        public float range = 100.0f;

        private PlayerInputActions InputActions;
        private RaycastHit hitLocation;
        public Camera cam;


        private void Awake()
        {
            InputActions = new PlayerInputActions();
            cam = new Camera();
        }

        private void OnEnable()
        {
            InputActions.PlayerActionMap.Fire.Enable();
            InputActions.PlayerActionMap.Fire.performed += Shoot;

        }

        private void OnDisable()
        {
            InputActions.PlayerActionMap.Fire.Disable();
            InputActions.PlayerActionMap.Fire.performed -= Shoot;
        }
        private void Shoot(InputAction.CallbackContext obj)
        {
            //Debug.Log("Shoot");
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(Damage);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}