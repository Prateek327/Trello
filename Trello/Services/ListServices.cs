using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trello.Models;

namespace Trello.Services
{
    class ListServices
    {
        private List<TrelloList> _lists;
        private static ListServices _instance;

        private ListServices()
        {
            _lists = new List<TrelloList>();
        }

        public static ListServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ListServices();
                }
                return _instance;
            }
        }

        internal void Add(TrelloList trelloList)
        {
            _lists.Add(trelloList);
            BoardServices.Instance.AddListToBoard(trelloList);
        }

        internal void Remove(string id)
        {
            TrelloList list = (from trellolists in _lists where trellolists.Id == id select trellolists).First();
            BoardServices.Instance.RemoveListFromBoard(list);
            CardServices.Instance.RemoveCardsOfParticularList(id);
            _lists.Remove(list);
        }

        internal void RemoveCardFromList(TrelloCard trelloCard)
        {
            var cardId = trelloCard.ParentListId;
            TrelloList list = (from trelloList in _lists where trelloList.Id == cardId select trelloList).First();
            list.Cards.Remove(trelloCard);
        }

        internal void AddCardToList(TrelloCard trelloCard)
        {
            var cardId = trelloCard.ParentListId;
            TrelloList list = (from trelloList in _lists where trelloList.Id == cardId select trelloList).First();
            list.Cards.Add(trelloCard);
        }

        internal void Show(string id)
        {
            TrelloList list = (from trellolist in _lists where trellolist.Id == id select trellolist).First();
            list.Print();
        }

        internal void ShowAll()
        {
            foreach (var list in _lists)
            {
                list.Print();
            }
        }

        internal void RemoveListsOfParticularBoard(string boardId)
        {
            List<TrelloList> lists = (from trellolist in _lists where trellolist.ParentBoardId == boardId select trellolist).ToList();
            _lists.RemoveAll(list => lists.Contains(list));
            foreach(var list in _lists)
            {
                CardServices.Instance.RemoveCardsOfParticularList(list.Id);
            }
        }
    }
}
