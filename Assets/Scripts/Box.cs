using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Destroyer))]

public class Box : MonoBehaviour
{
    private bool _isColorChanged = false;

    private void OnCollisionEnter()
    {
        Destroyer destroyer = GetComponent<Destroyer>();

        if (_isColorChanged == false)
        {
            _isColorChanged = true;

            GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, Random.value);

            destroyer.BoxDestroy();
        }
    }
}