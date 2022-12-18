using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionPractice.Models
{
    internal sealed class Calculator
    {
        /// <summary>
        /// 被演算項を取得または設定します
        /// </summary>
        public double Lhs { get; set; }

        /// <summary>
        /// 演算項を取得または設定します
        /// </summary>
        public double Rhs { get; set; }

        /// <summary>
        /// 計算結果を取得します
        /// </summary>
        public double Result { get; private set; }

        /// <summary>
        /// 割り算を実行します
        /// </summary>
        public void ExecuteDiv()
        {
            Result = Lhs / Rhs;
        }
    }
}
