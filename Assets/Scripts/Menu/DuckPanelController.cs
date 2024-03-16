using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckPanelController : MonoBehaviour
{
    public GameObject MenuController;
    public Text MoneyCount;
    public GameObject DuckPanelList;
    public GameObject DuckPanelPrefab;

    public Sprite[] duckImages;
    PlayerStats stats;
    void Start()
    {
        stats = MenuController.GetComponent<PlayerStats>();
        MoneyCount.text = stats.moneyCount.ToString();
        InitDuckPanelList();
        SetDucksPanelsStats();
    }

    void InitDuckPanelList()
    {
        for (int i = 0; i < stats.duckLevels.Length; i++)
        {
            int panelNumber = i;
            GameObject newPanel = Instantiate(DuckPanelPrefab, DuckPanelList.transform);
            newPanel.transform.Find("DuckName").GetComponent<Text>().text = DuckLibrary.ducksNames[panelNumber];
            newPanel.transform.Find("ImgPanel/DuckImg").GetComponent<Image>().sprite = duckImages[panelNumber];
            newPanel.transform.Find("InfoPanel/UbgradePriceBtn").GetComponent<Button>().onClick.AddListener(delegate { UpDuckLvl(panelNumber); });
        }
    }

    void SetDucksPanelsStats()
    {
        for (int i = 0; i < DuckPanelList.transform.childCount; i++)
        {
            if (stats.duckLevels[i] < 0)
            {
                DuckPanelList.transform.GetChild(i).transform.Find("InfoPanel/OpenPanel").gameObject.SetActive(true);
                DuckPanelList.transform.GetChild(i).transform.Find("InfoPanel/OpenPanel/OpenBtn/OpenPrice").GetComponent<Text>().text = DuckLibrary.Duck_LVL_Prices[i, 0].ToString();
                int panelNumber = i;
                DuckPanelList.transform.GetChild(i).transform.Find("InfoPanel/OpenPanel/OpenBtn").GetComponent<Button>().onClick.AddListener(delegate { UpDuckLvl(panelNumber); });
            }
            else
            {
                DuckPanelList.transform.GetChild(i).transform.Find("InfoPanel/OpenPanel").gameObject.SetActive(false);
                DuckPanelList.transform.GetChild(i).transform.Find("InfoPanel/CurrentPrice").GetComponent<Text>().text = DuckLibrary.Duck_Prices[i, stats.duckLevels[i]].ToString();
                DuckPanelList.transform.GetChild(i).transform.Find("InfoPanel/DuckLevel").GetComponent<Text>().text = stats.duckLevels[i].ToString();
                if (stats.duckLevels[i] < DuckLibrary.Duck_LVL_Prices.GetLength(1))
                {
                    DuckPanelList.transform.GetChild(i).transform.Find("InfoPanel/UbgradePriceBtn/Text").GetComponent<Text>().text = DuckLibrary.Duck_LVL_Prices[i, stats.duckLevels[i] + 1].ToString();
                    DuckPanelList.transform.GetChild(i).transform.Find("InfoPanel/NextPrice").GetComponent<Text>().text = DuckLibrary.Duck_Prices[i, stats.duckLevels[i] + 1].ToString();
                }
                else
                {
                    DuckPanelList.transform.GetChild(i).transform.Find("InfoPanel/UbgradePriceBtn").gameObject.SetActive(false);
                    DuckPanelList.transform.GetChild(i).transform.Find("InfoPanel/NextPrice").gameObject.SetActive(false);
                }
            }
        }
    }

    void UpDuckLvl(int panelNumber)
    {
        if (stats.moneyCount >= DuckLibrary.Duck_LVL_Prices[panelNumber, stats.duckLevels[panelNumber] + 1])
        {
            stats.moneyCount -= DuckLibrary.Duck_LVL_Prices[panelNumber, stats.duckLevels[panelNumber] + 1];
            stats.duckLevels[panelNumber]++;
            SetDucksPanelsStats();
            stats.SaveDuckLevels();
            stats.SaveMoney();
            MoneyCount.text = stats.moneyCount.ToString();
        }
    }

    void OpenDuck(int panelNumber)
    {

    }
}
