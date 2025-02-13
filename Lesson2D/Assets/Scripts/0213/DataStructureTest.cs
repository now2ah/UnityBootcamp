using System.Collections.Generic;
using UnityEngine;

public class DataStructureTest : MonoBehaviour
{
    public Queue<string> stringQueue;

    private void Start()
    {
        stringQueue = new Queue<string>();
        stringQueue.Enqueue("first");
        stringQueue.Enqueue("second");
        stringQueue.Enqueue("third");

        int size = stringQueue.Count;
        for (int i=0; i< size; i++)
            Debug.Log(stringQueue.Dequeue());
    }
}
