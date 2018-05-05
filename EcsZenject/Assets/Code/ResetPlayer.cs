using Unity.Entities;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ResetPlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        var entityManager = World.Active.GetExistingManager<EntityManager>();

        var entity = collider.GetComponent<GameObjectEntity>()?.Entity;
        if (entity.HasValue)
            entityManager.AddSharedComponentData(entity.Value, new ResetEntity());
    }

    void OnDrawGizmos()
    {
        var boxCollider = GetComponent<BoxCollider>();
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.size);
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(transform.position + boxCollider.center, boxCollider.size);
    }

    void OnDrawGizmosSelected()
    {
        var boxCollider = GetComponent<BoxCollider>();
        Gizmos.color = new Color(1, 1, 1, 1);
        Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.size);
        Gizmos.color = new Color(1, 1, 1, 0.3f);
        Gizmos.DrawCube(transform.position + boxCollider.center, boxCollider.size);
    }
}