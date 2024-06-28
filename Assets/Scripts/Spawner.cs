using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject ennemi;
    public GameObject endPoint;

    float timer = 0;
    public float spawnTime = 2;
    public int ennemiNumber = 10;
    public float ennemiPower = 1;
    int ennemiSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemiSpawned == ennemiNumber && GameObject.Find("Ennemi(Clone)") == null && GameManager.Instance.hasLost == false && GameManager.Instance.hasWon == false)
        {
            GameManager.Instance.WonStage();
        }
        if (ennemiSpawned < ennemiNumber)
        {
            timer += Time.deltaTime;
            if (timer >= spawnTime && GameManager.Instance.gameRunning())
            {
                GameObject clone;
                clone = Instantiate(ennemi);
                clone.transform.position = gameObject.transform.position;
                clone.gameObject.GetComponent<Ennemi>().Hp *= ennemiPower;
                clone.gameObject.GetComponent<Ennemi>().endPoint = endPoint;
                GameManager.Instance.ennemies.Add(clone);
                ennemiSpawned++;
                timer = 0;
            }
        }
    }
}
