using System;
using FlaxEngine;

namespace FlaxTasks
{
    /// <summary>
    /// The sample game plugin.
    /// </summary>
    /// <seealso cref="FlaxEngine.GamePlugin" />
    public class FlaxTasksPlugin : GamePlugin
    {
        /// <inheritdoc />
        public FlaxTasksPlugin()
        {
            _description = new PluginDescription
            {
                Name = "FlaxTasksPlugin",
                Category = "Scripting",
                Author = "ArtemPindrus",
                AuthorUrl = null,
                HomepageUrl = null,
                RepositoryUrl = "https://github.com/FlaxEngine/FlaxTasks",
                Description = "Tasks utility for Flax.",
                Version = new Version(),
                IsAlpha = false,
                IsBeta = false,
            };
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <inheritdoc />
        public override void Deinitialize()
        {
            base.Deinitialize();
        }
    }
}
