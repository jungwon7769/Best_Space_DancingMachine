using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceInfo
{
    public int num;
    public string name;
    public string effect;
    public int price;
    public float benefit;
}

public class Place : MonoBehaviour {

    private static Place instance = null;

    public GameObject place_Prefab;
    public GameObject parent_obj;

    public List<PlaceInfo> placeList;

    public Image map;
    public Sprite map1, map2,map3;


    private Place()
    {
        placeList = new List<PlaceInfo>();
        addList();
    }

    public static Place getInstance()
    {
        if (instance == null)
            instance = new Place();

        return instance;
    }

    public void Start()
    {
        create_Item(place_Prefab, placeList);

    }

    public void Update()
    {
        mapChange();
    }


    public void create_Item(GameObject prefab, List<PlaceInfo> list)
    {
        GameObject item;

        for (int i = 0; i < list.Count; i++)
        {
            item = Instantiate(prefab, parent_obj.transform); // 생성
            item.transform.localScale = new Vector3(1, 1, 1); // 스케일 설정
            item.GetComponent<PlaceItem>().num = list[i].num;
            item.GetComponent<PlaceItem>().name = list[i].name;
            item.GetComponent<PlaceItem>().effect = list[i].effect;
            item.GetComponent<PlaceItem>().price = list[i].price;
            item.GetComponent<PlaceItem>().benefit = list[i].benefit;

            item.GetComponent<PlaceItem>().Name.text = list[i].name;
            item.GetComponent<PlaceItem>().Effect.text = list[i].effect;
            item.GetComponent<PlaceItem>().Price.text = ((int)list[i].price).ToString();
        }

    }

    public void mapChange()
    {
        switch (PlayerData.getInstance().placeNum)
        {
            case 1: map.sprite = map1; break;
            case 2: map.sprite = map2; break;
            case 3: map.sprite = map3; break;
        }

    }

    public void addList()
    {
        addPlace(1, "동네놀이터", "효과없음", 0, 1.0f);
        addPlace(2, "홍대 걷고싶은거리", "피버 돌멩이양 1.5배 증가", 300, 1.5f);

    }

    public void addPlace(int num, string name, string effect, int price, float benefit)
    {
        PlaceInfo Place_ = new PlaceInfo();

        Place_.num = num;
        Place_.name = name;
        Place_.effect = effect;
        Place_.price = price;
        Place_.benefit = benefit;

        placeList.Add(Place_);

    }

}
