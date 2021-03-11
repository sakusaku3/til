# MVVMパターン

## INotifyPropertyChanged


```c#
public interface INotifyPropertyChanged
{
    event PropertyChangedEventHandler PropertyChanged;
}

public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

public class PropertyChangedEventArgs : EventArgs
{
    public virtual string PropertyName { get; }
}
```

```c#
public interface INotifyCollectionChanged
{
    event NotifyCollectionChangedEventHandler CollectionChanged;
}

public delegate void NotifyCollectionChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e);

public class NotifyCollectionChangedEventArgs : EventArgs
{
    public NotifyCollectionChangedAction Action { get; }
    public IList NewItems { get; }
    public IList OldItems { get; }
    public int NewStartingIndex { get; }
    public int OldStartingIndex { get; }
}

public enum NotifyCollectionChangedAction
{
    Add = 0,
    Remove = 1,
    Replace = 2,
    Move = 3,
    Reset = 4
}
```