using UnityEngine;

[ExecuteInEditMode]
public class Tower : MonoBehaviour
{
    private const float TOWER_HEIGHT = 2.7f;
    private static readonly Vector3 SnappingPoint = new Vector3(0, TOWER_HEIGHT, 0);

    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject pivot;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private float enemyDetectionDistance = 10f;

    private Enemy nearestEnemy;

    private void Update()
    {
        if (Application.isPlaying) {
            FindNearestEnemy();
        } else {
            SetTurret();
        }
    }

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, enemyDetectionDistance);
    }

    private void SetTurret()
    {
        turret.transform.localPosition = SnappingPoint;
    }

    private void FindNearestEnemy()
    {
        if (nearestEnemy == null)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            if (enemies.Length > 0)
            {
                foreach (var enemy in enemies)
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) <= enemyDetectionDistance)
                    {
                        nearestEnemy = enemy;
                        Debug.Log("Enemy found");
                        return;
                    }
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, nearestEnemy.transform.position) > enemyDetectionDistance)
            {
                nearestEnemy = null;
                Debug.Log("Enemy left detection zone");
            }
        }
    }

    private void RotateTurretToNearestEnemy()
    {
        
    }
}