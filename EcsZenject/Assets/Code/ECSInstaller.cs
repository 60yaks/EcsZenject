using Zenject;

public class ECSInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameSettings>().FromScriptableObjectResource("Settings").AsSingle();
    }
}
