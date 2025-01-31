using UnityEngine;

public class CreateObject3 : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    int dummy;

    [SerializeField]
    GameObject sample;

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/TableBody");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sample = Instantiate(prefab);
            sample.AddComponent<VectorSample>();
        }
    }
}
