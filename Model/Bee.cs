using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveSimulator.Model
{

    //Enums will enusre that the correct values are used and avoid magic number problems
    public enum BeeType { Work, Drone, Queen };
    public enum BeeStatus { Alive, Dead };

    public abstract class Bee
    {


        public BeeType CurrentBee { get; set; }

        public float Health { get; set; }

        public float DeathThreshold { get; set; }

        public BeeStatus CurrentBeeStatus { get; set; }

        public Bee(BeeType type)
        {
            CurrentBee = type;
            CurrentBeeStatus = BeeStatus.Alive;
            Health = 100.00F;
        }                
    }
}
