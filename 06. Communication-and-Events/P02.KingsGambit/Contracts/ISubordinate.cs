namespace P02.KingsGambit.Contracts
{
    public interface ISubordinate : INamable, IKillable
    {
        string Action { get; }
        void ReactToAttack();
    }
}