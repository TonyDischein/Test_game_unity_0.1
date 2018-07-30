using UnityEngine;

[ExecuteInEditMode]
public class Tower : MonoBehaviour
{
    private const float TOWER_HEIGHT = 2.7f;
    private static readonly Vector3 SnappingPoint = new Vector3(0, TOWER_HEIGHT, 0);

    [SerializeField] private GameObject turretBase;
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject pivot;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private float enemyDetectionDistance = 10f;

    private Enemy firstEnteredToDetectionZone;

    private void Update()
    {
        if (Application.isPlaying) {
            FindEnemy();
            RotateTurretToNearestEnemy();
        } else {
            SetTurretBase();
        }
    }

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, enemyDetectionDistance);
    }

    private void SetTurretBase()
    {
        turretBase.transform.localPosition = SnappingPoint;
    }

    private void FindEnemy()
    {
        if (firstEnteredToDetectionZone == null)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            if (enemies.Length > 0)
            {
                foreach (var enemy in enemies)
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) <= enemyDetectionDistance)
                    {
                        firstEnteredToDetectionZone = enemy;
                        Debug.Log("Enemy found");
                        return;
                    }
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, firstEnteredToDetectionZone.transform.position) > enemyDetectionDistance)
            {
                firstEnteredToDetectionZone = null;
                Debug.Log("Enemy left detection zone");
            }
        }
    }

    private void RotateTurretToNearestEnemy()
    {
        if (firstEnteredToDetectionZone != null)
        {
            Vector3 direction = firstEnteredToDetectionZone.transform.position - pivot.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            turret.transform.rotation = Quaternion.Euler(lookRotation.eulerAngles.x, lookRotation.eulerAngles.y, 0);
        }
    }
}