using UnityEngine;

public class KanjiSpawn : MonoBehaviour
{
    [SerializeField] private int MaxSpawnCount;

    public GameObject[] kanjiPrefabs;
    public GameObject[] kanjiSpawners;

    [SerializeField] private GameObject prefabToSpawn;

    void Start()
    {
        // 仮に上からスポーン
        SpawnKanji(0);
    }

    void SpawnKanji(int spawnerIndex)
    {
        Transform spawner = kanjiSpawners[spawnerIndex].transform;

        GameObject kanji = Instantiate(
            prefabToSpawn,
            spawner.position,
            spawner.rotation
        );

        KanjiMove move = kanji.GetComponent<KanjiMove>();

        Vector3[] directions =
        {
            Vector3.back,    // 上から下
            Vector3.forward, // 下から上
            Vector3.right,   // 左から右
            Vector3.left     // 右から左
        };

        move.SetDirection(directions[spawnerIndex]);
    }
}
