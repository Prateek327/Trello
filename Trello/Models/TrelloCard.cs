using System;
using System.Collections.Generic;
using System.Text;
using Trello.Services;

namespace Trello.Models
{
    public class TrelloCard
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AssignedUser { get; set; }
        public string ParentListId { get; set; }

        public TrelloCard()
        {
            Id = RandomNumberService.Instance.GenerateRandomNumber().ToString();
        }

        public void Print()
        {
            Console.WriteLine("Card: ");
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Assigned User: " + AssignedUser);
        }
    }
}
