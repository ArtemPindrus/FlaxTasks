using System;
using System.Collections.Generic;
using System.Threading;
using FlaxEngine;

namespace FlaxTasksPlugin;

/// <summary>
/// Script suitable for using <see cref="FlaxTasks"/>.
/// </summary>
public class TaskScript : Script
{
    private CancellationTokenSource destroyedCancellationSource = new();

    /// <summary>
    /// <see cref="CancellationToken"/> that gets cancelled when script is destroyed.
    /// </summary>
    public CancellationToken DestroyedCancellationToken => destroyedCancellationSource.Token;

    /// <inheritdoc/>
    public override void OnDestroy() {
        destroyedCancellationSource.Cancel();
    }
}
