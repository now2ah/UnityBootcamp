using UnityEngine;

public class Castle : MonoBehaviour
{
    public float maxHp = 30.0f;
    public float Hp;

    void GetDamage(float damage)
    {
        Hp -= damage;

        if (Hp <= 0){ Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            GetDamage(10.0f);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hp = maxHp;
    }
}
