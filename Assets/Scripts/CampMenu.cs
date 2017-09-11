using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampMenu : MonoBehaviour
{
    public Text civText;
    public int civValue;

    public Text foodText;
    public int foodValue;

    public Text waterText;
    public int waterValue;

    public GameObject MainCampMenu;
    public GameObject LootMenu;

    public Text lootText;

    private string[] scenarios = { "Food", "Water", "Citizens" };

    void Start()
    {
        SetFood();
        SetWater();
        SetCivs();
    }

    void SetFood()
    {
        foodText.text = "Food: " + foodValue.ToString();
    }

    void SetWater()
    {
        waterText.text = "Water: " + waterValue.ToString();
    }

    void SetCivs()
    {
        civText.text = "Citizens: " + civValue.ToString();
    }

    void GoLoot()
    {
        MainCampMenu.SetActive(false);
        LootMenu.SetActive(true);

        int scenarioSelection = Random.Range(0, scenarios.Length);
        switch (scenarioSelection)
        {
            case 0:
                LootFood();
                break;
            case 1:
                LootWater();
                break;
            case 2:
                LootCivilians();
                break;
        }
    }

    void LootFood()
    {
        lootText.text = "You found 1 food.";
        foodValue = foodValue + 1;
        SetFood();
    }

    void LootWater()
    {
        lootText.text = "You found 1 water.";
        waterValue = waterValue + 1;
        SetWater();
    }

    void LootCivilians()
    {
        lootText.text = "You found on 1 civilian";
        civValue = civValue + 1;
        SetCivs();
    }

    void BackMain()
    {
        LootMenu.SetActive(false);
        MainCampMenu.SetActive(true);
    }
}
