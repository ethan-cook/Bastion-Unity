using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour {

    public Text civText;
    public Text foodText;
    public Text waterText;
    public Text campLvlText;
    public Text suppliesText;

    public int foodValue = 0;
    public int waterValue = 0;
    public int suppliesValue = 0;
    public int civValue = 0;
    public int campLvl = 0;

    void Start()
    {
        
        foodValue = PlayerPrefs.GetInt("Food");
        waterValue = PlayerPrefs.GetInt("Water");
        suppliesValue = PlayerPrefs.GetInt("Supplies");
        civValue = PlayerPrefs.GetInt("Civilians");
        campLvl = PlayerPrefs.GetInt("CampLevel");

        foodText.text = "Food: " + foodValue;
        waterText.text = "Water: " + waterValue;
        suppliesText.text = "Supplies: " + suppliesValue;
        civText.text = "Civilians: " + civValue;
        campLvlText.text = "Camp Level: " + campLvl;
    }

    void BacktoMain()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
