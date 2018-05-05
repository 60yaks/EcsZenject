using System.Linq;
using Unity.Entities;
using UnityEngine;
using Zenject;

public sealed class GameBootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitializeECS()
    {
        var systems = World.AllWorlds.SelectMany(w => w.BehaviourManagers).Distinct();
        foreach (var system in systems)
        {
            ProjectContext.Instance.Container.Inject(system);
        }
    }
}
