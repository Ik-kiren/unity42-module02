using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 1;
    public float damage = 0.2f;
    public int cost = 5;
    GameObject currentTarget;
    float timer;
    void Start()
    {
    }

    void OnTriggerStay(Collider col)
    {
        if (GameManager.Instance.ennemies.Count > 0 && col.gameObject.CompareTag("Ennemi"))
        {
            currentTarget = GameManager.Instance.ennemies[0];
            for (int i = 0; i < GameManager.Instance.ennemies.Count; i++)
            {
                if (Vector3.Distance(GameManager.Instance.ennemies[i].transform.position, gameObject.transform.position) < Vector3.Distance(currentTarget.transform.position, gameObject.transform.position))
                    currentTarget = GameManager.Instance.ennemies[i];
            }

            if (timer >= fireRate && currentTarget == col.gameObject)
            {
                GameObject clone;
                clone = Instantiate(bullet, gameObject.transform);
                clone.GetComponent<Bullet>().target = currentTarget;
                clone.GetComponent<Bullet>().damage *= damage;
                timer = 0;
            }
        }
    }

    void Update()
    {
        TMP_Text tmpTxt = gameObject.GetComponentInChildren<TextMeshPro>();
        if (tmpTxt)
            tmpTxt.text = cost.ToString();
        timer += Time.deltaTime;
    }
}
