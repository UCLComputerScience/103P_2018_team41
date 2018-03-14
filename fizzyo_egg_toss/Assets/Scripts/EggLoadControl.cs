using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggLoadControl : MonoBehaviour {

    public static Sprite[] eggSprites;
    public static ArrayList eggsAvailable = new ArrayList();
    public static int selectedEgg = 0;
    public GameObject Select;
    public GameObject Selected;

    // Use this for initialization
    void Awake () {
        eggSprites = Resources.LoadAll<Sprite>("Sprites/Eggs");
        if (!eggsAvailable.Contains(0))
        {
            eggsAvailable.Add(0);
        }
    }

    public void BuyEgg()
    {
        eggsAvailable.Add(EggSelectionMenuGen.eggShopSelectedNum);
        gameObject.SetActive(false);
        Select.SetActive(true);
    }

    public void SelectEgg()
    {
        selectedEgg = EggSelectionMenuGen.eggShopSelectedNum;
        gameObject.SetActive(false);
        Selected.SetActive(true);
    }

    public static Sprite returnSelectedEggSprite()
    {
        return eggSprites[selectedEgg];
    }
}
