using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trello.Models;

namespace Trello.Services
{
    class BoardServices
    {
        private List<TrelloBoard> _boards;
        private static BoardServices _instance;

        private BoardServices()
        {
            _boards = new List<TrelloBoard>();
        }

        public static BoardServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BoardServices();
                }
                return _instance;
            }
        }

        internal void Add(TrelloBoard trelloBoard)
        {
            _boards.Add(trelloBoard);
        }

        internal void Remove(string id)
        {
            TrelloBoard board = (from trelloboard in _boards where trelloboard.Id == id select trelloboard).First();
            _boards.Remove(board);
            ListServices.Instance.RemoveListsOfParticularBoard(id);
        }

        internal void AddListToBoard(TrelloList trelloList)
        {
            var boardId = trelloList.ParentBoardId;
            TrelloBoard board = (from trelloboard in _boards where trelloboard.Id == boardId select trelloboard).First();
            board.Lists.Add(trelloList);
        }

        internal void RemoveListFromBoard(TrelloList trelloList)
        {
            var boardId = trelloList.ParentBoardId;
            TrelloBoard board = (from trelloboard in _boards where trelloboard.Id == boardId select trelloboard).First();
            board.Lists.Remove(trelloList);
        }

        internal void Show(string id)
        {
            TrelloBoard board = (from trelloboard in _boards where trelloboard.Id == id select trelloboard).First();
            board.Print();
        }

        internal void ShowAll()
        {
            foreach(var board in _boards)
            {
                board.Print();
            }
        }
    }
}
