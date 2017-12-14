using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Stage
{

}

public class Place {
    private static Place instance = null;

    public int placeNum;

    public List<PlaceInfo> placeList;

    public class PlaceInfo
    {
        public int num; // 맵 넘버
        public string name; // 맵 이름
        public float price; // 맵 가격
    }

    private Place()
    {
        placeNum = 1;
    }

    public static Place getInstance()
    {
        if (instance == null)
        {
            instance = new Place();
        }
        return instance;
    }

    public int getplaceNum() // get place num
    {
        return placeNum;
    }

    public void setplaceNum(int num) // set place num
    {
        placeNum = num;
    }

}
