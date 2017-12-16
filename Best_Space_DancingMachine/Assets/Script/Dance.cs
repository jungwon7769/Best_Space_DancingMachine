using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DanceInfo
{
    public int num;         // 댄스 넘버
    public string name;     // 댄스 이름
    public int level;       // 댄스 레벨
    public float price;     // 댄스 가격
    public float priceUP;   // 댄스 가격 강화비율
    public float earn;      // 댄스로 벌수 있는 돈
    public float earnUP;    // 댄스로 벌수있는돈 증가비율
    public float playTime;  // 댄스 재생시간
    
}


public class Dance : MonoBehaviour {

    private static Dance instance = null;

    public GameObject dance_Prefab;     // 생성될 댄스 프리팹
    public GameObject parent_obj;       // 생성될 프리팹 부모
    public List<DanceInfo> danceList;   // 댄스들을 저장할 리스트


    private Dance()
    {
        danceList = new List<DanceInfo>();
        addDanceList();
    }


    public static Dance getInstance()
    {
        if (instance == null)
        {
            instance = new Dance();
        }

        return instance;
    }

    public void Start()
    {
        createPrefab();
    }

    public void createPrefab()
    {
        GameObject item;

        for (int i = 0; i < danceList.Count; i++)
        {
            item = Instantiate(dance_Prefab, parent_obj.transform);
            item.name = "댄스" + item.GetComponent<DanceItem>().num;
            item.transform.localScale = new Vector3(1, 1, 1);
            item.GetComponent<DanceItem>().num = danceList[i].num;
            item.GetComponent<DanceItem>().NAME.text = danceList[i].name;
            item.GetComponent<DanceItem>().LV.text = "Lv. " + danceList[i].level;
            item.GetComponent<DanceItem>().price = danceList[i].price;
            item.GetComponent<DanceItem>().PRICE.text = danceList[i].price.ToString();
            item.GetComponent<DanceItem>().danceLv = danceList[i].level;
            item.GetComponent<DanceItem>().playTime = danceList[i].playTime;
            item.GetComponent<DanceItem>().earn = danceList[i].earn;
            item.GetComponent<DanceItem>().earnUP = danceList[i].earnUP;
            item.GetComponent<DanceItem>().priceUP = danceList[i].priceUP;

        }
    }
    


    public void addDanceList()
    {
       int[] danceLv = new int[2];
       danceLv = PlayerData.getInstance().danceLv;

       addDance(1, "왼쪽비트", danceLv[0], 100, 1.1f, 10, 1.1f, 1f);
       addDance(2, "오른쪽비트", danceLv[1],100, 1.1f, 10, 1.1f, 0.5f);
    }
 

    //댄스종류 추가
    public void addDance(int num, string name,int level, float price, float priceUP, float earn, float earnUP, float playTime)
    {
        DanceInfo dance = new DanceInfo();

        dance.num = num;
        dance.name = name;
        dance.level = level;
        dance.price = price;
        dance.priceUP = priceUP;
        dance.earn = earn;
        dance.earnUP = earnUP;
        dance.playTime = playTime;

        danceList.Add(dance); // 리스트에 추가

    }


}
