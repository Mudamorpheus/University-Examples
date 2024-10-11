using System;
using System.Collections.Generic;
using System.Text;

namespace СomputerEngineeringLab2.Commands
{
    //Инициатор команды - вызывает команду для выполнения определенного запроса
    public class Invoker
    {
        Command command;
        public void SetCommand(Command c)
        {
            command = c;
        }
        public void Run()
        {
            if (command != null)
                command.Execute();
        }

    }
}
