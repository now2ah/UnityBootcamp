using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text cannonText;
    public Text castleText;
    public Shoot shootScript;
    public Castle castleScript;

    void ShowCannonUI()
    {
        if (cannonText != null && shootScript != null)
        {
            cannonText.text = shootScript.shootRatio.ToString("N2") + "%";
        }
    }

    void ShowCastleUI()
    {
        if (castleText != null)
        {
            castleText.text = castleScript.Hp.ToString("N0") + "/" + castleScript.maxHp.ToString("N0");
        }
    }

    private void Update()
    {
        ShowCannonUI();
        ShowCastleUI();
    }
}
