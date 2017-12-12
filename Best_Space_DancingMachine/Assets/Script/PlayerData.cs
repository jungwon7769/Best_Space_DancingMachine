﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData{
    private static PlayerData instance = null;

    public float money;
    public int day;
    public string place;
    public int mapnum;

    private PlayerData()
    {
        mapnum = 0;
        money = 0.0f;
        day = 1;
        place = "동네놀이터"; 
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
