using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit.Contracts
{

    public delegate void GetAttackedEventHandler();


   public interface IAttackable
    {
         event GetAttackedEventHandler GetAttackedEvent;

        void GetAttacked();
    }
}
