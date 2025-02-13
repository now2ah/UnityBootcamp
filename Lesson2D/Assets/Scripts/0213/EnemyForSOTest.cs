using UnityEngine;

public class EnemyForSOTest : MonoBehaviour
{
    public DropTable dropTable;

    void _Die()
    {
        _DropItem();
        Destroy(gameObject);
    }

    void _DropItem()
    {
        GameObject dropItemPrefab = dropTable.itemList[Random.Range(0, dropTable.itemList.Count)];

        Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            _Die();
    }
}
