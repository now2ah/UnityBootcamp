using UnityEngine;

public class CircleMove : MonoBehaviour
{
    public GameObject circle;
    Vector3 pos = new Vector3(5, 0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //circle.transform.position = Vector3.Lerp(circle.transform.position, pos, Time.deltaTime);
        //Debug.Log(Time.deltaTime);

        //circle.transform.position = Vector3.MoveTowards(circle.transform.position, pos, Time.deltaTime);
        //Debug.Log(Time.deltaTime);

        //circle.transform.position = Vector3.Slerp(circle.transform.position, pos, 0.01f);
    }
}
