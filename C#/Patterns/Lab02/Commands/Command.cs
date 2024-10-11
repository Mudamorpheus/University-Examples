using System;
using System.Collections.Generic;
using System.Text;

namespace СomputerEngineeringLab2
{
    //интерфейс, представляющий команду. Обычно определяет метод Execute() для выполнения действия, 
    //а также нередко включает метод Undo(), реализация которого должна заключаться в отмене действия команды
    public abstract class Command
    {
        public abstract void Execute();
    }
}
