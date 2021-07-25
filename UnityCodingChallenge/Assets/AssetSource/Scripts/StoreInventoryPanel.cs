using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreInventoryPanel : MonoBehaviour
{
    public static bool isPaused;

    public GameObject storeInventoryPanel;
    public Text coinsCount;
    public Text grassCount;
    public Text flowerCount;
    public Text shrubCount;

    private GameObject player;
    private Player pScript;

    void Start()
    {
        storeInventoryPanel.SetActive(false);
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        pScript = player.GetComponent<Player>();
    }

    void OnMouseDown()
    {
        Pause();
    }

    public void Resume()
    {
        isPaused = false;
        storeInventoryPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        isPaused = true;
        storeInventoryPanel.SetActive(true);
        Time.timeScale = 0f;  
        coinsCount.text = pScript.getMoney().ToString();
        grassCount.text = pScript.getInventory()[0].ToString();
        flowerCount.text = pScript.getInventory()[1].ToString();
        shrubCount.text = pScript.getInventory()[2].ToString();
    }

    public void BuyGrass()
    {
        if (15 < pScript.getMoney())
        {
            pScript.setMoney((pScript.getMoney() - 15));
            pScript.addInventory(0, 1);
            coinsCount.text = pScript.getMoney().ToString();
        }
    }

    public void BuyFlower()
    {
        if (15 < pScript.getMoney())
        {
            pScript.setMoney((pScript.getMoney() - 35));
            pScript.addInventory(1, 1);
            coinsCount.text = pScript.getMoney().ToString();
        }
    }

    public void BuyShrub()
    {
        if (15 < pScript.getMoney())
        {
            pScript.setMoney((pScript.getMoney() - 50));
            pScript.addInventory(2, 1);
            coinsCount.text = pScript.getMoney().ToString();
        }
    }
}
