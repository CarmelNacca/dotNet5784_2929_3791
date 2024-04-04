

namespace Dal
{
    /// <summary>
    /// This class represents the data source for the application.
    /// </summary>
    internal static class DataSource
    {
        /// <summary>
        /// Configuration settings for the data source.
        /// </summary>
        internal static class Config
        {
            
            /// Starting ID for tasks.
           
            internal const int startTaskId = 1;

            /// <summary>
            /// Starting ID for dependencies.
            /// </summary>
            internal const int startDependencyId = 1;

            private static int nextTaskId = startTaskId;
            private static int nextDependencyId = startDependencyId;

            /// <summary>
            /// Property to get the next available task ID.
            /// </summary>
            internal static int NextTaskId { get => nextTaskId++; }

            /// <summary>
            /// Property to get the next available dependency ID.
            /// </summary>
            internal static int NextDependencyId { get => nextDependencyId++; }
        }

        /// <summary>
        /// List of dependencies in the data source.
        /// </summary>
        internal static List<DO.Dependency> Dependencies { get; } = new();

        /// <summary>
        /// List of tasks in the data source.
        /// </summary>
        internal static List<DO.Task> Tasks { get; } = new();

        /// <summary>
        /// List of workers in the data source.
        /// </summary>
        internal static List<DO.Worker> Workers { get; } = new();

        /// <summary>
        /// Collection of links (not implemented yet).
        /// </summary>
        public static IEnumerable<object> Links { get; internal set; }
    }
}

