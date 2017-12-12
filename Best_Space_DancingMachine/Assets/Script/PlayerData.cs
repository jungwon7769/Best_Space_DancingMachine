using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData{
    private static PlayerData instance = null;

    public float money;
    public int day;

    private PlayerData()
    {
        money = 0.0f;
        day = 1;
        //초기화
    }

    public static PlayerData getInstance()
    {
        if (instance == null)
        {
            instance = new PlayerData();
        }
        return instance;
    }
}
