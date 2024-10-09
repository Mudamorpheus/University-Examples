using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Modify
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

//Custom
using TrafficSimulatorWF.Graphic.Figures;
using TrafficSimulatorWF.Objects;
using TrafficSimulatorWF.Objects.Elements;
using TrafficSimulatorWF.Traffic;

namespace TrafficSimulatorWF.Graphic
{
    class Graphoid
    {
        //================================================
        //Константы
        //================================================

        static double PARAM_VERTEX_DEFAULT_SIZE = 8.00;
        static double PARAM_TEXT_DEFAULT_SIZE = 9.00;
        static double PARAM_EDGE_DEFAULT_SIZE = 6.00;
        static double PARAM_AGENT_DEFAULT_SIZE = 3.00;

        //================================================
        //Поля
        //================================================

        //Графические контроллеры
        private PictureBox _graphicControl;
        private TreeView _edgesViewer;
        private TreeView _agentsViewer;
        //Списки фигур
        private List<Figure> _vertexList;
        private List<Line> _edgeList;
        private List<Figure> _agentList;

        //Главный граф
        private Graph _graph;
        //Симуляция
        private TrafficSimulation _simulation;
        public TrafficSimulation Simulation { get { return _simulation; } }

        //Полотно
        private Graphics _graphics;
        //Битмап
        private Bitmap _bitmap;

        //Зум
        private double _zoom = 1.00F;
        public double Zoom { get { return _zoom; } }
        //Сдвиг
        private double _shiftX = 0;
        public double ShiftX { get { return _shiftX; } }
        private double _shiftY = 0;
        public double ShiftY { get { return _shiftY; } }
        //Размер холста
        private double _plotWidth = 500.00;
        private double _plotHeight = 500.00;
        //Выбор
        private int _selectedVertex = -1;
        public int SelectedVertex { get { return _selectedVertex; } }

        //================================================
        //Конструкторы
        //================================================

        //Пустой конструктор
        public Graphoid()
        {
            _vertexList = new List<Figure>();
            _edgeList = new List<Line>();
            _agentList = new List<Figure>();
            _graph = new Graph();
            _simulation = new TrafficSimulation(_graph);
        }

        //Конструктор полотна
        public Graphoid(PictureBox graphicControl, TreeView edgesViewer, TreeView agentsViewer) : this()
        {
            _graphicControl = graphicControl;
            _edgesViewer = edgesViewer;
            _agentsViewer = agentsViewer;
            InitGraphics();
        }

        //================================================
        //Методы
        //================================================

        //Добавить агента
        public void AddAgent()
        {
            //Графика
            Round round = new Round(0, 0, PARAM_AGENT_DEFAULT_SIZE);
            _agentList.Add(round);

            //Симуляция
            _simulation.AddAgent(50, 8);

            //Список
            TreeNode agentNode = new TreeNode("Агент "+_agentList.IndexOf(round).ToString());
            _agentsViewer.Nodes.Add(agentNode);
            int id = _agentsViewer.Nodes.IndexOf(agentNode);
            _agentsViewer.Nodes[id].Checked = true;
        }

        //Скопировать агента
        public void CopyAgent(int index)
        {
            //Графика
            Round round = new Round(0, 0, PARAM_AGENT_DEFAULT_SIZE);
            _agentList.Add(round);

            //Симуляция
            TrafficAgent origin = _simulation.AgentList[index];
            TrafficAgent agent = new TrafficAgent(origin);
            _simulation.AddAgent(agent);

            //Список
            TreeNode agentNode = new TreeNode("Агент " + _agentList.IndexOf(round).ToString());
            _agentsViewer.Nodes.Add(agentNode);
            int id = _agentsViewer.Nodes.IndexOf(agentNode);
            _agentsViewer.Nodes[id].Checked = true;
        }

        //Удалить агента
        public void RemoveAgent(int index)
        {
            if(_agentList.Count == 0)
            {
                return;
            }

            //Графика
            _agentList.RemoveAt(index);

            //Симуляция
            _simulation.RemoveAgent(index);

            //Список
            _agentsViewer.Nodes.RemoveAt(index);
        }

        //Добавить вершину
        public void AddVertex(double x, double y)
        {
            if((x > 0 && x < _plotWidth) && (y > 0 && y < _plotHeight))
            {
                //Графика
                Round round = new Round(x, y, PARAM_VERTEX_DEFAULT_SIZE);
                _vertexList.Add(round);

                //Граф
                _graph.AddVertex(x, y);
            }
        }

        //Добавить ребро
        public void AddEdge(int start, int end)
        {
            if(start == end || _graph.FindEdge(start, end) != null)
            {
                return;
            }

            //Вершины
            Vertex startVertex = _graph.VertexList[start];
            Vertex endVertex = _graph.VertexList[end];

            //Графика
            Line line = new Line(startVertex.X, startVertex.Y, endVertex.X, endVertex.Y, PARAM_EDGE_DEFAULT_SIZE);
            _edgeList.Add(line);

            //Граф
            double distance = Math.Sqrt(Math.Pow((endVertex.X-startVertex.X), 2)+Math.Pow((endVertex.Y-startVertex.Y), 2));
            _graph.AddEdge(start, end, (double)distance);

            //Добавить ребро в список
            TreeNode edgeNode = new TreeNode(start.ToString()+ " → " + end.ToString());
            _edgesViewer.Nodes.Add(edgeNode);
        }

        //===Базовая отрисовка===
        //Иницилизация
        public void InitGraphics()
        {
            _bitmap = new Bitmap(_graphicControl.ClientSize.Width+600, _graphicControl.ClientSize.Height+300);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
        }
        //Обновить изображение
        public void Refresh()
        {
            _graphicControl.Image = _bitmap;
        }
        //Очистка
        public void Clear()
        {
            _graphics.Clear(_graphicControl.BackColor);
        }
        //Перерисовать все
        public void Repaint()
        {
            Clear();
            PaintPlot();
            PaintFigures();
            Refresh();
        }

        //===Отрисовка фигур===
        //Нарисовать холст
        public void PaintPlot()
        {
            _graphics.FillRectangle(Brushes.White, 0, 0, (float)_plotWidth, (float)_plotHeight);
        }
        //Нарисовать фигуру
        public void PaintFigure(Figure figure)
        {
            figure.Draw(_graphics);            
        }
        //Нарисовать все фигуры
        public void PaintFigures()
        {
            //Рёбра
            foreach (var figure in _edgeList)
            {   
                if(_simulation.IsRunning)
                {
                    byte busy = (byte)(_graph.EdgeList[_edgeList.IndexOf(figure)].Params.Busy);
                    if(busy > 255)
                    {
                        busy = 255;
                    }
                    Color color = Color.FromArgb(busy, 255-busy, 0);
                    figure.DrawColoredPen(_graphics, new Pen(color));
                }
                else
                {
                    if (_edgesViewer.Nodes[_edgeList.IndexOf(figure)].Checked)
                    {
                        figure.DrawColoredPen(_graphics, Pens.Red);
                    }
                    else
                    {
                        figure.Draw(_graphics);
                    }
                }
            }
            //Вершины
            foreach (var figure in _vertexList)
            {
                Brush textbrush;
                if (_selectedVertex != -1 && _vertexList.IndexOf(figure) == _selectedVertex)
                {
                    figure.DrawColoredBrush(_graphics, Brushes.Red);
                    textbrush = Brushes.Black;
                }
                else
                {
                    figure.Draw(_graphics);
                    textbrush = Brushes.White;
                }
                _graphics.DrawString(_vertexList.IndexOf(figure).ToString(), new Font("Arial", (float)PARAM_TEXT_DEFAULT_SIZE), textbrush, (float)(figure.X-figure.Size), (float)(figure.Y-figure.Size));
            }
            //Агенты
            if(_simulation.IsRunning)
            { 
                foreach (var agent in _simulation.AgentList)
                {                    
                    if(!agent.IsMoving || !_agentsViewer.Nodes[_simulation.AgentList.IndexOf(agent)].Checked)
                    {
                        continue;
                    }

                    Figure figure = _agentList[_simulation.AgentList.IndexOf(agent)];
                    if(agent.Vertex != -1 && agent.Edge == -1)
                    {
                        figure.X = _vertexList[agent.Vertex].X;
                        figure.Y = _vertexList[agent.Vertex].Y;
                    }
                    else if (agent.Vertex == -1 && agent.Edge != -1)
                    {
                        Line line = _edgeList[agent.Edge];
                        double distance = agent.EdgeProgress*Math.Sqrt(Math.Pow(line.EndX-line.X, 2)+Math.Pow(line.EndY-line.Y, 2));
                        double radian = Math.Atan2((line.EndY-line.Y), (line.EndX-line.X));
                        double cos = Math.Cos(radian);
                        double sin = Math.Sin(radian);

                        figure.X = (_edgeList[agent.Edge].X+distance*cos);
                        figure.Y = (_edgeList[agent.Edge].Y+distance*sin);
                    }
                    else
                    {
                        figure.X = 0;
                        figure.Y = 0;
                    }

                    byte busy = (byte)(agent.Slow*255);
                    Color color = Color.FromArgb(busy, 255-busy, 0);
                    figure.DrawColoredBrush(_graphics, new SolidBrush(color));
                }
            }
        }

        //Зум
        public void SetZoom(double zoom)
        {
            if(zoom != 0)
            {
                _graphics.ScaleTransform((float)(1/_zoom), (float)(1/_zoom));
                _graphics.ScaleTransform((float)zoom, (float)zoom);                
                _zoom = zoom;
            }
        }

        //Сдвиг
        public void SetShift(double x, double y)
        {
            //Калибровка степени сдвига в зависимости от приближения
            x /= Zoom;
            y /= Zoom;

            //Новые координаты
            double newShiftX = _shiftX + x*_zoom;
            double newShiftY = _shiftY + y*_zoom;

            //Ограничение по Х
            if(Math.Abs(newShiftX) < _graphicControl.Width)
            { 
                _shiftX = newShiftX;
                _graphics.TranslateTransform((float)x, 0);
            }
            //Ограничение по Y
            if(Math.Abs(newShiftY) < _graphicControl.Height)
            {
                _shiftY = newShiftY;
                _graphics.TranslateTransform(0, (float)y);
            }
        }

        //===Определение и выбор фигур===
        //Выбор
        public void SelectVertex(double x, double y)
        {
            //Вершины
            foreach (var figure in _vertexList)
            {
                //Проверка попадания
                if(Math.Abs(figure.X-x) < figure.Size && Math.Abs(figure.Y-y) < figure.Size)
                {
                    if(_selectedVertex == _vertexList.IndexOf(figure))
                    {
                        UnselectVertex();
                    }
                    else
                    { 
                        _selectedVertex = _vertexList.IndexOf(figure);
                    }
                }
            }
            //Если найдена вершина
            if(_selectedVertex != -1)
            {
                Repaint();
            }
        }
        //Отменить выбор
        public void UnselectVertex()
        {
            //Если выбрана вершина
            if(_selectedVertex != -1)
            {
                //Убрать выбор
                _selectedVertex = -1;
                Repaint();
            }
        }
        //Найти вершину в точке
        public int FindVertex(double x, double y)
        {
            int result = -1;
            //Вершины
            foreach (var figure in _vertexList)
            {
                //Проверка попадания
                if (Math.Abs(figure.X - x) < figure.Size && Math.Abs(figure.Y - y) < figure.Size)
                {
                    result = _vertexList.IndexOf(figure);
                }
            }
            return result;
        }
    }
}
