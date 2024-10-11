using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01.Bridge
{
    interface ILab
    {
        int Difficility { get; set; }
        List<String> Paterns { get; set; }
        int Id { get; set; }
    }
}
