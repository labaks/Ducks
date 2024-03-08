using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moneyCount;
    public int[] duckLevels;

    void Start()
    {
        duckLevels = new int[DuckLibrary.ducksNames.Length];
        if (!PlayerPrefs.HasKey("Money"))
        {
            CreatePlayerProfile();
        }
        GetPlayerProfile();
    }

    private void CreatePlayerProfile()
    {
        PlayerPrefs.SetFloat("Money", 0f);
        string strLevels = "";
        for (int i = 0; i < duckLevels.Length; i++)
        {
            if (i == duckLevels.Length - 1)
            {
                strLevels += "-1";
            }
            else
            {
                strLevels += "-1,";
            }
        }
        PlayerPrefs.SetString("DuckLevels", strLevels);
    }

    private void GetPlayerProfile()
    {
        moneyCount = PlayerPrefs.GetFloat("Money");

        string[] strLevels = PlayerPrefs.GetString("DuckLevels").Split(',');
        for (int i = 0; i < strLevels.Length; i++)
        {
            duckLevels[i] = Convert.ToInt32(strLevels[i]);
        }
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetFloat("Money", moneyCount);
    }

    public void SaveDuckLevels()
    {
        string result = String.Join(",", duckLevels);
        PlayerPrefs.SetString("DuckLevels", result);
    }
}
