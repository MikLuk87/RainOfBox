using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;

    private ObjectPool<Rigidbody> _pool;

    private int _quantity = 20;
    private int _spawnZoneX = 24;
    private int _spawnZoneZ = 24;
    private float _spawnDelay = 0.5f;

    private void Awake()
    {
        _pool = new ObjectPool<Rigidbody>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.GameObject().SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _quantity,
            maxSize: _quantity);
    }

    private void ActionOnGet(Rigidbody obj)
    {
        obj.transform.position = new Vector3(Random.Range(0, _spawnZoneX), _prefab.transform.position.y, Random.Range(0, _spawnZoneZ));
        obj.GameObject().SetActive(true);
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