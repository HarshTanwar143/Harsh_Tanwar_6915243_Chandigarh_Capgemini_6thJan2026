using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServiceCaseStudy
{
    internal class SupportCenter
    {
        public Queue<string> Tickets { get; } = new Queue<string>();
        public Stack<string> ActionHistory { get; } = new Stack<string>();

        public void AddTicket(string ticket)
        {
            Tickets.Enqueue(ticket);
        }

        public string ProcessTicket()
        {
            return Tickets.Dequeue();
        }

        public void PerformAction(string action)
        {
            ActionHistory.Push(action);
        }

        public string UndoLastAction()
        {
            return ActionHistory.Pop();
        }
    }
}
