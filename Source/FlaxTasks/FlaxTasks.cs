using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FlaxEngine;

namespace FlaxTasksPlugin;

/// <summary>
/// FlaxTasks class.
/// </summary>
public static class FlaxTasks
{
    /// <summary>
    /// Delays until supplied amount of time passes. Synced with update loop.
    /// </summary>
    /// <param name="time">Time in seconds.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException"></exception>
    public static async Task Delay(float time, CancellationToken? cancellationToken = null) {
        float passedTime = 0;
        Action action = () => passedTime += Time.DeltaTime;

        while (passedTime < time) {
            if (cancellationToken is CancellationToken validToken && validToken.IsCancellationRequested) throw new TaskCanceledException();
            await Scripting.RunOnUpdate(action);    
        }
    }

    /// <summary>
    /// Waits while <paramref name="condition"/> evaluates to true.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException"></exception>
    public static async Task WaitWhile(Func<bool> condition, CancellationToken? cancellation = null) {
        bool done = false;
        Action action = () => done = !condition();

        while (!done) {
            if (cancellation is CancellationToken validToken && validToken.IsCancellationRequested) throw new TaskCanceledException();

            await Scripting.RunOnUpdate(action);
        }
    }

    /// <summary>
    /// Waits until condition fails.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException"></exception>
    public static async Task WaitUntil(Func<bool> condition, CancellationToken? cancellation = null) {
        bool done = false;
        Action action = () => done = condition();

        while (!done) {
            if (cancellation is CancellationToken validToken && validToken.IsCancellationRequested) throw new TaskCanceledException();

            await Scripting.RunOnUpdate(action);
        }
    }
}
