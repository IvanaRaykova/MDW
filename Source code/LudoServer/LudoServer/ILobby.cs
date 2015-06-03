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
       
        private bool isReady;
        private Color Color;
        private List<Game> games;
        
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
        public bool Login(string username, string password);
        
        [OperationContract]
        public void Register(string username, string password);
        
        [OperationContract]
        public void NewGame();
       
        [OperationContract]
        public void InvitePlayer(Player player);
       
        [OperationContract]
        public void JoinGame(Game game);
        
        [OperationContract]
        public void setColor(Player player);
        
        [OperationContract]
        public void Ready();


    }

    public interface ILobbyCallBack
    {
        [OperationContract(IsOneWay=true)]
        void onMessageAdded(DateTime timestamp, string playerName, string message);
       
        [OperationContract(IsOneWay=true)]
        void OnOnline(string username);
        
        [OperationContract(IsOneWay = true)]
        public void OnInvited(Player player);
        
        [OperationContract(IsOneWay = true)]
        public void OnReady();
        
        [OperationContract(IsOneWay = true)]
        public void OnGameStarted();
        
        [OperationContract(IsOneWay = true)]
        public void OnColorSet(Color color);
        
    }
}
