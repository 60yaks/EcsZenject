using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using ECSInject = Unity.Entities.InjectAttribute;
using ZenInject = Zenject.InjectAttribute;

public class PlayerInputSystem : ComponentSystem
{
    public struct Data
    {
        public int Length;
        [ReadOnly] public SharedComponentDataArray<Player> Player;
        public ComponentDataArray<Heading> Heading;
        public ComponentDataArray<MoveSpeed> Speed;
    }

    [ECSInject] private Data data;
    [ZenInject] private GameSettings settings;

    protected override void OnUpdate()
    {
        for (int i = 0; i < data.Length; i++)
        {
            data.Heading[i] = new Heading { Value = new float3(Input.GetAxisRaw("Horizontal"), 0, 0) };
            data.Speed[i] = new MoveSpeed { speed = Input.GetKey(KeyCode.LeftShift) ? settings.RunSpeed : settings.WalkSpeed };
        }
    }
}
