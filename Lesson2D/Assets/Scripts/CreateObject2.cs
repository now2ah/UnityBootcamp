using UnityEngine;

public class CreateObject2 : MonoBehaviour
{
    public GameObject prefab;

    GameObject square;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        square = Instantiate(prefab);

        Destroy(square, 5.0f);
        Debug.Log("destroyed : " + square.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
