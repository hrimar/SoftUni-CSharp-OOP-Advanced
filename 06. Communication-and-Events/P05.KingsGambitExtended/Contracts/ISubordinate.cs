namespace P02.KingsGambit.Contracts
{
    public delegate void SubordinateDeathEventHandler(object sender);


    public interface ISubordinate : INamable, IKillable
    {
        event SubordinateDeathEventHandler DeathEvent;


        string Action { get; }

        void ReactToAttack();
    }
}