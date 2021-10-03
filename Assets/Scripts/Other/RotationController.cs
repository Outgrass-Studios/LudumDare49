using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Vector3 axisMultiplier;

    Vector3 rotation;

    private void Update()
    {
        rotation += axisMultiplier * speed * Time.deltaTime;
        transform.localEulerAngles = rotation;
    }
}