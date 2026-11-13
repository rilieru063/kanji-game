
using UnityEngine;

public class KanjiSpawn : MonoBehaviour
{
    [Header("スポーン設定")]
    [SerializeField] private int MaxSpawnCount;
    [SerializeField] private float spawnInterval;

    public GameObject[] kanjiPrefabs;
    public GameObject[] kanjiSpawners;

    private int currentSpawnCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomKanji), spawnInterval, spawnInterval);
    }

    void SpawnRandomKanji()
    {
        // 最大スポーン数に達したら終了
        if (currentSpawnCount >= MaxSpawnCount)
        {
            CancelInvoke(nameof(SpawnRandomKanji));
            return;
        }

        // 12か所からランダムに選択
        int randomSpawner = Random.Range(0, kanjiSpawners.Length);

        SpawnKanji(randomSpawner);

        currentSpawnCount++;
    }

    void SpawnKanji(int spawnerIndex)
    {
        Transform spawner = kanjiSpawners[spawnerIndex].transform;

        // 漢字Prefabをランダムに選択
        int randomIndex = Random.Range(0, kanjiPrefabs.Length);

        GameObject kanji = Instantiate(
            kanjiPrefabs[randomIndex],
            spawner.position,
            spawner.rotation
        );

        KanjiMove move = kanji.GetComponent<KanjiMove>();

        Vector3[] directions =
        {
            Vector3.down,
            Vector3.down,
            Vector3.down,

            Vector3.up,
            Vector3.up,
            Vector3.up,

            Vector3.right,
            Vector3.right,
            Vector3.right,

            Vector3.left,
            Vector3.left,
            Vector3.left
        };

        move.SetDirection(directions[spawnerIndex]);
    }
}
