using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CampMenu : MonoBehaviour
{
    public Text civText;
    public int civValue = 1;
    public int civMax = 10;

    public Text foodText;
    public int foodValue;
    public int foodMax = 50;

    public Text waterText;
    public int waterValue;
    public int waterMax = 50;

    public Text campLvlText;
    public int campLvl = 1;

    public Text suppliesText;
    public int suppliesValue;
    public int suppliesMax = 10;

    public GameObject MainCampMenu;
    public GameObject LootMenu;
    public GameObject BuildMenu;

    public Text lootText;

    public Text upgradeText;
    public Button upgradeButton;

    public Text noSuppliesText;

    public Text lostCivText;

    private string[] scenarios = { "Food", "Water", "Citizens", "Supplies" };

    void Start()
    {
        SetFood();
        SetWater();
        SetCivs();
        SetCampLvl();
        SetSupplies();

        InvokeRepeating("FoodLoop", 1.0f, 5.0f);
        InvokeRepeating("WaterLoop", 1.0f, 5.0f);
    }
    void SetFood()
    {
        if (foodValue >= foodMax)
        {
            foodValue = foodMax;
        }

        if (foodValue <= 0)
        {
            foodValue = 0;
            StarveCiv();
        }
        foodText.text = "Food: " + foodValue.ToString() + "/" + foodMax.ToString();
    }

    void SetWater()
    {
        if (waterValue >= waterMax)
        {
            waterValue = waterMax;
        }

        if (waterValue <= 0)
        {
            waterValue = 0;
            StarveCiv();
        }
        waterText.text = "Water: " + waterValue.ToString() + "/" + waterMax.ToString();
    }

    void SetCivs()
    {
        if (civValue >= civMax)
        {
            civValue = civMax;
        }

        if (civValue <= 0)
        {
            PlayerPrefs.SetInt("Food", foodValue);
            PlayerPrefs.SetInt("Water", waterValue);
            PlayerPrefs.SetInt("Supplies", suppliesValue);
            PlayerPrefs.SetInt("Civilians", civValue);
            PlayerPrefs.SetInt("CampLevel", campLvl);
            SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
        }
        civText.text = "Citizens: " + civValue.ToString() + "/" + civMax.ToString();
    }

    void SetCampLvl()
    {
        campLvlText.text = "Camp Level: " + campLvl.ToString();
    }

    void SetSupplies()
    {
        if (suppliesValue >= suppliesMax)
        {
            suppliesValue = suppliesMax;
        }
        suppliesText.text = "Supplies: " + suppliesValue.ToString() + "/" + suppliesMax.ToString();
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
            case 3:
                LootSupplies();
                break;
        }
    }

    void LootFood()
    {
        int lootFound = Random.Range(0, 10);
        lootText.text = "You found " + lootFound.ToString() + " food.";
        foodValue = foodValue + lootFound;
        SetFood();
    }

    void LootWater()
    {
        int lootFound = Random.Range(0, 10);
        lootText.text = "You found " + lootFound.ToString() + " water.";
        waterValue = waterValue + lootFound;
        SetWater();
    }

    void LootCivilians()
    {
        int lootFound = Random.Range(0, 4);
        lootText.text = "You found " + lootFound.ToString() +" civilians.";
        civValue = civValue + lootFound;
        SetCivs();
    }

    void LootSupplies()
    {
        int lootFound = Random.Range(0, 10);
        lootText.text = "You found " + lootFound.ToString() + " supplies.";
        suppliesValue = suppliesValue + lootFound;
        SetSupplies();
    }

    void BuildCamp()
    {
        MainCampMenu.SetActive(false);
        BuildMenu.SetActive(true);

        switch (campLvl)
        {
            case 1:
                upgradeText.text = "Upgrade to level 2";
                if (suppliesValue >= 10)
                {
                    upgradeButton.interactable = true;
                    noSuppliesText.gameObject.SetActive(true);
                    noSuppliesText.text = "Cost: 10";
                }
                else
                {
                    noSuppliesText.gameObject.SetActive(true);
                    noSuppliesText.text = "You need 10 supplies for the next level.";
                }
                break;
            case 2:
                upgradeText.text = "Upgrade to level 3";
                if (suppliesValue >= 20)
                {
                    upgradeButton.interactable = true;
                    noSuppliesText.gameObject.SetActive(true);
                    noSuppliesText.text = "Cost: 20";
                }
                else
                {
                    noSuppliesText.gameObject.SetActive(true);
                    noSuppliesText.text = "You need 20 supplies for the next level.";
                }
                break;
            case 3:
                upgradeText.text = "Upgrade to level 4";
                if (suppliesValue >= 30)
                {
                    upgradeButton.interactable = true;
                    noSuppliesText.gameObject.SetActive(true);
                    noSuppliesText.text = "Cost: 30";
                }
                else
                {
                    noSuppliesText.gameObject.SetActive(true);
                    noSuppliesText.text = "You need 30 supplies for the next level.";
                }
                break;
            case 4:
                upgradeText.text = "You can't upgrade anymore";
                noSuppliesText.gameObject.SetActive(false);
                break;
        }
    }

    void UpgradeCamp()
    {
        upgradeButton.interactable = false;
        int suppliesUsed = campLvl * 10;
        campLvl = campLvl + 1;
        suppliesValue = suppliesValue - suppliesUsed;
        foodMax = foodMax * 2;
        waterMax = waterMax * 2;
        suppliesMax = suppliesMax * 2;
        civMax = civMax * 2;
        SetFood();
        SetWater();
        SetCivs();
        SetSupplies();
        SetCampLvl();
        BuildCamp();
    }

    void FoodLoop()
    {
        int foodDecrease = civValue * 2;
        foodValue = foodValue - foodDecrease;
        SetFood();
    }

    void WaterLoop()
    {
        int waterDecrease = civValue * 4;
        waterValue = waterValue - waterDecrease;
        SetWater();
    }

    void StarveCiv()
    {
        int starveChance = Random.Range(0, 4);
        if (starveChance == 0 || starveChance == 4)
        {
            civValue = civValue - 1;
            SetCivs();
            lostCivText.gameObject.SetActive(true);
            Invoke("notifyDeath", 5f);
        };
    }

    void notifyDeath ()
    {
        lostCivText.gameObject.SetActive(false);
    }

    void BackLoot()
    {
        LootMenu.SetActive(false);
        MainCampMenu.SetActive(true);
    }

    void BackUpgrade()
    {
        BuildMenu.SetActive(false);
        MainCampMenu.SetActive(true);

        if (upgradeButton.interactable)
        {
            upgradeButton.interactable = false;
            noSuppliesText.gameObject.SetActive(false);
        }
    }
}
