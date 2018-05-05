using Unity.Entities;

public struct Player : ISharedComponentData
{
}

public class PlayerComponent : SharedComponentDataWrapper<Player>
{
}
