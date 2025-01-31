using System.Collections;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public GameObject bomb;
    Coroutine deployBombCoroutine;

    IEnumerator DeployBomb()
    {
        while (true)
        {
            yield return null;
        }
    }

    void StartDeployBombCoroutine()
    {
        if (null != deployBombCoroutine)
        {
            StopCoroutine(deployBombCoroutine);
        }
        else if (null == deployBombCoroutine)
        {
            deployBombCoroutine = StartCoroutine(DeployBomb());
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
