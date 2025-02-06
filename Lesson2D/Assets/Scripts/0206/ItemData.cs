using System.Collections.Generic;
using System;
using UnityEngine;


[Serializable]
public class ItemListWrap
{
    public List<ItemData> itemDatas;
}


[Serializable]
public class ItemData
{
    public string name;
    [TextArea] public string description;
}
