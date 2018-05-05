using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using ECSInject = Unity.Entities.InjectAttribute;
using ZenInject = Zenject.InjectAttribute;

public class PlayerMovementSystem : ComponentSystem
{
    public struct Data
    {
        public int Length;
        [ReadOnly] public ComponentDataArray<Heading> Heading;
        [ReadOnly] public ComponentDataArray<MoveSpeed> Speed;
        [ReadOnly] public ComponentArray<Rigidbody> Rigidbody;
    }

    [ECSInject] private Data data;

    protected override void OnUpdate()
    {
        var dt = Time.deltaTime;

        for (var i = 0; i < data.Length; i++)
        {
            var rigidbody = data.Rigidbody[i];
            rigidbody.AddForce(data.Heading[i].Value * data.Speed[i].speed);
        }
    }
}
