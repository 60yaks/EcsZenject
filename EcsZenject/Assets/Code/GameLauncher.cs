using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using ZenInject = Zenject.InjectAttribute;

public class GameLauncher : MonoBehaviour
{
    [ZenInject] private GameSettings settings;

    private void Start()
    {
        var entityManager = World.Active.GetExistingManager<EntityManager>();

        var player = GameObject.Find("Player");
        var entity = player.GetComponent<GameObjectEntity>().Entity;

        entityManager.AddSharedComponentData(entity, new Player());
        entityManager.AddSharedComponentData(entity, new MoveForward());
        entityManager.AddComponentData(entity, new CopyTransformFromGameObject());
        entityManager.AddComponentData(entity, new Position());
        entityManager.AddComponentData(entity, new Heading());
        entityManager.AddComponentData(entity, new MoveSpeed { speed = settings.WalkSpeed });
    }
}
