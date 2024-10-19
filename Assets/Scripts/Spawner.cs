using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private ObjectPool<GameObject> _pool;

    private int _quantity = 20;
    private int _spawnZoneX = 24;
    private int _spawnZoneZ = 24;
    private float _spawnDelay = 0.5f;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _quantity,
            maxSize: _quantity);
    }

    private void ActionOnGet(GameObject obj)
    {
        obj.transform.position = new Vector3(Random.Range(0, _spawnZoneX), _prefab.transform.position.y, Random.Range(0, _spawnZoneZ));
        obj.SetActive(true);
    }

    private void Start()
    {
       StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _quantity; i++)
        {
            _pool.Get();
            yield return wait;
        }
    }
}