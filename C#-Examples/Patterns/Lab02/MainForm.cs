using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using СomputerEngineeringLab2.Figure;
using СomputerEngineeringLab2.Commands;
using СomputerEngineeringLab2.Memento;
using СomputerEngineeringLab2.Proxy;

namespace СomputerEngineeringLab2
{
    public partial class MainForm : Form
    {

        public Graphics graphics;
        public ColorDialog colorDialog;
        public SaveFileDialog saveFileDialog;
        public Invoker invoker;
        //public Figures figure;
        public ChangeHistory history;
        public Originator originator;
        public List<Command> commandsRec;
        ISubject proxy;

        public MainForm()
        {
            InitializeComponent();
            graphics = this.FiguresBox.CreateGraphics();
            colorDialog = new ColorDialog();
            saveFileDialog = new SaveFileDialog();
            invoker = new Invoker();
            history = new ChangeHistory();
            originator = new Originator();
            List<Command> commandsRec = new List<Command>();
            //proxy = new FigureProxy();
            //figures = new Figures();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void FiguresBox_Paint(object sender, PaintEventArgs e)
        {
            //graphics = e.Graphics;


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void trackBarSize_ValueChanged(object sender, EventArgs e)
        {
            this.FuigureSize.Text = this.trackBarSize.Value.ToString();
        }

        private void buttonFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            this.buttonFillColor.BackColor = colorDialog.Color;
        }

        private System.Drawing.Point GetPoint()
        {
            if (history.History.Count != 0)
                buttonUndo.Enabled = true;
            graphics.Clear(Color.White);
            RadioButton radioBtn = this.groupBoxEdit.Controls.OfType<RadioButton>()
                                       .Where(x => x.Checked).FirstOrDefault();
            switch (radioBtn.Name)
            {
                case "radioCircle":
                    if (originator.Figure == null || !(originator.Figure is Circle))
                    {
                        //figure = new Circle();
                        originator.Figure = new Circle();
                    }
                    break;
                case "radioTriangle":
                    if (originator.Figure == null || !(originator.Figure is Triangle))
                    {
                        //figure = new Triangle();
                        originator.Figure = new Triangle();
                    }
                    break;
                case "radioSquare":
                    if (originator.Figure == null || !(originator.Figure is Square))
                    {
                        //figure = new Square();
                        originator.Figure = new Square();
                    }
                    break;
                case "radioHexagon":
                    if (originator.Figure == null || !(originator.Figure is Hexagon))
                    {
                        //figure = new Hexagon();
                        originator.Figure = new Hexagon();
                    }
                    break;
                case "radioPentagone":
                    if (originator.Figure == null || !(originator.Figure is Pentagon))
                    {
                        //figure = new Pentagon();
                        originator.Figure = new Pentagon();
                    }
                    break;
                default:
                    //figure = new Figures();
                    originator.Figure = new Figures();
                    break;
            }
            //originator.Figure = figure;
            return new System.Drawing.Point(FiguresBox.Width / 2, FiguresBox.Height / 2);
        }



        private void buttonBorderColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            this.buttonBorderColor.BackColor = colorDialog.Color;
        }

        private void trackBarBorderSize_ValueChanged(object sender, EventArgs e)
        {
            this.BorderSize.Text = this.trackBarBorderSize.Value.ToString();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            originator.RestoreState(history.History.Pop());
            var startPoint = GetPoint();
            originator.Figure.Draw(graphics, startPoint);
            if (history.History.Count == 0)
            {
                buttonUndo.Enabled = false;
            }
            proxy = new FigureProxy(originator.Figure);
            proxy.Request(listBoxHistory);
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            history.History.Push(originator.SaveState());
            var startPoint = GetPoint();
            List<Command> commands = new List<Command> {
                new BorderSizeCommand(originator.Figure, graphics, trackBarBorderSize.Value, startPoint),
                new SizeCommand(originator.Figure, graphics, trackBarSize.Value, startPoint),
                new FillCommand(originator.Figure, graphics, buttonFillColor.BackColor, startPoint),
                new BorderColorCommand(originator.Figure, graphics, buttonBorderColor.BackColor, startPoint)
            };
            invoker.SetCommand(new MacroCommand(commands));
            invoker.Run();
            proxy = new FigureProxy(originator.Figure);
            proxy.Request(listBoxHistory);
        }

        private void buttonBorder_Click(object sender, EventArgs e)
        {
            if (buttonRec.Text == "Stop")
            {
                var startPoint = new System.Drawing.Point(FiguresBox.Width / 2, FiguresBox.Height / 2);
                AddCommand(new BorderColorCommand(originator.Figure, graphics, buttonBorderColor.BackColor, startPoint));
            }
            else
            {
                history.History.Push(originator.SaveState());
                var startPoint = GetPoint();
                BorderColorCommand borderColorCom = new BorderColorCommand(originator.Figure, graphics, buttonBorderColor.BackColor, startPoint);
                invoker.SetCommand(borderColorCom);
                invoker.Run();
                proxy = new FigureProxy(originator.Figure);
                proxy.Request(listBoxHistory);
            }
        }

        private void buttonSize_Click(object sender, EventArgs e)
        {
            if (buttonRec.Text == "Stop")
            {
                var startPoint = new System.Drawing.Point(FiguresBox.Width / 2, FiguresBox.Height / 2);
                AddCommand(new SizeCommand(originator.Figure, graphics, trackBarSize.Value, startPoint));
            }
            else
            {
                history.History.Push(originator.SaveState());
                var startPoint = GetPoint();
                SizeCommand sizeCom = new SizeCommand(originator.Figure, graphics, trackBarSize.Value, startPoint);
                invoker.SetCommand(sizeCom);
                invoker.Run();
                proxy = new FigureProxy(originator.Figure);
                proxy.Request(listBoxHistory);
            }
        }

        private void buttonBorderSize_Click(object sender, EventArgs e)
        {
            if (buttonRec.Text == "Stop")
            {
                var startPoint = new System.Drawing.Point(FiguresBox.Width / 2, FiguresBox.Height / 2);
                AddCommand(new BorderSizeCommand(originator.Figure, graphics, trackBarBorderSize.Value, startPoint));
            }
            else
            {
                history.History.Push(originator.SaveState());
                var startPoint = GetPoint();
                BorderSizeCommand borderSizeCom = new BorderSizeCommand(originator.Figure, graphics, trackBarBorderSize.Value, startPoint);
                invoker.SetCommand(borderSizeCom);
                invoker.Run();
                proxy = new FigureProxy(originator.Figure);
                proxy.Request(listBoxHistory);
            }
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            if (buttonRec.Text == "Stop")
            {
                var startPoint = new System.Drawing.Point(FiguresBox.Width / 2, FiguresBox.Height / 2);
                AddCommand(new FillCommand(originator.Figure, graphics, buttonFillColor.BackColor, startPoint));
            }
            else
            {
                history.History.Push(originator.SaveState());
                var startPoint = GetPoint();
                FillCommand fillCom = new FillCommand(originator.Figure, graphics, buttonFillColor.BackColor, startPoint);
                invoker.SetCommand(fillCom);
                invoker.Run();
                proxy = new FigureProxy(originator.Figure);
                proxy.Request(listBoxHistory);
            }
        }

        private void buttonRec_Click(object sender, EventArgs e)
        {
            if (buttonRec.Text == "Record")
            {
                commandsRec = new List<Command>();
                buttonRec.Text = "Stop";
            }
            else
            {
                buttonRec.Text = "Record";
                if (commandsRec.Count > 0)
                    buttonRun.Enabled = true;
            }
        }

        public void AddCommand(Command com)
        {
            commandsRec.Add(com);
            if (commandsRec.Count == 5)
            {
                buttonRec.Text = "Record";
                buttonRun.Enabled = true;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            history.History.Push(originator.SaveState());
            var startPoint = GetPoint();
            invoker.SetCommand(new MacroCommand(commandsRec));
            invoker.Run();
            proxy = new FigureProxy(originator.Figure);
            proxy.Request(listBoxHistory);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var filePath = saveFileDialog.FileName;
            var result = String.Empty;
            for(int i = 0; i < listBoxHistory.Items.Count; i++)
            {
                result += listBoxHistory.Items[i] + "\n";
            }
            using (var fs = System.IO.File.Create(filePath))
            {
                fs.Write(Encoding.ASCII.GetBytes(result), 0, result.Count());
                fs.Flush();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxHistory.Items.Clear();
        }
    }
}
