using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveSimulator.Model
{
   public class QueenBee : Bee
    {
        public QueenBee() : base(BeeType.Queen)
        {
            DeathThreshold = 20.00F;
        }

        public void DamageQueen(int damage)
        {

            //bee is already don't both damaging it more
            if (CurrentBeeStatus == BeeStatus.Dead)
            {
                return;
            }

            //update the bee status as the threshold has been passed.
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
