using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DanceInfo
{
    public int num;
    public string name;
    public string effect;
    public int price;
    public float priceUP;
    public int earn;
    public float earnUP;
    public float playTime;
    
}


public class Dance : MonoBehaviour {

    private static Dance instance = null;

    public GameObject dance_Prefab;     // 생성될 댄스 프리팹
    public GameObject parent_obj;       // 생성될 프리팹 부모
    public List<DanceInfo> danceList;   // 댄스들을 저장할 리스트


    private Dance()
    {
        danceList = new List<DanceInfo>();
        addList();
    }


    public static Dance getInstance()
    {
        if (instance == null)
            instance = new Dance();

        return instance;
    }

    public void Start()
    {
        create_Item(dance_Prefab, danceList);

    }

    public void create_Item(GameObject prefab, List<DanceInfo> list)
    {
        GameObject item;

        for (int i = 0; i < list.Count; i++)
        {
            item = Instantiate(prefab, parent_obj.transform); // 생성
            item.transform.localScale = new Vector3(1, 1, 1); // 스케일 설정
            item.GetComponent<DanceItem>().num = list[i].num;
            item.GetComponent<DanceItem>().name = list[i].name;
            item.GetComponent<DanceItem>().effect = list[i].effect;
            item.GetComponent<DanceItem>().price = list[i].price;
            item.GetComponent<DanceItem>().priceUP = list[i].priceUP;
            item.GetComponent<DanceItem>().earn = list[i].earn;
            item.GetComponent<DanceItem>().earnUP = list[i].earnUP;
            item.GetComponent<DanceItem>().playTime = list[i].playTime;

            item.GetComponent<DanceItem>().Name.text = list[i].name;
            item.GetComponent<DanceItem>().Effect.text = list[i].effect;
            item.GetComponent<DanceItem>().Price.text = money_view_change(list[i].price);
        }

    }


    public string money_view_change(int money)
    {

        if (money >= 10000)
        {
            if (money >= 100000000)
                return (money / 10000000) + "b";

            else
                return (money / 10000) + "a";
        }
        else
            return money.ToString();
    }

    public void addList()
    {
        addDance(1, "왼쪽으로 비트", money_view_change(10), 100, 1.1f, 10, 1.1f, 0.5f);
        addDance(2, "소원을말해봐 춤", money_view_change(10000), 100, 1.1f, 10, 1.1f, 1f);
    }

    public void addDance(int num, string name, string effect, int price, float priceUP, int earn, float earnUP, float playTime)
    {
        DanceInfo Dance_ = new DanceInfo();

        Dance_.num = num;
        Dance_.name = name;
        Dance_.effect = effect;
        Dance_.price = price;
        Dance_.priceUP = priceUP;
        Dance_.earn = earn;
        Dance_.earnUP = earnUP;
        Dance_.playTime = playTime;

        danceList.Add(Dance_);

    }


}
