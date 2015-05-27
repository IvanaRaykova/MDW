using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatServiceMDW
{
    
    [ServiceContract(Namespace = "ChatCallbacks",CallbackContract = typeof(IChatCallback))]
    public interface IChat
    {
        [OperationContract]
        void AddMessage(string playerName, string message);
        [OperationContract]
        bool Subscribe();

        [OperationContract]
        bool UnSubscribe();

        [OperationContract]
        List<Player> GetOnlinePlayers();

        [OperationContract]
        bool PrivateSubscribe();

        [OperationContract]
        void AddPrivateMessage(string playerName, string message);


    }

}
