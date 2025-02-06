using TMPro;
using UnityEngine;

public class SavedItem : MonoBehaviour
{
    public TextMeshProUGUI tierText;
    public TextMeshProUGUI levelText;
    public Weapon _weapon;

    public void SetText()
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
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
