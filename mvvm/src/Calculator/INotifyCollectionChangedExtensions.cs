using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Calculator
{
    public static class INotifyCollectionChangeExtensions
    {
        public static IDisposable SynchronizeWith<TSource, TTarget>(
            this INotifyCollectionChanged items,
            ObservableCollection<TTarget> self,
            Func<TSource, TTarget> getItem)
        {
            var handler = new CollectionChangeHandler<TSource, TTarget>(self, getItem);

            items.CollectionChanged += handler.OnChildrenChanged;

            return new DelegateDisposable(
                () => items.CollectionChanged -= handler.OnChildrenChanged);
        }

        /// <summary>
        /// コレクションチェンジのハンドラを代行するクラス
        /// </summary>
        /// <typeparam name="TSource">更新元コレクションのアイテムタイプ</typeparam>
        /// <typeparam name="TTarget">更新先コレクションのアイテムタイプ</typeparam>
        private class CollectionChangeHandler<TSource, TTarget>
        {
            /// <summary>
            /// 更新先コレクション
            /// </summary>
            private readonly ObservableCollection<TTarget> items;

            /// <summary>
            /// 要素取得コールバック
            /// </summary>
            private readonly Func<TSource, TTarget> getItemCallBack;

            public CollectionChangeHandler(
                ObservableCollection<TTarget> items,
                Func<TSource, TTarget> getItemCallBack)
            {
                this.items = items;
                this.getItemCallBack = getItemCallBack;
            }

            public void OnChildrenChanged(object? sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        this.addExecute((TSource)e.NewItems[0], e.NewStartingIndex);
                        break;

                    case NotifyCollectionChangedAction.Move:
                        this.moveExecute(e.OldStartingIndex, e.NewStartingIndex);
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        this.removeExecute(e.OldStartingIndex);
                        break;

                    case NotifyCollectionChangedAction.Replace:
                        this.replaceExecute((TSource)e.NewItems[0], e.NewStartingIndex);
                        break;

                    case NotifyCollectionChangedAction.Reset:
                        this.clearExecute();
                        break;
                }
            }

            /// <summary>
            /// 追加
            /// </summary>
            private void addExecute(TSource newItem, int index)
            {
                this.items.Insert(index, this.getNode(newItem));
            }

            /// <summary>
            /// 移動
            /// </summary>
            private void moveExecute(int oldIndex, int newIndex)
            {
                this.items.Move(oldIndex, newIndex);
            }

            /// <summary>
            /// 削除
            /// </summary>
            private void removeExecute(int oldIndex)
            {
                var removing = this.items.ElementAt(oldIndex);
                this.items.Remove(removing);
            }

            /// <summary>
            /// 置換
            /// </summary>
            private void replaceExecute(TSource newItem, int index)
            {
                this.items[index] = this.getNode(newItem);
            }

            /// <summary>
            /// クリア
            /// </summary>
            private void clearExecute()
            {
                this.items.Clear();
            }

            /// <summary>
            /// 新規子ノード取得
            /// </summary>
            private TTarget getNode(TSource newChildItem) => this.getItemCallBack.Invoke(newChildItem);
        }
    }
}
