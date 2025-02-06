using Unity.VisualScripting;
using UnityEngine;

class Unit
{
    public string unitName;

    public static void UnitAction()
    {
        Debug.Log("Action");
    }

    public void Cry()
    {
        Debug.Log("Cry");
    }
}

public class ClassSample : MonoBehaviour
{
    Unit unit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unit.unitName = "MiniGun";

        unit.Cry();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
