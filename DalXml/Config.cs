using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

internal static class Config
{
    internal const int startTaskId = 1;
    private static int nextTaskId = startTaskId;
    internal const int startDependencyId = 1;
    private static int nextDependencyId = startDependencyId;
    internal static int NextTaskId { get => nextTaskId++; }
    internal static int NextDependencyId { get => nextDependencyId++; }

    
}
