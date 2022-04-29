using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application
{
    public class CommandResult
    {
        public CommandResult(){
            Messages = new List<string>();
            }
        public bool IsSucceeded { get; set; }

        public ICollection<string> Messages { get;  }


        public static CommandResult Success(params string[] messages)
        {
            var result = new CommandResult() { IsSucceeded = true };

            if(messages != null)
            {
                foreach(var message in messages)
                {
                    result.Messages.Add(message);
                }
            }
            return result;
        }

        public static CommandResult Error(params string[] messages)
        {
            var result = new CommandResult() { IsSucceeded= false };

            if(messages != null)
            {
                foreach(var  message in messages)
                {
                    result.Messages.Add(message);
                }
            }
            return result;
        }
    }

}
