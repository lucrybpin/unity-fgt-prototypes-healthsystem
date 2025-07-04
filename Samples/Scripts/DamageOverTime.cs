using System;
using System.Threading.Tasks;

namespace FGT.Prototypes.HealthSystem.Demo
{
    public class DamageOverTime
    {
        public DamageOverTime(Mushroom target, float damage, int totalTicks)
        {
            _ = Execute(target, damage, totalTicks);
        }

        public async Task Execute(Mushroom target, float damage, int totalTicks)
        {
            if (target.GetCurrentHealth() == 0)
                return;

            for (int ticks = 0; ticks < totalTicks; ticks++)
            {
                await Task.Delay(TimeSpan.FromSeconds(1f));
                // Cancellation Token in a more serious implementation
                target.Hit(damage);
            }
        }
    }
}
