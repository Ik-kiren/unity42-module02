using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    Vector3 tmpPosition;

    public float damage = 1f;
    public float bulletSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        tmpPosition = target.transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ennemi"))
        {
            target.GetComponent<Ennemi>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!target || !GameManager.Instance.gameRunning())
            Destroy(gameObject);
        else
            tmpPosition = target.transform.position;
        transform.position = Vector3.MoveTowards(gameObject.transform.position, tmpPosition, bulletSpeed * Time.deltaTime);
    }
}
