using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject ennemi;
    public GameObject endPoint;

    float timer = 0;
    public float spawnTime = 2;
    public float ennemiPower = 1;
    float startSpawnTimer = 0;
    public float startSpawnTime = 0;
    bool startSpawnBool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startSpawnTimer += Time.deltaTime;
        if (startSpawnTimer >= startSpawnTime && !startSpawnBool)
        {
            startSpawnBool = true;
        }
        if (startSpawnBool)
        {
            if (GameManager.Instance.ennemiSpawned == GameManager.Instance.numbersEnnemiToSpawn && GameObject.Find("Ennemi(Clone)") == null && GameManager.Instance.hasLost == false && GameManager.Instance.hasWon == false)
            {
                GameManager.Instance.WonStage();
            }
            if (GameManager.Instance.ennemiSpawned < GameManager.Instance.numbersEnnemiToSpawn)
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
                    GameManager.Instance.ennemiSpawned++;
                    timer = 0;
                }
            }
        }
    }
}
