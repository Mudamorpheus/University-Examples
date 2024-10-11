using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Custom
using TrafficSimulatorWF.Objects.Elements;

namespace TrafficSimulatorWF.Objects
{
    class Graph
    {
        //================================================
        //Поля
        //================================================

        //Интерпретация графа
        private List<Vertex> _vertexlist; //Список вершин
        public List<Vertex> VertexList { get { return _vertexlist; } set { _vertexlist = value; } }
        private List<Edge> _edgelist; //Список рёбер
        public List<Edge> EdgeList { get { return _edgelist; } set { _edgelist = value; } }

        //================================================
        //Конструкторы
        //================================================

        //Пустой
        public Graph()
        {
            _vertexlist = new List<Vertex>();
            _edgelist = new List<Edge>();
        }

        //================================================
        //Методы
        //================================================

        //Добавить вершину
        public void AddVertex(double x, double y)
        {
            Vertex vertex = new Vertex(x, y);
            _vertexlist.Add(vertex);
        }

        //Добавить ребро
        public void AddEdge(int start, int end, double length)
        {
            Edge edge = new Edge(start, end, length);
            _edgelist.Add(edge);
        }

        //Найти ребро
        public Edge FindEdge(int start, int end)
        {
            foreach(var edge in EdgeList)
            {
                if(edge.Start == start && edge.End == end)
                {
                    return edge;
                }
            }
            return null;
        }

        //Найти индекс ребра
        public int FindEdgeIndex(int start, int end)
        {
            foreach (var edge in EdgeList)
            {
                if (edge.Start == start && edge.End == end)
                {
                    return EdgeList.IndexOf(edge);
                }
            }
            return -1;
        }

        //Найти соседнюю вершину с наикратчайшим путём
        public Vertex FindVertexMinimal(int start)
        {
            Vertex minVertex = VertexList[start];
            double minLength = Double.MaxValue;

            foreach (var vertex in VertexList)
            {
                int index = VertexList.IndexOf(vertex);
                Edge edge = FindEdge(start, index);
                if (edge != null && edge.Params.Length < minLength)
                {
                    minVertex = vertex;
                    minLength = edge.Params.Length;
                }
            }

            return minVertex;
        }

        //Найти всех соседей вершины
        public List<Vertex> GetNeighbors(int origin)
        {
            List<Vertex> neighbors = new List<Vertex>();

            foreach (var vertex in VertexList)
            {
                int index = VertexList.IndexOf(vertex);
                Edge edge = FindEdge(origin, index);
                if(edge != null)
                {
                    neighbors.Add(vertex);
                }
            }

            return neighbors;
        }

        //Получить матрицу связей
        public double[,] GetDistanceMatrix()
        {
            int size = VertexList.Count;
            double[,] matrix = new double[size, size];

            foreach(var vertexA in VertexList)
            {
                foreach(var vertexB in VertexList)
                {
                    int a = VertexList.IndexOf(vertexA);
                    int b = VertexList.IndexOf(vertexB);
                    Edge dist = FindEdge(a, b);
                    if(dist != null)
                    {
                        matrix[a, b] = dist.Params.Length;
                    }
                    else
                    {
                        matrix[a, b] = 0;
                    }
                }
            }

            return matrix;
        }
    }
}
