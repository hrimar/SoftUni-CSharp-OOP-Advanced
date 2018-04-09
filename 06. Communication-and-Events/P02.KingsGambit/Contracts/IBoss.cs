using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit.Contracts
{
  public  interface IBoss
    {
        IReadOnlyCollection<ISubordinate> Subordinates { get; }

        void AddSubordinate(ISubordinate subordinate);
    }
}
