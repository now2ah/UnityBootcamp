using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class ItemDataSystem : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField descInputField;
    public Button saveButton;
    public Button loadButton;
    public Button deleteButton;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;

    ItemData itemData01;

    bool hasItem;

    void _EndNameEdit(string text)
    {
        if (null != nameInputField)
        {
            nameInputField.text = text;
            itemData01.name = text;
        }
    }

    void _EndDescEdit(string text)
    {
        if (null != descInputField)
        {
            descInputField.text = text;
            itemData01.description = text;
        }
    }

    void _Save()
    {
        PlayerPrefs.SetString("ItemName", itemData01.name);
        PlayerPrefs.SetString("ItemDesc", itemData01.description);
        hasItem = true;
        loadButton.interactable = hasItem;
        Debug.Log("Save complete");
    }

    void _Load()
    {
        itemData01.name = PlayerPrefs.GetString("ItemName");
        itemData01.description = PlayerPrefs.GetString("ItemDesc");
        _ShowData(itemData01.name, itemData01.description);
        Debug.Log("Load complete");
    }

    void _Delete()
    {
        PlayerPrefs.DeleteAll();
        _HideData();
        hasItem = false;
        loadButton.interactable = hasItem;
        Debug.Log("delete complete");
    }

    void _ShowData(string name, string desc)
    {
        if (null != nameText && null != descText)
        {
            nameText.text = name;
            descText.text = desc;
        }
    }

    void _HideData()
    {
        if (null != nameText && null != descText)
        {
            nameText.text = "";
            descText.text = "";
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemData01 = new ItemData();
        hasItem = false;
        nameInputField.onEndEdit.AddListener(_EndNameEdit);
        descInputField.onEndEdit.AddListener(_EndDescEdit);
        saveButton.onClick.AddListener(_Save);
        loadButton.onClick.AddListener(_Load);
        loadButton.interactable = hasItem;
        deleteButton.onClick.AddListener(_Delete);
    }
}
