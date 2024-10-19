using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private int _lifeTime;

    public void BoxDestroy()
    {
        int minTime = 2;
        int maxTime = 6;
        _lifeTime = Random.Range(minTime, maxTime);

        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
