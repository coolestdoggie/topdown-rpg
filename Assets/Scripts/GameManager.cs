using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    public Player player;

    public int pesosAmount;
    public int experienceAmount;
    
    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState")) return;
        
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        
        // TODO: change player skin
        pesosAmount = int.Parse(data[1]);
        experienceAmount = int.Parse(data[2]);
        // TODO: change the weapon level
    }

    public void SaveState()
    {
        string saveSystem = "";

        saveSystem += "0" + "|"; // preferred skin
        saveSystem += pesosAmount.ToString() + "|"; // pesos amount
        saveSystem += experienceAmount.ToString() + "|"; // experience
        saveSystem += "0"; // weapon level
        
        PlayerPrefs.SetString("SaveState", saveSystem);
    }

}
