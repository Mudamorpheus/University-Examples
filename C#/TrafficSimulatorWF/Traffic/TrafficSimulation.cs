using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Modify
using System.Windows.Forms;

//Custom
using TrafficSimulatorWF.Objects;
using TrafficSimulatorWF.Objects.Elements;
using TrafficSimulatorWF.Forms.MainForm;

namespace TrafficSimulatorWF.Traffic
{
    class TrafficSimulation
    {
        //================================================
        //Коэффициент загруженности
        //================================================

        static double PARAM_OVERLOAD_EFFECT = 0.20;
        static double PARAM_OVERLOAD_RANDOM = 10;
        static double PARAM_BUSY_POWER = 100;

        //================================================
        //Поля
        //================================================

        //Список агентов
        private List<TrafficAgent> _agentList;
        public List<TrafficAgent> AgentList { get { return _agentList;  } }
        //Граф
        private Graph _graph;
        public Graph Graph { get { return _graph; } set { _graph = value; } }
        //Состояние
        private bool _isRunning = false;
        public bool IsRunning { get { return _isRunning; } }
        private bool _isPaused = false;
        public bool IsPaused { get { return _isPaused; } }
        //Таймер
        private Timer _simulationTimer = new Timer();
        private int _interval = 25;
        //Время
        private double _estimated = 0;
        public double Estimated { get { return _estimated; } }

        //================================================
        //Конструкторы
        //================================================

        //Пустой конструктор
        public TrafficSimulation()
        {
            _agentList = new List<TrafficAgent>();
            _simulationTimer.Interval = _interval;
            _simulationTimer.Tick += new EventHandler(TimerEventProcessor);
        }

        //Конструктор графа
        public TrafficSimulation(Graph graph) : this()
        {
            _graph = graph;
        }

        //================================================
        //Методы
        //================================================

        //Добавить агента
        public void AddAgent(TrafficAgent agent)
        {
            _agentList.Add(agent);
        }
        public void AddAgent(int speed, int size)
        {
            TrafficAgent agent = new TrafficAgent(speed, size);
            _agentList.Add(agent);
        }

        //Удалить агента
        public void RemoveAgent(int index)
        {
            _agentList.RemoveAt(index);
        }

        //Запуск
        public void Run()
        {
            //Логика
            _isRunning = true;
            _isPaused = false;
            _estimated = 0;

            //Запуск таймера
            _simulationTimer.Start();

            //Настройка агентов
            foreach(var agent in _agentList)
            {
                //Если агент некорректен
                if(agent.Start == -1 || agent.End == -1 || agent.Speed == 0)
                {
                    continue;
                }

                //Проверка вершин
                if(_graph.VertexList[agent.Start] == null || _graph.VertexList[agent.End] == null)
                {
                    continue;
                }

                //Подбор маршрута
                if (!agent.SetPathDijkstra(this, agent.Start, agent.End))
                {
                    agent.Path.Clear();
                }
                else
                {
                    //Если агент корректен
                    agent.Vertex = agent.Start;
                    agent.Edge = -1;
                    agent.EdgeProgress = 0;
                    agent.SetSlow(0);
                    agent.IsMoving = true;
                }
            }
        }

        //Остановка симуляции
        public void Stop()
        {
            //Логика
            _isRunning = false;
            _isPaused = false;

            //Остановка таймера
            _simulationTimer.Stop();

            //Настройка агентов
            foreach (var agent in _agentList)
            {
                agent.Vertex = -1;
                agent.Edge = -1;
                agent.EdgeProgress = 0;
                agent.SetSlow(0);
                agent.IsMoving = false;
                agent.Path.Clear();
                agent.PathStage = 0;
            }

            //Сброс загруженности
            foreach (var edge in Graph.EdgeList)
            {
                edge.Params.Busy = 0;
                edge.Params.AgentList.Clear();
            }
        }

        //Скорость
        public void SetInterval(int interval)
        {
            _interval = interval;
            _simulationTimer.Interval = interval;
        }

        //Рассчитать замедление
        public double CalculateSlow(double param)
        {
            return PARAM_OVERLOAD_EFFECT*(param/(1+PARAM_OVERLOAD_EFFECT*param));
        }

        //================================================
        //События
        //================================================

        //Таймер
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            int counter = 0;
            _estimated += _simulationTimer.Interval/1000.00;

            //Движение агентов
            foreach (var agent in _agentList)
            {
                if(!agent.IsMoving)
                {
                    continue;
                }

                //Если агент некорректен
                if (agent.Start == -1 || agent.End == -1 || agent.Speed == 0 || agent.Path.Count == 0)
                {
                    agent.IsMoving = false;
                    continue;
                }

                //Агент добрался до своей цели
                if(agent.Vertex == agent.End)
                {
                    agent.IsMoving = false;
                    continue;
                }

                counter++;

                //Вход в новое ребро
                if(agent.Vertex != -1 && agent.Edge == -1)
                {
                    //Перерасчет
                    agent.SetPathDijkstra(this, agent.Vertex, agent.End);

                    //Проверка есть ли впереди кто-либо
                    int edgeIndex = Graph.FindEdgeIndex(agent.Path[agent.PathStage], agent.Path[agent.PathStage+1]);
                    Edge edge = _graph.EdgeList[edgeIndex];
                    int bung = 0;
                    foreach (var edgeagent in edge.Params.AgentList)
                    {
                        if (edgeagent.EdgeProgress*edge.Params.Length <= agent.Size*0.25)
                        {
                            bung++;
                        }
                    }

                    //Пробка
                    if(bung >= 1)
                    {
                        //Продолжить
                        continue;
                    }

                    //Переход на новый элемент
                    agent.Edge = edgeIndex;
                    agent.Vertex = -1;

                    //Добавляем загруженность
                    _graph.EdgeList[agent.Edge].Params.Busy += agent.Size/_graph.EdgeList[edgeIndex].Params.Length*PARAM_BUSY_POWER;
                    _graph.EdgeList[agent.Edge].Params.AgentList.Add(agent);

                    continue;
                }

                //Переход по пути
                if(agent.Edge != -1 && agent.Vertex == -1)
                {
                    //Вход в новую вершину
                    if(agent.EdgeProgress >= 1)
                    {
                        //Убираем загруженность
                        Edge edge = _graph.EdgeList[agent.Edge];
                        edge.Params.Busy -= agent.Size/edge.Params.Length*PARAM_BUSY_POWER;
                        edge.Params.AgentList.Remove(agent);

                        //Переход на новый элемент
                        agent.PathStage++;
                        agent.Vertex = agent.Path[agent.PathStage];
                        agent.Edge = -1;

                        //Сброс
                        agent.SetSlow(0);
                        agent.EdgeProgress = 0;

                        continue;
                    }

                    //В пути
                    double length = _graph.EdgeList[agent.Edge].Params.Length;
                    double busy = _graph.EdgeList[agent.Edge].Params.Busy;
                    double speed = agent.Speed*((double)_simulationTimer.Interval/1000);
                    double slow = agent.Slow;

                    //Вычисляем загруженность
                    int busycounter = 0;
                    foreach(var edgeagent in _graph.EdgeList[agent.Edge].Params.AgentList)
                    {
                        double difference = edgeagent.EdgeProgress-agent.EdgeProgress;
                        if(difference < 0)
                        {
                            continue;
                        }
                        
                        double distance = difference*length;
                        if(distance < agent.Size*2)
                        {
                            busycounter++;
                        }
                    }
                    Random rnd = new Random();

                    double busyslow = CalculateSlow(busycounter);
                    double randslow = rnd.Next(0, (int)PARAM_OVERLOAD_RANDOM)*0.01;

                    agent.SetSlow(busyslow+randslow);

                    //Прогресс
                    agent.AddProgress((speed*(1-slow))/length);
                }
            }

            if (counter == 0)
            {
                TrafficSimulatorForm.getInstance().StopSimulation();
            }
        }
    }
}
