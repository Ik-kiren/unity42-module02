using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public GameObject endPoint;

    public float Hp = 3;
    public float speed = 0.006f;

    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            GameManager.Instance.ennemies.Remove(gameObject);
            if (GameManager.Instance.currentGold < 5)
                GameManager.Instance.currentGold++;
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, speed * Time.deltaTime);
        if (gameObject.transform.position == endPoint.transform.position)
        {
            GameManager.Instance.ennemies.Remove(gameObject);
            Destroy(gameObject);
            GameManager.Instance.TakeDamage(1);
        }
        if (!GameManager.Instance.gameRunning())
            Destroy(gameObject);
    }
}
