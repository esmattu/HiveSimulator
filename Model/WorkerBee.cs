using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveSimulator.Model
{
    public class WorkerBee : Bee
    {
        //Constructor will set the up the base class.
        public WorkerBee() : base (BeeType.Work)
        {
            DeathThreshold = 70.00F;
        }

        //Process the damage for the bee
        public void DamageWorker(int damage)
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
