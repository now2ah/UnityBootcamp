using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.IO;
using Unity.Properties;

public class Weapon
{
    public int level;

    public Weapon(int level)
    {
        this.level = level;
    }
}

public class EnchantSystem : MonoBehaviour
{
    public Button upgradeButton;
    public Button saveButton;
    public Button loadButton;
    public TextMeshProUGUI tierText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI chanceText;
    Weapon _weapon;
    int _lotteryNum;
    float _maxChanceNum = 10000f;
    float _chanceNum;
    float _chance;

    public SavedItem savedItem;

    void _UpgradeWeapon()
    {
        _lotteryNum = Random.Range(0, (int)_maxChanceNum);
        _chanceNum = _weapon.level * 1000;
        _chance = (_maxChanceNum - _chanceNum) / _maxChanceNum * 100;

        if (_lotteryNum > _chanceNum)
        {
            _Success();
        }
        else
        {
            _Fail();
        }
        _SetText();
    }

    void _Success()
    {
        _weapon.level++;
    }

    void _Fail()
    {
        _weapon.level = 1;
    }

    void _SetText()
    {
        if (_weapon.level >= 0 && _weapon.level < 4)
        {
            tierText.text = "Common";
            tierText.color = Color.black;
            levelText.color = Color.black;
        }
        else if (_weapon.level >= 4 && _weapon.level < 7)
        {
            tierText.text = "Rare";
            tierText.color = Color.blue;
            levelText.color = Color.blue;
        }
        else if (_weapon.level >= 7 && _weapon.level < 10)
        {
            tierText.text = "Unique";
            tierText.color = Color.magenta;
            levelText.color = Color.magenta;
        }
        else
        {
            tierText.text = "Epic";
            tierText.color = Color.yellow;
            levelText.color = Color.yellow;
        }

        levelText.text = "+ " + _weapon.level.ToString();

        chanceText.text = _chance.ToString("N2") + "%";
    }

    void _Save()
    {
        savedItem._weapon = _weapon;
        savedItem.SetText();
        //PlayerPrefs.SetInt("level", _weapon.level);
        string jsonString = JsonUtility.ToJson(savedItem._weapon);
        File.WriteAllText(Application.dataPath + "/weapon.json", jsonString);
        loadButton.interactable = true;
    }

    void _Load()
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/weapon.json");
        savedItem._weapon = JsonUtility.FromJson<Weapon>(jsonString);
        savedItem.SetText();
        //savedItem._weapon.level = PlayerPrefs.GetInt("level");
        _weapon = savedItem._weapon;
        _SetText();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upgradeButton.onClick.AddListener(_UpgradeWeapon);
        saveButton.onClick.AddListener(_Save);
        loadButton.onClick.AddListener(_Load);
        _weapon = new Weapon(1);
        _chance = 100;
        _SetText();
    }

    private void OnDestroy()
    {
        //PlayerPrefs.DeleteAll();
    }
}
