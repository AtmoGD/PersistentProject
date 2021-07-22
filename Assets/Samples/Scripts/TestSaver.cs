using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleLibrary;
using System;
using UnityEngine.UI;

[Serializable]
public class TestPlayer
{
    public string name = "";
    public string description = "";
    public float positionX = 0.0f;
    public float positionY = 0.0f;
    public float positionZ = 0.0f;
    public float maxHealth = 0.0f;
    public float healthLeft = 0.0f;

}

public class TestSaver : MonoBehaviour
{
    [SerializeField] private InputField name;
    [SerializeField] private InputField description;
    [SerializeField] private InputField positionX;
    [SerializeField] private InputField positionY;
    [SerializeField] private InputField positionZ;
    [SerializeField] private InputField maxHealth;
    [SerializeField] private InputField healthLeft;
    [SerializeField] private string path = "/player.data";

    private TestPlayer player = new TestPlayer();

    void Start()
    {
        player = LoadData(path);
        if (player == null)
            player = new TestPlayer();
        UpdateUI();


    }

    private void UpdateUI()
    {
        Debug.Log(player.description);
        name.text = player.name;
        description.text = player.description;
        positionX.text = player.positionX.ToString();
        positionY.text = player.positionY.ToString();
        positionZ.text = player.positionZ.ToString();
        maxHealth.text = player.maxHealth.ToString();
        healthLeft.text = player.healthLeft.ToString();
    }

    private void SaveUI()
    {
        player.name = name.text;
        player.description = description.text;
        player.positionX = float.TryParse(positionX.text, out float resultX) ? resultX : player.positionX;
        player.positionY = float.TryParse(positionY.text, out float resultY) ? resultY : player.positionY;
        player.positionZ = float.TryParse(positionZ.text, out float resultZ) ? resultZ : player.positionZ;
        player.maxHealth = float.TryParse(maxHealth.text, out float resultMaxHealth) ? resultMaxHealth : player.maxHealth;
        player.healthLeft = float.TryParse(healthLeft.text, out float resultHealthLeft) ? resultHealthLeft : player.healthLeft;
    }


    public TestPlayer LoadData(string _path)
    {
        return SimpleDataLoader.LoadData<TestPlayer>(_path);
    }

    public void SaveData(TestPlayer _player, string _path)
    {
        SimpleDataLoader.SaveData<TestPlayer>(_player, _path);
    }

    public void DeleteData()
    {
        SimpleDataLoader.DeleteData(path);
    }

    public void OnUIChange()
    {
        SaveUI();
        SaveData(player, path);
    }
}
