using System.Collections;
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

    public void money_add_map1()
    {
        money += Time.deltaTime * 1;
        
    }


}
