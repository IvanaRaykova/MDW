using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChatServiceMDW;
using System.Runtime.Serialization;

namespace ChatServiceMDW
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public string name;

        public IChatCallback chatCallback;

        public Player(string name)
        {
            this.name = name;
        }

    }
}
