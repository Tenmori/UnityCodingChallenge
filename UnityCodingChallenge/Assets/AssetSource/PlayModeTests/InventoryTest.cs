using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTest
{
    private GameObject player;
    private Player pScript;

    [Test]
    public void Inventory_Test()
    {
        player = GameObject.Instantiate(new GameObject());
        pScript = player.AddComponent<Player>();

        int[] expectedInventory = new int[3];
        expectedInventory[0] = 0;
        expectedInventory[1] = 0;
        expectedInventory[2] = 0;

        int[] inventory = pScript.getInventory();

        Assert.That(inventory, Is.EqualTo(expectedInventory));
        Assert.That(inventory[0], Is.EqualTo(expectedInventory[0]));
        Assert.That(inventory[0], Is.EqualTo(expectedInventory[1]));
        Assert.That(inventory[0], Is.EqualTo(expectedInventory[2]));
    }
}
