using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{

    
    public class WeaponSwitch : MonoBehaviour
    {
        int weaponSelected = 1;

        [SerializeField]
        GameObject primary, secondary, primaryUI, secondaryUI;

      

        private PlayerInputActions InputActions; 

        private void Awake()
        {
            InputActions = new PlayerInputActions();
        }

        private void OnSwapInventoryWeapon(Input value)
        {

           
        }

        //private void Update()
        //{
        //    if(Input.GetKeyDown(KeyCode.Alpha1))
        //    {

        //    }

        //    if (Input.GetKeyDown(KeyCode.Alpha1))
        //    {

        //    }
        //}

        void SwapWeapon(int weaponType)
        {
            if (weaponType == 1)
            {
                primary.SetActive(true);
                secondary.SetActive(false);
                primaryUI.SetActive(true);
                secondaryUI.SetActive(false);
                //weaponSelected = 2;
            }

            if (weaponType == 2)
            {
                primary.SetActive(false);
                secondary.SetActive(true);
                primaryUI.SetActive(false);
                secondaryUI.SetActive(true);

            }
        }

        

        private void OnEnable()
        {
            //InputActions.Enable();
            InputActions.PlayerActionMap.PrimaryInventoryWeapon.performed += HandlePrimaryInv;
            InputActions.PlayerActionMap.PrimaryInventoryWeapon.Enable();

            InputActions.PlayerActionMap.SecondaryInventoryWeapon.performed += HandleSecondaryInv; ;
            InputActions.PlayerActionMap.SecondaryInventoryWeapon.Enable();
        }

        private void HandleSecondaryInv(InputAction.CallbackContext obj)
        {
            weaponSelected = 2;
            if (weaponSelected == 2)
            {
                Debug.Log("2 Pressed");
                SwapWeapon(2);
            }
            weaponSelected = 1;

        }

        private void HandlePrimaryInv(InputAction.CallbackContext context)
        {
            weaponSelected = 1;
            Debug.Log(weaponSelected);
            if (weaponSelected == 1)
            {
                SwapWeapon(1);
                //Debug.Log("1 Pressed");
            }

            weaponSelected = 2;

        }

        private void OnDisable()
        {
           // InputActions.Disable();
            InputActions.PlayerActionMap.PrimaryInventoryWeapon.performed -= HandlePrimaryInv;
            InputActions.PlayerActionMap.PrimaryInventoryWeapon.Disable();

            InputActions.PlayerActionMap.SecondaryInventoryWeapon.performed -= HandleSecondaryInv;
            InputActions.PlayerActionMap.SecondaryInventoryWeapon.Disable();
        }
    }

  
}
