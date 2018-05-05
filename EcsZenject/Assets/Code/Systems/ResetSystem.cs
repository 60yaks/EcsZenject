using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using ECSInject = Unity.Entities.InjectAttribute;
using ZenInject = Zenject.InjectAttribute;

public class ResetSystem : ComponentSystem
{
    public struct Data
    {
        public int Length;
        [ReadOnly] public SharedComponentDataArray<ResetEntity> Reset;
        [ReadOnly] public ComponentArray<Transform> Transform;
        [ReadOnly] public ComponentArray<Rigidbody> Rigidbody;
        public EntityArray Entity;
    }

    [ECSInject] private Data data;
    [ZenInject] private GameSettings settings;

    protected override void OnUpdate()
    {
        for (int i = 0; i < data.Length; i++)
        {
            data.Rigidbody[i].velocity = Vector3.zero;
            data.Rigidbody[i].angularVelocity = Vector3.zero;
            data.Transform[i].position = settings.ResetPosition;
            data.Transform[i].rotation = Quaternion.identity;
            PostUpdateCommands.RemoveComponent<ResetEntity>(data.Entity[i]);
        }

    }
}