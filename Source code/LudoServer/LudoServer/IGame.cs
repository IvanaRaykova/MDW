using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace LudoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "LudoServer", CallbackContract = typeof(IGameCallBack))]
    public interface IGame
    {


        [OperationContract]
        int RollDie();
        [OperationContract]
        void NewGame(List<Player> players);

        [OperationContract]
        void MovePiece(Color PieceColor, int CurrentPosition);
        [OperationContract]
        void AddMessage(string playername, string message);
        [OperationContract]
        bool Subscribe();
        [OperationContract]
        bool Unsubscribe();
        //[OperationContract]
        // void Spectate();
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
        void onMessageAdded(DateTime timestamp, string playerName, string message);
    }

}
