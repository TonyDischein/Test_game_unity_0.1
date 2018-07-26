using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class Tower : MonoBehaviour
{
    private const float TOWER_HEIGHT = 2.7f;
    private static readonly Vector3 SnappingPoint = new Vector3(0, TOWER_HEIGHT, 0);

    [SerializeField] private GameObject turret;

    private void Update()
    {
        SetTurret();
    }

    private void SetTurret()
    {
        turret.transform.localPosition = SnappingPoint;
    }
}