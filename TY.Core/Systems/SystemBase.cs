using System.Reflection;
using TY.Entities;
using TY.Time;

namespace TY.Systems;

public abstract partial class SystemBase
{
    public EntityManager? EntityManager { get; internal set; } 

    protected EntitiesForEach Entities => EntityManager!.EntitiesForEach!;

    protected TimeData TimeData => EntityManager!.World.TimeData;

    public void Update()
    {
        OnUpdate();
    }

    public virtual void Awake()
    {
    }

    protected virtual void OnUpdate()
    {
    }
}

public partial class SystemBase
{
    public int Order => GetType().GetCustomAttribute<SystemOrderAttribute>()?.Order ?? int.MaxValue;
}