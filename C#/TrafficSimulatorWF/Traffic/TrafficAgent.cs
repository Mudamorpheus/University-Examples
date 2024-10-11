using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Custom
using TrafficSimulatorWF.Objects.Elements;

namespace TrafficSimulatorWF.Traffic
{
    class TrafficAgent
    {
        //================================================
        //Коэффициент загруженности
        //================================================

        //Лимит замедления
        static double PARAM_SLOW_LIMIT = 0.9;
        //Шанс перехода
        static double PARAM_CHANGE_CHANCE = 0.25;

        //================================================
        //Поля
        //================================================

        //Позиция
        private int _startVertex = -1;
        public int Start { get { return _startVertex; } }
        private int _endVertex = -1;
        public int End { get { return _endVertex; }  }
        
        //Движение
        private int _currentVertex = -1;
        public int Vertex { get { return _currentVertex; } set { _currentVertex = value; }  }
        private int _currentEdge = -1;
        public int Edge { get { return _currentEdge; } set { _currentEdge = value; } }
        private double _edgeProgress = 0;
        public double EdgeProgress { get { return _edgeProgress; } set { _edgeProgress = value; } }
        
        //Маршрут
        private List<int> _path;
        public List<int> Path { get { return _path; } set { _path = value; } }
        private int _pathStage;
        public int PathStage { get { return _pathStage; } set { _pathStage = value; } }

        //Логика       
        private bool _isMoving = false;
        public bool IsMoving { get { return _isMoving; } set { _isMoving = value; } }

        //Параметры
        private int _speed;
        public int Speed { get { return _speed; } }
        private double _slow = 0;
        public double Slow { get { return _slow; } }
        private int _size;
        public int Size { get { return _size; } }

        //================================================
        //Конструкторы
        //================================================

        //Пустой
        public TrafficAgent()
        {
            _path = new List<int>();
        }

        //Скорость и размер
        public TrafficAgent(int speed, int size) : this()
        {
            _speed = speed;
            _size = size;
        }

        //Конструктор копирования
        public TrafficAgent(TrafficAgent origin) : this()
        {
            _startVertex = origin._startVertex;
            _endVertex = origin._endVertex;
            _speed = origin._speed;
            _size = origin._size;
        }

        //================================================
        //Методы
        //================================================

        //Прогресс
        public void AddProgress(double progress)
        {
            _edgeProgress += progress;
            if(_edgeProgress > 1)
            {
                _edgeProgress = 1;
            }
        }

        //Установить начало
        public int SetStart(int start)
        {
            if(start < 0)
            {
                start = -1;
            }
            _startVertex = start;
            return _startVertex;
        }

        //Установить конец
        public int SetEnd(int end)
        {
            if (end < 0)
            {
                end = -1;
            }
            _endVertex = end;
            return _endVertex;
        }

        //Установить скорость
        public int SetSpeed(int speed)
        {
            if (speed < 0)
            {
                speed = 0;
            }
            _speed = speed;
            return _speed;
        }

        //Установить замедление
        public double SetSlow(double slow)
        {
            if (slow < 0)
            {
                slow = 0;
            }
            else if(slow > PARAM_SLOW_LIMIT)
            {
                slow = 1;
            }

            _slow = slow;
            return _slow;
        }

        //Установить маршрут
        public bool SetPathDijkstra(TrafficSimulation simulation, int start, int end)
        {
            //Сброс
            _path.Clear();
            _pathStage = 0;


            //Параметры
            int size = simulation.Graph.VertexList.Count;

            //Расстояния
            double[] ArrayD = new double[size];
            //Маркеры
            bool[] ArrayB = new bool[size];
            //Маршруты
            List<int>[] ArrayPaths = new List<int>[size];

            //Этап - инициализация
            for (int i = 0; i < size; i++)
            {
                ArrayD[i] = Double.MaxValue;
                ArrayB[i] = false;
                ArrayPaths[i] = new List<int>();
            }
            ArrayD[start] = 0;
            ArrayPaths[start].Add(start);

            for(int i = 0; i < size; ++i)
            {
                int index = -1;
                double min = Double.MaxValue;
                for(int j = 0; j < size; ++j)
                {
                    if(ArrayB[j])
                    {
                        continue;
                    }
                    if(min < ArrayD[j])
                    {
                        continue;
                    }
                    index = j;
                    min = ArrayD[j];
                }
                
                for(int k = 0; k < simulation.Graph.EdgeList.Count; ++k)
                {
                    Edge edge = simulation.Graph.EdgeList[k];
                    if(simulation.Graph.EdgeList[k].Start == index)
                    {
                        int u = edge.End;
                        double distance = edge.Params.Length;

                        //Загруженность
                        distance *= (1 + simulation.CalculateSlow(edge.Params.Busy));

                        //Релаксация
                        if(ArrayD[index]+distance < ArrayD[u])
                        {
                            //Расстояние
                            ArrayD[u] = ArrayD[index] + distance;

                            //Маршрут
                            ArrayPaths[u].Clear();
                            foreach (var element in ArrayPaths[index])
                            {
                                ArrayPaths[u].Add(element);
                            }
                            ArrayPaths[u].Add(u);
                        }
                    }
                }

                ArrayB[index] = true;
            }

            //Итоговый маршрут
            foreach (var element in ArrayPaths[end])
            {                
                _path.Add(element);
            }

            //Вывод корректности
            if (ArrayD[end] == Double.MaxValue || _path.Count <= 1 || _path.First() != start || _path.Last() != end)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
