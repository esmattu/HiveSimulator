using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveSimulator.Model
{
    class DroneBee : Bee
    {

        public DroneBee() : base(BeeType.Drone)
        {
            DeathThreshold = 50.00F;
        }

        public void DamageDrone(int damage)
        {
            //bee is already don't both damaging it more
            if (CurrentBeeStatus == BeeStatus.Dead)
            {
                return;
            }

            //update the bee status as the threshold has passed.
            if (!(Health > DeathThreshold))
            {
                CurrentBeeStatus = BeeStatus.Dead;
                return;
            }

            float damagePercent = (Health / 100) * damage;

            //update the health with damage taken
            Health -= damagePercent;
        }

    }
}
