using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckPanelController : MonoBehaviour
{
    public GameObject MenuController;
    public Text MoneyCount;
    public GameObject OrdinaryDuckPanel;
    private float[] Ordinary_Duck_LVL_Prices = { 0f, 50f, 85f, 144.5f, 245.6f, 417.6f, 709.9f, 1206.8f, 2051.7f, 3487.9f, 5929.4f };
    private float[] Ordinary_Duck_Prices = { 1f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2f };
    public int ordinaryDuckLvl;
    PlayerStats stats;
    void Start()
    {
        stats = MenuController.GetComponent<PlayerStats>();
        MoneyCount.text = stats.moneyCount.ToString();
        GetDucksLevels();
        SetDucksPanelsStats();
    }

    void GetDucksLevels()
    {
        if (!PlayerPrefs.HasKey("OrdinaryDuck"))
        {
            PlayerPrefs.SetInt("OrdinaryDuck", 0);
        }
        ordinaryDuckLvl = PlayerPrefs.GetInt("OrdinaryDuck");
    }

    void SaveDucksLevels() {
        PlayerPrefs.SetInt("OrdinaryDuck", ordinaryDuckLvl);
    }

    void SetDucksPanelsStats()
    {
        OrdinaryDuckPanel.transform.Find("InfoPanel/CurrentPrice").GetComponent<Text>().text = Ordinary_Duck_Prices[ordinaryDuckLvl].ToString();
        if (ordinaryDuckLvl < Ordinary_Duck_LVL_Prices.Length)
        {
            OrdinaryDuckPanel.transform.Find("InfoPanel/UbgradePriceBtn/Text").GetComponent<Text>().text = Ordinary_Duck_LVL_Prices[ordinaryDuckLvl + 1].ToString();
            OrdinaryDuckPanel.transform.Find("InfoPanel/NextPrice").GetComponent<Text>().text = Ordinary_Duck_Prices[ordinaryDuckLvl + 1].ToString();
        }
        else
        {
            OrdinaryDuckPanel.transform.Find("InfoPanel/UbgradePriceBtn").gameObject.SetActive(false);
            OrdinaryDuckPanel.transform.Find("InfoPanel/NextPrice").gameObject.SetActive(false);
        }
    }

    public void UpOrdinaryDuckLvl()
    {
        if (stats.moneyCount >= Ordinary_Duck_LVL_Prices[ordinaryDuckLvl + 1])
        {
            stats.moneyCount -= Ordinary_Duck_LVL_Prices[ordinaryDuckLvl + 1];
            ordinaryDuckLvl++;
            SetDucksPanelsStats();
            SaveDucksLevels();
            stats.SaveMoney();
            MoneyCount.text = stats.moneyCount.ToString();
        }
    }
}
