using Flax.Build;

public class FlaxTasksEditorTarget : GameProjectEditorTarget
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Reference the modules for editor
        Modules.Add("FlaxTasks");
        Modules.Add("FlaxTasksEditor");
    }
}
