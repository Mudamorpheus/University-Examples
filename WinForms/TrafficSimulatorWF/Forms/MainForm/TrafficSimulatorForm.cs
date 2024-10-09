using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Custom
using TrafficSimulatorWF.Forms.MainForm;
using TrafficSimulatorWF.Graphic;

namespace TrafficSimulatorWF
{
    public partial class TrafficSimulatorForm : Form
    {
        //Синглтон
        private static TrafficSimulatorForm _singletone;
        public static TrafficSimulatorForm getInstance()
        {
            return _singletone;
        }

        //График
        private Graphoid MainGraphoid;

        //Координаты
        private float shiftX;
        private float shiftY;
        private bool isMoving = false;

        //Выбор
        private int _selectedAgent = -1;

        //Перегрузка отрисовки
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            MainGraphoid.Repaint();
        }

        //Оптимизация
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        //Конструктор
        public TrafficSimulatorForm()
        {
            InitializeComponent();

            //Синглтон
            _singletone = this;

            //Двойная буферизация
            DoubleBuffered = true;

            //Инструменты
            Toolbox.AddTool(ButtonCursor); //Курсор
            Toolbox.AddTool(ButtonVertex); //Добавить вершину
            Toolbox.AddTool(ButtonEdge); //Добавить ребро
            Toolbox.SetTool(ButtonCursor); //Инструмент по умолчанию

            //Карта
            MainGraphoid = new Graphoid(PictureBoxMain, TreeViewEdges, TreeViewAgents);

            //Таблица
            DataGridAgentInfo.ColumnCount = 3;
            DataGridAgentInfo.Columns[0].Name = "Точка отбытия";
            DataGridAgentInfo.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridAgentInfo.Columns[1].Name = "Точка прибытия";
            DataGridAgentInfo.Columns[2].Name = "Скорость";
            string[] row = { "", "", "" };
            DataGridAgentInfo.Rows.Add(row);
            DataGridAgentInfo.Rows[0].Height = DataGridAgentInfo.Height;
            DataGridAgentInfo.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
        }

        //================================================
        //Меню
        //================================================

        //Закрыть
        private void MenuSubItemClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //================================================
        //События
        //================================================

        //Добавить агента
        private void ButtonAgentAdd_Click(object sender, EventArgs e)
        {
            MainGraphoid.AddAgent();
            TreeViewAgents.SelectedNode = TreeViewAgents.Nodes[TreeViewAgents.Nodes.Count-1];
            _selectedAgent = TreeViewAgents.Nodes.Count-1;
        }

        //Убрать агента
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            //Если ничего не выбрано
            if (_selectedAgent == -1)
            {
                return;
            }

            //Очистить таблицу
            for (int i = 0; i > 2; i++)
            {
                DataGridAgentInfo[i, 0].Value = "";
            }

            //Удалить
            MainGraphoid.RemoveAgent(_selectedAgent);

            //Убрать выбор
            _selectedAgent = 0;
        }

        //Скопировать
        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            if(_selectedAgent == -1)
            {
                return;
            }

            MainGraphoid.CopyAgent(_selectedAgent);
            TreeViewAgents.SelectedNode = TreeViewAgents.Nodes[TreeViewAgents.Nodes.Count-1];
            _selectedAgent = TreeViewAgents.Nodes.Count-1;
        }

        //Запустить симуляцию
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            MainGraphoid.Simulation.Run();
            ButtonStart.Enabled = false;
            ButtonAgentAdd.Enabled = false;
            ButtonAgentCopy.Enabled = false;
            ButtonAgentRemove.Enabled = false;
            ButtonCursor.Enabled = false;
            ButtonVertex.Enabled = false;
            ButtonEdge.Enabled = false;
            ButtonStart.Enabled = false;
            ButtonStop.Enabled = true;
        }

        //Остановить симуляцию
        private void ButtonStop_Click(object sender, EventArgs e)
        {
            StopSimulation();
        }

        //Редактирование ячейки
        private void DataGridAgentInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rownum = e.RowIndex;
            int colnum = e.ColumnIndex;

            if (_selectedAgent == -1)
            {
                DataGridAgentInfo[colnum, rownum].Value = "";
                return;
            }

            int value;
            bool isParsable = Int32.TryParse((string)DataGridAgentInfo[colnum, rownum].Value, out value);
            
            if(!isParsable)
            {
                value = -1;
                DataGridAgentInfo[colnum, rownum].Value = -1;
            }

            switch(colnum)
            {
                case 0:
                    DataGridAgentInfo[colnum, rownum].Value = MainGraphoid.Simulation.AgentList[_selectedAgent].SetStart(value);
                    break;
                case 1:
                    DataGridAgentInfo[colnum, rownum].Value = MainGraphoid.Simulation.AgentList[_selectedAgent].SetEnd(value);
                    break;
                case 2:
                    DataGridAgentInfo[colnum, rownum].Value = MainGraphoid.Simulation.AgentList[_selectedAgent].SetSpeed(value);
                    break;
            }
        }

        //Выбор элементов в дереве агентов
        private void TreeViewAgents_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int index = TreeViewAgents.SelectedNode.Index;
            _selectedAgent = index;
            DataGridAgentInfo[0, 0].Value = MainGraphoid.Simulation.AgentList[index].Start;
            DataGridAgentInfo[1, 0].Value = MainGraphoid.Simulation.AgentList[index].End;
            DataGridAgentInfo[2, 0].Value = MainGraphoid.Simulation.AgentList[index].Speed;
        }

        //Клик на полотне
        private void PictureBoxMain_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point clickCoords = me.Location;

            //Преобразования
            double fluxX = (clickCoords.X-MainGraphoid.ShiftX)/MainGraphoid.Zoom;
            double fluxY = (clickCoords.Y-MainGraphoid.ShiftY)/MainGraphoid.Zoom;

            //Левая кнопка
            if(me.Button == MouseButtons.Left && !MainGraphoid.Simulation.IsRunning)
            {
                //Курсор
                if (Toolbox.CheckTool(ButtonCursor))
                {
                    MainGraphoid.SelectVertex(fluxX, fluxY);
                }
                //Добавить вершину
                if (Toolbox.CheckTool(ButtonVertex))
                {
                    MainGraphoid.AddVertex(fluxX, fluxY);
                }
                //Добавить ребро
                if(Toolbox.CheckTool(ButtonEdge))
                {
                    //Выбрать первую вершину
                    if(MainGraphoid.SelectedVertex == -1)
                    {
                        MainGraphoid.SelectVertex(fluxX, fluxY);
                    }
                    else
                    {
                        int start = MainGraphoid.SelectedVertex;
                        int end = MainGraphoid.FindVertex(fluxX, fluxY);

                        MainGraphoid.UnselectVertex();
                        if (end != -1)
                        {
                            MainGraphoid.AddEdge(start, end);
                        }
                    }
                }

            }

        }

        //Нажать на мышь на полотне
        private void PictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            Point mouseCoords = e.Location;

            //Левая кнопка
            if (e.Button == MouseButtons.Right)
            {
                //Начало движения курсором
                isMoving = true;
                shiftX = e.X;
                shiftY = e.Y;
            }
        }

        //Отпустить мышь на полотне
        private void PictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            //Левая кнопка
            if (e.Button == MouseButtons.Right)
            {
                //Начало движения курсором
                isMoving = false;
            }
        }

        //Двигать мышь на полотне
        private void PictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                Point mouseCoords = e.Location;
                MainGraphoid.SetShift(mouseCoords.X-shiftX, mouseCoords.Y-shiftY);
                shiftX = e.X;
                shiftY = e.Y;
            }
        }

        //Изменение зума
        private void TrackBarZoom_ValueChanged(object sender, EventArgs e)
        {
            MainGraphoid.SetZoom(TrackBarZoom.Value / 100F);
        }

        //Скролл зума
        private void TrackBarZoom_Scroll(object sender, EventArgs e)
        {
            LabelZoom.Text = TrackBarZoom.Value.ToString() + "%";
        }

        //Отлов конца симуляции
        public void StopSimulation()
        {
            MainGraphoid.Simulation.Stop();
            ButtonStart.Enabled = true;
            ButtonAgentAdd.Enabled = true;
            ButtonAgentCopy.Enabled = true;
            ButtonAgentRemove.Enabled = true;
            ButtonCursor.Enabled = true;
            ButtonVertex.Enabled = true;
            ButtonEdge.Enabled = true;
            ButtonStart.Enabled = true;
            ButtonStop.Enabled = false;
            MessageBox.Show("Затраченное время: " + (Math.Round(MainGraphoid.Simulation.Estimated, 2)).ToString() + " секунд.", Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
