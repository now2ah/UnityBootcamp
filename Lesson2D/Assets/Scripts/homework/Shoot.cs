using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombTransform;
    public float maxShootSpeed;
    public float shootRatio;
    float shootSpeed;
    

    void LookAt()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - bombTransform.position.x, mousePosition.y - bombTransform.position.y);
        bombTransform.right = direction;
    }

    void Charge()
    {
        if (Input.GetMouseButton(0))
        {
            if (shootSpeed <= maxShootSpeed)
            {
                shootSpeed += 0.05f;
                shootRatio = (shootSpeed / maxShootSpeed) * 100.0f;
            }
        }
    }

    void Fire()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject gO = Instantiate(bombPrefab, bombTransform.position, bombTransform.rotation);
            gO.GetComponent<Rigidbody2D>().linearVelocity = bombTransform.transform.right * shootSpeed;
            shootSpeed = 0;
            shootRatio = 0;
        }
    }

    private void Start()
    {
        shootSpeed = 0;
        shootRatio = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LookAt();
        Charge();
        Fire();
    }
}
