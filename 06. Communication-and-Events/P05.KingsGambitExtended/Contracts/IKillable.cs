using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit.Contracts
{
    public interface IKillable
    {
        bool IsAlive { get; }

        int HitPoints { get; }

        void TakeDamage();

        void Die();
    }
}
