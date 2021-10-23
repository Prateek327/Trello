using System;
using System.Collections.Generic;
using Trello.Services;

namespace Trello
{
    class Program
    {
        static void Main(string[] args)
        {
            TrelloProjectManager trelloProjectManager = new TrelloProjectManager();
            while (true)
            {
                string commands = Console.ReadLine();
                string[] commandList = commands.Split();
                switch (commandList[0])
                {
                    case "SHOW":
                        if (commandList.Length == 1)
                        {
                            trelloProjectManager.ShowAllBoards();
                        }
                        else
                        {
                            switch (commandList[1])
                            {
                                case "BOARD":
                                    trelloProjectManager.ShowBoard(commandList[2]);
                                    break;
                                case "LIST":
                                    trelloProjectManager.ShowList(commandList[2]);
                                    break;
                                case "CARD":
                                    trelloProjectManager.ShowCard(commandList[2]);
                                    break;
                            }
                        }
                        break;
                    case "BOARD":
                        switch (commandList[1])
                        {
                            case "CREATE":
                                trelloProjectManager.AddBoard(commandList[2]);
                                break;
                            case "DELETE":
                                trelloProjectManager.RemoveBoard(commandList[2]);
                                break;
                            default:
                                Console.WriteLine("Fuctionality not available");
                                break;
                        }
                        break;
                    case "LIST":
                        switch (commandList[1])
                        {
                            case "CREATE":
                                var listName = "";
                                for (int i = 3; i < commandList.Length; i++){
                                    listName = listName + commandList[i] + " ";
                                }
                                trelloProjectManager.AddList(listName.Trim(), commandList[2]);
                                break;
                            case "DELETE":
                                trelloProjectManager.RemoveList(commandList[2]);
                                break;
                            default:
                                Console.WriteLine("Fuctionality not available");
                                break;
                        }
                        break;
                    case "CARD":
                        switch (commandList[1])
                        {
                            case "CREATE":
                                var listName = "";
                                for (int i = 3; i < commandList.Length; i++)
                                {
                                    listName = listName + commandList[i] + " ";
                                }
                                trelloProjectManager.AddCard(listName.Trim(), commandList[2]);
                                break;
                            case "DELETE":
                                trelloProjectManager.RemoveCard(commandList[2]);
                                break;
                            default:
                                Console.WriteLine("Fuctionality not available");
                                break;
                        }
                        break;
                    case "EXIT":
                        return;
                }
            }
        }
    }
}
