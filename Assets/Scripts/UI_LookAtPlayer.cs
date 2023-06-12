using UnityEngine;

public class UI_LookAtPlayer : MonoBehaviour
{
    [SerializeField] Transform _headTransform;

    Vector3 _headPosition;

    void Start()
    {
        _headPosition = new Vector3(_headTransform.position.x, transform.position.y, _headTransform.position.z);

        transform.LookAt(_headPosition);
        transform.forward *= -1f;
    }
}
