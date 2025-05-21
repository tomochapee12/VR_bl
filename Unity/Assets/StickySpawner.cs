using UnityEngine;

public class StickySpawner : MonoBehaviour
{
    public GameObject objectPrefab;     // 自分のPrefabを指定
    public float maxDistance = 0.5f;    // 動かされたと判断する距離
    private Vector3 initialPosition;
    private bool hasSpawned = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // 一度だけスポーンし、次のObjectにバトンを渡す
        if (!hasSpawned && Vector3.Distance(transform.position, initialPosition) > maxDistance)
        {
            Instantiate(objectPrefab, initialPosition, transform.rotation);
            hasSpawned = true;
        }
    }
}
