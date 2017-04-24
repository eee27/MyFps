using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    [SerializeField]
    private GameObject bagItem;

    [SerializeField]
    private GameObject itemPrefab;

    [SerializeField]
    private Sprite[] sprites = new Sprite[5];//0-空,1-金葫芦,2-瓶,3-洗点,4乾坤壶

    private GameObject[] itemList = new GameObject[20];//实例后每个Button的指针
    private List<int> itemKinds = new List<int>();//物品种类,对应图片种类
    private List<int> itemNums = new List<int>();//物品的叠加数

    private string bagItemPrefabName = "Prefab/BagItemButton";

    private void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            itemList[i] = Instantiate(Resources.Load(bagItemPrefabName), bagItem.transform, false) as GameObject;

            int _i = i;
            itemList[_i].GetComponent<Button>().onClick.AddListener(delegate ()
            {
                UseItem(_i);
            });

            itemKinds.Add(0);
            itemNums.Add(0);

            LoadItemImage(i, 0, 0);
        }
    }

    private void Start()
    {
        TestAddItem();
    }

    private void Update()
    {
    }

    private void OnEnable()
    {
        GlobalData.isUi = true;
    }

    private void OnDisable()
    {
        GlobalData.isUi = false;
    }

    /*----------------------------------------------------------*/

    private void TestAddItem()
    {
        LoadItemImage(0, 1, 5);
        LoadItemImage(1, 2, 2);
        LoadItemImage(2, 3, 3);
        LoadItemImage(3, 4, 4);
    }

    private void LoadItemImage(int itemListNum, int itemKind, int itemNum)//根据物品种类,数量,修改对应格
    {
        itemList[itemListNum].GetComponent<Image>().sprite = sprites[itemKind];
        itemNums[itemListNum] = itemNum;
        itemKinds[itemListNum] = itemKind;

        itemKinds[itemListNum] = itemKind;
        itemNums[itemListNum] = itemNum;
        if (itemNum > 1)
        {
            itemList[itemListNum].transform.FindChild("Num").GetComponent<Text>().text = itemNum.ToString();
        }
        else
        {
            itemList[itemListNum].transform.FindChild("Num").GetComponent<Text>().text = null;
        }
    }

    private void LoadItemImage(int itemListNum)//在对应格已有物品情况下更新
    {
        int itemCurrentNum = itemNums[itemListNum];
        if (itemCurrentNum > 1)
        {
            itemList[itemListNum].transform.FindChild("Num").GetComponent<Text>().text = itemCurrentNum.ToString();
        }
        else
        {
            itemList[itemListNum].transform.FindChild("Num").GetComponent<Text>().text = "";
        }
        if (itemCurrentNum == 0)
        {
            itemList[itemListNum].GetComponent<Image>().sprite = sprites[0];
        }
    }

    private void AddItem(int itemKind, int itemNum)
    {
    }

    private void UseItem(int itemListNum)
    {
        switch (itemKinds[itemListNum])
        {
            case 1: { GlobalData.blood += 10; break; }
            case 2: { /*armor*/ break; }
            case 3: { GlobalData.playerScore += 1000; break; }
            case 4: { GlobalData.playerDamageRate += 1f; break; }
        }

        if (itemNums[itemListNum] >= 1)
        {
            itemNums[itemListNum] -= 1;
            LoadItemImage(itemListNum);
        }
    }
}