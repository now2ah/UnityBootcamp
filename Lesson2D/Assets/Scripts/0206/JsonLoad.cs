
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("ItemListWrap");
        ItemListWrap itemWrap = JsonUtility.FromJson<ItemListWrap>(textAsset.text);

        foreach (var item in itemWrap.itemDatas)
        {
            Debug.Log(item.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
