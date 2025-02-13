using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public GameObject itemPrefab;

    public int itemId;
    public string itemName;
    public string itemDesc;
}
