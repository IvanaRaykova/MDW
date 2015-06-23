using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace LudoService
{

    [DataContract]
    public class Die
    {
        Random randomizer;
        [DataMember]
        int die_value = 0;

        public Die()
        {
            randomizer = new Random();

        }

        public int DieValue
        {
            get { return this.die_value; }
        }


        public int RollDie()
        {
            this.die_value = this.randomizer.Next(1, 7);
            return die_value;
        }

    }
}