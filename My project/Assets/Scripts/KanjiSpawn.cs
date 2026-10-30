using UnityEngine;

public class KanjiSpawn : MonoBehaviour
{
    [SerializeField] private int MaxSpawnCount;
    public GameObject[] kanjiPrefabs;
    public GameObject[] kanjiSpawners;
    [SerializeField] private GameObject prefabToSpawn;

    void Start()
    {
        // 1. 位置と回転を指定してスポーンする場合
        //Instantiate(prefabToSpawn, new Vector3(0, 0, 0), Quaternion.identity);

        // 2. このスクリプトをアタッチしているオブジェクトと同じ位置・向きでスポーンする場合
        Instantiate(prefabToSpawn, transform.position, transform.rotation);
    }
}