using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconAnimControl : MonoBehaviour {

    public GameObject BackButton;
    public GameObject SelectBackButton;
    public GameObject EggShopButton;
    public GameObject LeaderboardButton;
    public GameObject AchievementButton;

    public void revertButtonSize()
    {
        BackButton.GetComponent<Animator>().enabled = false;
        SelectBackButton.GetComponent<Animator>().enabled = false;
        EggShopButton.GetComponent<Animator>().enabled = false;
        LeaderboardButton.GetComponent<Animator>().enabled = false;
        AchievementButton.GetComponent<Animator>().enabled = false;

        BackButton.GetComponent<RectTransform>().sizeDelta = new Vector2(60f, 60f);
        SelectBackButton.GetComponent<RectTransform>().sizeDelta = new Vector2(60f, 60f);
        EggShopButton.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 150f);
        LeaderboardButton.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 150f);
        AchievementButton.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 150f);

        BackButton.GetComponent<Animator>().enabled = true;
        SelectBackButton.GetComponent<Animator>().enabled = true;
        EggShopButton.GetComponent<Animator>().enabled = true;
        LeaderboardButton.GetComponent<Animator>().enabled = true;
        AchievementButton.GetComponent<Animator>().enabled = true;
    }
}
