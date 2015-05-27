using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LudoServer;

namespace LudoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
   [ServiceContract(Namespace = "LudoServer", CallbackContract = typeof(IGameCallBack))]
    public interface IGame
    {
       List<Player> players;

       bool isTurn;

       [OperationContract]
       void RollDie();

       [OperationContract]
       public void MovePiece();
       [OperationContract]
       public void AddMessage(string playername, string message);
       [OperationContract]
       public bool Subscribe();
       [OperationContract]
       public bool Unsubscribe();
       [OperationContract]
       public void Spectate();
        // TODO: Add your service operations here

    }
   public interface IGameCallBack
   {
       [OperationContract(IsOneWay = true)]
       void OnRollDie(Player player, int dieresult);

       [OperationContract(IsOneWay = true)]
       void OnPlayerTurn(Player player);
       [OperationContract(IsOneWay = true)]
       void OnMovePiece(Player player);

       [OperationContract(IsOneWay = true)]
       void OnMessageAdded(Player player);
   }

   [ServiceBehavior(Namespace = "WebShopService")]

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
