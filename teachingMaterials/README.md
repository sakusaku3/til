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

## ICommand

```c#
public interface ICommand
{
    /// コマンドを実行する
    void Execute(object parameter);

    /// コマンドが実行可能な状態にあるかどうかを判定する
    bool CanExecute(object parameter);

    /// コマンド実行の可否が変化したことを通知するためのイベント
    event EventHandler CanExecuteChanged;
}
```