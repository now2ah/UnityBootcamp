using UnityEngine;

public class SOTest : MonoBehaviour
{
    public Item item;
    public EventSO eventTest;

    void _ShowItemInfo()
    {
        if (null != item)
            Debug.Log("id : " + item.itemId + ", name : " + item.itemName + ", desc : " + item.itemDesc);
    }

    void _OnEvent(string name)
    {
        Debug.Log("item name is " + name);
        GameObject prefab = item.itemPrefab;
        Instantiate(prefab);
    }

    void Start()
    {
        eventTest.OnEvent += _OnEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            eventTest.DoInvoke(item.itemName);

        if (Input.GetKeyDown(KeyCode.Space))
            _ShowItemInfo();
    }
}
