using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moneyCount;
    public int[] duckLevels;

    void Start()
    {
        duckLevels = new int[5];
        if (!PlayerPrefs.HasKey("Money"))
        {
            CreatePlayerProfile();
        }
        GetPlayerProfile();
    }

    private void CreatePlayerProfile()
    {
        PlayerPrefs.SetFloat("Money", 0f);
        PlayerPrefs.SetInt("OrdinaryDuck", 0);
    }

    private void GetPlayerProfile()
    {
        moneyCount = PlayerPrefs.GetFloat("Money");
        duckLevels[0] = PlayerPrefs.GetInt("OrdinaryDuck");
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetFloat("Money", moneyCount);
    }
}
