using System.Collections;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public GameObject bomb;
    [SerializeField]
    float bombInterval = 2.0f;
    Coroutine deployBombCoroutine;

    IEnumerator DeployBomb()
    {
        while (true)
        {
            float xPos = Random.Range(-5, 5);
            Instantiate<GameObject>(bomb, new Vector3(xPos, 4, 0), Quaternion.identity);
            yield return new WaitForSeconds(bombInterval);
        }
    }

    void StartDeployBombCoroutine()
    {
        if (null == deployBombCoroutine)
        {
            deployBombCoroutine = StartCoroutine(DeployBomb());
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartDeployBombCoroutine();
    }
}
