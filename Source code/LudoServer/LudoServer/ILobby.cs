using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Drawing;
using System.Runtime.Serialization;
using LudoServer;


namespace LudoServer
{
    [ServiceContract(Namespace = "LudoServer", CallbackContract = typeof(ILobbyCallBack))]
   public interface ILobby
    {
       
        
        
        [OperationContract]
        void AddMessage(string playerName, string message);
        
        [OperationContract]
        bool Subscribe();
        
        [OperationContract]
        bool Unsubscribe();
        
        [OperationContract]
        List<Player> GetOnlinePlayers();
        
        [OperationContract]
        bool JoinGameSub();

        [OperationContract]
        void AddMessageGame(string playerName, string message);
                
        [OperationContract]
         bool Login(string username, string password);
        
        [OperationContract]
        void Register(string username, string password);
        
        [OperationContract]
         void NewGame();
       
        [OperationContract]
         void InvitePlayer(Player player);
       
        [OperationContract]
         void JoinGame(Game game);
        
        [OperationContract]
       void setColor(Player player);
        
        [OperationContract]
         void Ready();


    }

    public interface ILobbyCallBack
    {
        [OperationContract(IsOneWay=true)]
        void onMessageAdded(DateTime timestamp, string playerName, string message);
       
        [OperationContract(IsOneWay=true)]
        void OnOnline(string username);
        
        [OperationContract(IsOneWay = true)]
         void OnInvited(Player player);
        
        [OperationContract(IsOneWay = true)]
         void OnReady();
        
        [OperationContract(IsOneWay = true)]
         void OnGameStarted();
        
        [OperationContract(IsOneWay = true)]
         void OnColorSet(Color color);
        
    }
}
