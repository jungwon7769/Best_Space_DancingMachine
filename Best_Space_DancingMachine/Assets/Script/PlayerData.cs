using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData{

    private static PlayerData instance = null;

    // 플레이어 기본 정보
    public float money;
    public int rock_money;
    public int day;
    public string place;

    public int placeNum;
    public int soundNum;
    public int danceNum;

    public int[] danceLv;
    public bool fever;

    public bool isChange = false;


    private PlayerData()
    {
        placeNum = 0;
        soundNum = 0;
        danceNum = 0;
        money = 0.0f;
        rock_money = 0;
        day = 1;
        place = "동네놀이터";
        fever = false;

        danceLv = new int[2];
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
