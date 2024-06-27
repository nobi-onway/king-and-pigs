using System;
public interface IStateManager<T>  where T : Enum
{
    public T State { get; set; }

    public event Action<T> OnStateChange;
}
