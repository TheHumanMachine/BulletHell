namespace BulletHell.Engine.Entities.Interfaces
{
    public interface IsKillable
    {
        double Health
        {
            get;
        }

        double TakeDamage(double damage);
    }
}
