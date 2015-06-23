using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace LudoServer
{
    interface ILobby
    {
        [OperationContract]
        void AddMessage(string userName, string message);
        [OperationContract]
        bool Subscribe();

        [OperationContract]
        bool UnSubscribe();

        [OperationContract]
        List<User> GetOnline();

        [OperationContract]
        void AddPrivateMessage(string playerName, string message);


    }
}
