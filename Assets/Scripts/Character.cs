using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Character : MonoBehaviour
{
    public GameObject[] pickupPrefabs;
    public GameObject[] inventoryPrefabs;
    public GameObject inventoryGui;
    public List<InventoryItem> inventory;
    public GameObject GameOverText;

    bool inventoryShown = false;
    static int maxInvSize = 6;
    int invCount = 0;
    string[] itemStrings = new string[3] { "cube", "sphere", "capsule" };

	// Use this for initialization
	void Start ()
    {
        inventory = new List<InventoryItem>();
        //inventory = new InventoryItem[maxInvSize];
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryShown = !inventoryShown;
            inventoryGui.SetActive(inventoryShown);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            DropItem();
        }
    }

    public void AddInventoryItem(string objectToSpawn, int attack, int speed, int defence, Color colour)
    {
        if (invCount < maxInvSize)
        {
            InventoryItem item = new InventoryItem();

            item.objectToSpawn = objectToSpawn;
            item.attack = attack;
            item.speed = speed;
            item.defence = defence;
            item.colour = colour;

            inventory.Add(item);
            //inventory[invCount] = item;
            invCount++;

            UpdateInventory();
        }
    }

    public void RemoveInventoryItem(string itemName)
    {
        if (invCount > 0)
        {
            foreach (InventoryItem item in inventory)
            {
                if (item.objectToSpawn == itemName)
                {
                    inventory.Remove(item);
                    invCount--;
                    UpdateInventory();
                    break;
                }
            }
        }
    }

    public bool IsInventoryFull()
    {
        return invCount >= maxInvSize;
    }


    void UpdateInventory()
    {
        GameObject invSlots = inventoryGui.transform.GetChild(1).gameObject;
        int slotIndex = 0;

        int childCount = invSlots.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = invSlots.transform.GetChild(i);

            if (child.childCount > 0)
            {
                Destroy(child.GetChild(0).gameObject);
            }
        }

        foreach (InventoryItem item in inventory)
        {
            int itemType = System.Array.IndexOf(itemStrings, item.objectToSpawn);
            GameObject slot = invSlots.transform.GetChild(slotIndex).gameObject;

            GameObject invItem = (GameObject)Instantiate(inventoryPrefabs[itemType], slot.transform.position, slot.transform.rotation);
            invItem.transform.SetParent(slot.transform, true);

            slotIndex++;
        }
    }

    void DropItem()
    {
        if (invCount > 0)
        {
            Debug.Log("Dropped");

            string itemName = inventory.First().objectToSpawn;
            RemoveInventoryItem(itemName);

            int index = Array.IndexOf(itemStrings, itemName);
            Instantiate(pickupPrefabs[index], transform.position + (transform.forward * 1.5f) + (transform.up * 0.5f), Quaternion.identity);
        }
    }

    void OnDestroy()
    {
        GameOverText.SetActive(true);
    }

    [System.Serializable]
    public struct InventoryItem
    {
        public string objectToSpawn;
        public int attack;
        public int speed;
        public int defence;
        public Color colour;
    }
}