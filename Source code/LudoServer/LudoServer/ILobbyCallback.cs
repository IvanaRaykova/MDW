using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LudoServer
{
    interface ILobbyCallback
    {
        [OperationContract(IsOneWay = true)]

        void onMessageAdded(DateTime timestamp, string userName, string message);

        [OperationContract(IsOneWay = true)]
        void OnOnline(string username);


    }
}
