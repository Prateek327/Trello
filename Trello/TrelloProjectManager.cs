using System;
using System.Collections.Generic;
using System.Text;
using Trello.Models;

namespace Trello.Services
{
    public class TrelloProjectManager
    {
   
        public void AddBoard(string name)
        {
            TrelloBoard trelloBoard = new TrelloBoard()
            {
                Name = name
            };
            BoardServices.Instance.Add(trelloBoard);
            Console.WriteLine("Board created: " + trelloBoard.Id);
        }

        public void RemoveBoard(string boardID)
        {
            BoardServices.Instance.Remove(boardID);
            Console.WriteLine("Board removed: " + boardID);
        }

        public void ShowBoard(string boardId)
        {
            BoardServices.Instance.Show(boardId);
        }

        public void ShowAllBoards()
        {
            BoardServices.Instance.ShowAll();
        }

        public void AddList(string name, string parentBoardId)
        {
            TrelloList list = new TrelloList() { Name = name, ParentBoardId = parentBoardId };
            ListServices.Instance.Add(list);
            Console.WriteLine("Created List: " + list.Id);
        }

        public void RemoveList(string listId)
        {
            ListServices.Instance.Remove(listId);
            Console.WriteLine("List removed: " + listId);
        }

        public void ShowList(string listId)
        {
            ListServices.Instance.Show(listId);
        }

        public void AddCard(string name, string parentListId)
        {
            TrelloCard card = new TrelloCard()
            {
                Name = name,
                ParentListId = parentListId
            };

            CardServices.Instance.Add(card);
            Console.WriteLine("Created card: " + card.Id);

        }

        public void RemoveCard(string cardId)
        {
            CardServices.Instance.Remove(cardId);
            Console.WriteLine("Card removed: " + cardId);
        }

        public void ShowCard(string cardId)
        {
            CardServices.Instance.Show(cardId);
        }
    }
}
