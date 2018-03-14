using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggSelectionMenuGen : MonoBehaviour {

    private GameObject Buy;
    private GameObject Select;
    private GameObject Selected;
    public static int eggShopSelectedNum;

    public void OnClickEgg()
    {
        Buy = GameObject.Find("Buy");
        Select = GameObject.Find("Select");
        Selected = GameObject.Find("Selected");

        //GameObject BackButton = GameObject.Find("SelectBackButton");
        //BackButton.GetComponent<Animator>().enabled = false;
        //BackButton.GetComponent<RectTransform>().sizeDelta = new Vector2(60f, 60f);
        //BackButton.GetComponent<Animator>().enabled = true;

        Buy.GetComponent<TextMeshProUGUI>().fontSize = 60;
        Select.GetComponent<TextMeshProUGUI>().fontSize = 60;
        
        String name = gameObject.name;
        eggShopSelectedNum = Int32.Parse(Regex.Match(name, @"\d+").Value);
        MatchCollection matches = Regex.Matches(name, "[A-Z]([a-z]+)");

        GameObject.Find("Egg").GetComponent<Image>().sprite = EggLoadControl.eggSprites[eggShopSelectedNum];
        GameObject.Find("EggNameText").GetComponent<TextMeshProUGUI>().text = matches[0]+" "+matches[1];

        String price;
        switch(eggShopSelectedNum)
        {
            case 1:
                price = "100";
                break;
            case 2:
                price = "100";
                break;
            case 3:
                price = "150";
                break;
            case 4:
                price = "250";
                break;
            case 5:
                price = "400";
                break;
            default:
                price = "NIL";
                break;

        }
        GameObject.Find("PriceText").GetComponent<TextMeshProUGUI>().text = price;

        if (EggLoadControl.eggsAvailable.Contains(eggShopSelectedNum))
        {
            Buy.SetActive(false);
        }
        
        if (eggShopSelectedNum != EggLoadControl.selectedEgg || !EggLoadControl.eggsAvailable.Contains(eggShopSelectedNum))
        {
            Selected.SetActive(false);
        }

        if (eggShopSelectedNum == EggLoadControl.selectedEgg || !EggLoadControl.eggsAvailable.Contains(eggShopSelectedNum))
        {
            Select.SetActive(false);
        }
        
    }
}
