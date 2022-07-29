using System.Collections.ObjectModel;
using System.Linq;

namespace Calculator.Models
{
    /// <summary>
    /// 加算器クラス
    /// </summary>
    public class Adder : NotificationObject
    {
        /// <summary>
        /// 項リスト
        /// </summary>
        public ReadOnlyObservableCollection<Term> Terms { get; } 
        private readonly ObservableCollection<Term> _terms;

        /// <summary>
        /// 結果
        /// </summary>
        public int Result
        {
            get { return this._result; }
            set { this.SetProperty(ref this._result, value); }
        }
        private int _result;

        public Adder()
        {
            this._terms = new ObservableCollection<Term>();
            this.Terms = new ReadOnlyObservableCollection<Term>(this._terms);
        }

        /// <summary>
        /// 項追加
        /// </summary>
        public void AddNewTerm()
        {
            this._terms.Add(new Term());
        }

        /// <summary>
        /// 項削除
        /// </summary>
        public void DeleteTerm()
        {
            if (!this._terms.Any()) return;
            this._terms.Remove(this._terms.Last());
        }

        /// <summary>
        /// 足し算実行可能
        /// </summary>
        /// <returns></returns>
        public bool CanDeleteTerm()
        {
            return this._terms.Any();
        }

        /// <summary>
        /// 足し算実行
        /// </summary>
        public void AddExecute()
        {
            this.Result = this._terms.Sum(x => x.Value);
        }

        /// <summary>
        /// 足し算実行可能
        /// </summary>
        /// <returns></returns>
        public bool CanAddExecute()
        {
            return true;
        }
    }
}
