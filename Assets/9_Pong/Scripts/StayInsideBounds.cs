using UnityEngine;

[RequireComponent(typeof(Collider))]
public class StayInsideBounds : MonoBehaviour
{
    public Collider boundsCollider;

    private Collider _col;
    private Transform _transform;

    Vector3 _lastPosition;

    private void Awake()
    {
        _transform = transform;

        _col = GetComponent<Collider>();
    }
    
    private void Update()
    {
        if (boundsCollider)
        {
            var halfSize = _col.bounds.extents;
            halfSize = _transform.position.z > boundsCollider.bounds.center.z ? halfSize * 1 : halfSize * -1;
            
            var contains = boundsCollider.bounds.Contains(_transform.position + halfSize);
            if (!contains)
            {
                _transform.position = _lastPosition;
            }
            else
            {
                _lastPosition = _transform.position;
            }

            //Debug.Log($"Size: {_col.bounds.size} Extends: {_col.bounds.extents} Center: {_col.bounds.center}");
        }
    }
}
