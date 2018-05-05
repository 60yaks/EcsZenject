using Unity.Entities;

public struct ResetEntity : ISharedComponentData
{
}

public class ResetEntityComponent : SharedComponentDataWrapper<ResetEntity>
{
}