using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace Calculator.Models
{
    abstract class NodeBase
    {
        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<double> PositionX { get; }
        public ReactiveProperty<double> PositionY { get; }
        public ReactiveProperty<double?> Result { get; }

        public NodeBase()
        {
            this.Name = new ReactiveProperty<string>(string.Empty);
            this.PositionX = new ReactiveProperty<double>(0);
            this.PositionY = new ReactiveProperty<double>(0);
            this.Result = new ReactiveProperty<double?>(0);
        }
    }
}
