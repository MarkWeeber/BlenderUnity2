using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    [SerializeField] private Animator animator = null;
    [SerializeField] private GameObject[] weaponsInventory = null;
    private string inputKey;
    private int activeInventoryWeapon = 0;
    private int inventorySize = 0;

    private void Start()
    {
        inventorySize = weaponsInventory.Length;
    }

    private void Update()
    {
        // tracking 1-5 pressed keys
        inputKey = Input.inputString;
        if(!string.IsNullOrEmpty(inputKey))
        {
            switch (inputKey)
            {
                case "1":
                    animator.SetTrigger("Melee 1");
                    break;
                case "2":
                    animator.SetTrigger("Melee 2");
                    break;
                case "3":
                    animator.SetTrigger("Block");
                    break;
                case "4":
                    animator.SetTrigger("Taunt");
                    break;
                case "5":
                    animator.SetTrigger("Jump");
                    break;
                default:
                    break;
            }
        }
        // tracking mouse wheel
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(activeInventoryWeapon >= inventorySize - 1)
            {
                activeInventoryWeapon = 0;
            }
            else
            {
                activeInventoryWeapon++;
            }
            RefreshWeapons();
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (activeInventoryWeapon <= 0)
            {
                activeInventoryWeapon = inventorySize - 1;
            }
            else
            {
                activeInventoryWeapon--;
            }
            RefreshWeapons();
        }
    }

    private void RefreshWeapons()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if(activeInventoryWeapon == i)
            {
                weaponsInventory[i].SetActive(true);
            }
            else
            {
                weaponsInventory[i].SetActive(false);
            }
        }
    }
}
