

namespace BO;

   
[Serializable]
public class BlDoesNotExistException : Exception
{
    public BlDoesNotExistException(string? message) : base(message) { }
    public BlDoesNotExistException(string message, Exception innerException)
                : base(message, innerException) { }
}

[Serializable]

public class BlAlreadyExistsException : Exception
{
    public BlAlreadyExistsException(string? message) : base(message) { }
    public BlAlreadyExistsException(string message, Exception innerException)
                : base(message, innerException) { }
}

public class BlInvalidData : Exception
{
    public BlInvalidData(string? message) : base(message) { }
}
public class BlHavePendingTasks : Exception
{
    public BlHavePendingTasks(string? message) : base(message) { }
}
public class BlUnableDeleteBecauseProjectIsInProgress : Exception
{
    public BlUnableDeleteBecauseProjectIsInProgress(string? message) : base(message) { }
}
public class BlWorkerInMiddleOfTask : Exception
{
    public BlWorkerInMiddleOfTask(string? message) : base(message) { }
}



