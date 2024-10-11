using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulatorWF.Traffic
{
    //Интерфейс параметров дорожного пути
    interface ITrafficParams
    {

    }

    //Параметры вершины
    class TrafficVertexParams : ITrafficParams
    {

    }

    //Параметры ребра
    class TrafficEdgeParams : ITrafficParams
    {
        //Длина
        private double _length;
        public double Length { get { return _length; } set { _length = value; } }
        //Пропускная ширина
        private double _wide;
        public double Wide { get { return _wide; } set { _wide = value; } }
        //Загруженность
        private double _busy = 0;
        public double Busy { get { return _busy; } set { _busy = value; } }
        //Список агентов на дороге
        private List<TrafficAgent> _agentList = new List<TrafficAgent>();
        public List<TrafficAgent> AgentList { get { return _agentList; } }
    }
}
