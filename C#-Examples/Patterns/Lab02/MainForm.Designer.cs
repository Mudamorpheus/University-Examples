
namespace СomputerEngineeringLab2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FiguresBox = new System.Windows.Forms.PictureBox();
            this.labelSizeFigure = new System.Windows.Forms.Label();
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.FuigureSize = new System.Windows.Forms.Label();
            this.groupBoxEdit = new System.Windows.Forms.GroupBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonBorderSize = new System.Windows.Forms.Button();
            this.buttonRec = new System.Windows.Forms.Button();
            this.buttonSize = new System.Windows.Forms.Button();
            this.buttonBorder = new System.Windows.Forms.Button();
            this.labelSizeBorder = new System.Windows.Forms.Label();
            this.trackBarBorderSize = new System.Windows.Forms.TrackBar();
            this.BorderSize = new System.Windows.Forms.Label();
            this.buttonFill = new System.Windows.Forms.Button();
            this.radioHexagon = new System.Windows.Forms.RadioButton();
            this.radioPentagone = new System.Windows.Forms.RadioButton();
            this.radioSquare = new System.Windows.Forms.RadioButton();
            this.radioTriangle = new System.Windows.Forms.RadioButton();
            this.radioCircle = new System.Windows.Forms.RadioButton();
            this.buttonBorderColor = new System.Windows.Forms.Button();
            this.buttonFillColor = new System.Windows.Forms.Button();
            this.labelBorderColor = new System.Windows.Forms.Label();
            this.labelFillColor = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBoxHistory = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.FiguresBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            this.groupBoxEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBorderSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBoxHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // FiguresBox
            // 
            this.FiguresBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.FiguresBox.Location = new System.Drawing.Point(0, 0);
            this.FiguresBox.Name = "FiguresBox";
            this.FiguresBox.Size = new System.Drawing.Size(392, 450);
            this.FiguresBox.TabIndex = 0;
            this.FiguresBox.TabStop = false;
            this.FiguresBox.Paint += new System.Windows.Forms.PaintEventHandler(this.FiguresBox_Paint);
            // 
            // labelSizeFigure
            // 
            this.labelSizeFigure.AutoSize = true;
            this.labelSizeFigure.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSizeFigure.Location = new System.Drawing.Point(0, 70);
            this.labelSizeFigure.Name = "labelSizeFigure";
            this.labelSizeFigure.Size = new System.Drawing.Size(50, 30);
            this.labelSizeFigure.TabIndex = 1;
            this.labelSizeFigure.Text = "Size";
            this.labelSizeFigure.Click += new System.EventHandler(this.label1_Click);
            // 
            // trackBarSize
            // 
            this.trackBarSize.Location = new System.Drawing.Point(0, 105);
            this.trackBarSize.Maximum = 100;
            this.trackBarSize.Minimum = 5;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(231, 45);
            this.trackBarSize.TabIndex = 1;
            this.trackBarSize.Value = 5;
            this.trackBarSize.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            this.trackBarSize.ValueChanged += new System.EventHandler(this.trackBarSize_ValueChanged);
            // 
            // FuigureSize
            // 
            this.FuigureSize.AutoSize = true;
            this.FuigureSize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FuigureSize.Location = new System.Drawing.Point(56, 69);
            this.FuigureSize.Name = "FuigureSize";
            this.FuigureSize.Size = new System.Drawing.Size(24, 30);
            this.FuigureSize.TabIndex = 2;
            this.FuigureSize.Text = "5";
            // 
            // groupBoxEdit
            // 
            this.groupBoxEdit.Controls.Add(this.buttonRun);
            this.groupBoxEdit.Controls.Add(this.buttonDraw);
            this.groupBoxEdit.Controls.Add(this.buttonBorderSize);
            this.groupBoxEdit.Controls.Add(this.buttonRec);
            this.groupBoxEdit.Controls.Add(this.buttonSize);
            this.groupBoxEdit.Controls.Add(this.buttonBorder);
            this.groupBoxEdit.Controls.Add(this.labelSizeBorder);
            this.groupBoxEdit.Controls.Add(this.trackBarBorderSize);
            this.groupBoxEdit.Controls.Add(this.BorderSize);
            this.groupBoxEdit.Controls.Add(this.buttonFill);
            this.groupBoxEdit.Controls.Add(this.radioHexagon);
            this.groupBoxEdit.Controls.Add(this.radioPentagone);
            this.groupBoxEdit.Controls.Add(this.radioSquare);
            this.groupBoxEdit.Controls.Add(this.radioTriangle);
            this.groupBoxEdit.Controls.Add(this.radioCircle);
            this.groupBoxEdit.Controls.Add(this.buttonBorderColor);
            this.groupBoxEdit.Controls.Add(this.buttonFillColor);
            this.groupBoxEdit.Controls.Add(this.labelBorderColor);
            this.groupBoxEdit.Controls.Add(this.labelFillColor);
            this.groupBoxEdit.Controls.Add(this.labelSizeFigure);
            this.groupBoxEdit.Controls.Add(this.trackBarSize);
            this.groupBoxEdit.Controls.Add(this.FuigureSize);
            this.groupBoxEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEdit.Location = new System.Drawing.Point(392, 0);
            this.groupBoxEdit.Name = "groupBoxEdit";
            this.groupBoxEdit.Size = new System.Drawing.Size(1103, 450);
            this.groupBoxEdit.TabIndex = 3;
            this.groupBoxEdit.TabStop = false;
            this.groupBoxEdit.Text = "Настройка";
            this.groupBoxEdit.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonRun
            // 
            this.buttonRun.Enabled = false;
            this.buttonRun.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRun.Location = new System.Drawing.Point(170, 408);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(57, 30);
            this.buttonRun.TabIndex = 20;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonDraw
            // 
            this.buttonDraw.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDraw.Location = new System.Drawing.Point(7, 408);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(87, 30);
            this.buttonDraw.TabIndex = 19;
            this.buttonDraw.Text = "Draw Figure";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonBorderSize
            // 
            this.buttonBorderSize.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBorderSize.Location = new System.Drawing.Point(100, 360);
            this.buttonBorderSize.Name = "buttonBorderSize";
            this.buttonBorderSize.Size = new System.Drawing.Size(131, 30);
            this.buttonBorderSize.TabIndex = 18;
            this.buttonBorderSize.Text = "Set Border Size";
            this.buttonBorderSize.UseVisualStyleBackColor = true;
            this.buttonBorderSize.Click += new System.EventHandler(this.buttonBorderSize_Click);
            // 
            // buttonRec
            // 
            this.buttonRec.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRec.Location = new System.Drawing.Point(100, 408);
            this.buttonRec.Name = "buttonRec";
            this.buttonRec.Size = new System.Drawing.Size(64, 30);
            this.buttonRec.TabIndex = 13;
            this.buttonRec.Text = "Record";
            this.buttonRec.UseVisualStyleBackColor = true;
            this.buttonRec.Click += new System.EventHandler(this.buttonRec_Click);
            // 
            // buttonSize
            // 
            this.buttonSize.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSize.Location = new System.Drawing.Point(6, 360);
            this.buttonSize.Name = "buttonSize";
            this.buttonSize.Size = new System.Drawing.Size(88, 30);
            this.buttonSize.TabIndex = 17;
            this.buttonSize.Text = "Set Size";
            this.buttonSize.UseVisualStyleBackColor = true;
            this.buttonSize.Click += new System.EventHandler(this.buttonSize_Click);
            // 
            // buttonBorder
            // 
            this.buttonBorder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBorder.Location = new System.Drawing.Point(100, 313);
            this.buttonBorder.Name = "buttonBorder";
            this.buttonBorder.Size = new System.Drawing.Size(131, 30);
            this.buttonBorder.TabIndex = 16;
            this.buttonBorder.Text = "Set Border Color";
            this.buttonBorder.UseVisualStyleBackColor = true;
            this.buttonBorder.Click += new System.EventHandler(this.buttonBorder_Click);
            // 
            // labelSizeBorder
            // 
            this.labelSizeBorder.AutoSize = true;
            this.labelSizeBorder.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSizeBorder.Location = new System.Drawing.Point(6, 153);
            this.labelSizeBorder.Name = "labelSizeBorder";
            this.labelSizeBorder.Size = new System.Drawing.Size(117, 30);
            this.labelSizeBorder.TabIndex = 13;
            this.labelSizeBorder.Text = "Border Size";
            // 
            // trackBarBorderSize
            // 
            this.trackBarBorderSize.Location = new System.Drawing.Point(6, 188);
            this.trackBarBorderSize.Maximum = 30;
            this.trackBarBorderSize.Minimum = 1;
            this.trackBarBorderSize.Name = "trackBarBorderSize";
            this.trackBarBorderSize.Size = new System.Drawing.Size(231, 45);
            this.trackBarBorderSize.TabIndex = 14;
            this.trackBarBorderSize.Value = 1;
            this.trackBarBorderSize.ValueChanged += new System.EventHandler(this.trackBarBorderSize_ValueChanged);
            // 
            // BorderSize
            // 
            this.BorderSize.AutoSize = true;
            this.BorderSize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BorderSize.Location = new System.Drawing.Point(129, 153);
            this.BorderSize.Name = "BorderSize";
            this.BorderSize.Size = new System.Drawing.Size(24, 30);
            this.BorderSize.TabIndex = 15;
            this.BorderSize.Text = "1";
            // 
            // buttonFill
            // 
            this.buttonFill.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFill.Location = new System.Drawing.Point(7, 313);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(87, 30);
            this.buttonFill.TabIndex = 12;
            this.buttonFill.Text = "Set Fill";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // radioHexagon
            // 
            this.radioHexagon.AutoSize = true;
            this.radioHexagon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioHexagon.Location = new System.Drawing.Point(109, 52);
            this.radioHexagon.Name = "radioHexagon";
            this.radioHexagon.Size = new System.Drawing.Size(87, 24);
            this.radioHexagon.TabIndex = 11;
            this.radioHexagon.TabStop = true;
            this.radioHexagon.Text = "Hexagon";
            this.radioHexagon.UseVisualStyleBackColor = true;
            // 
            // radioPentagone
            // 
            this.radioPentagone.AutoSize = true;
            this.radioPentagone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioPentagone.Location = new System.Drawing.Point(6, 48);
            this.radioPentagone.Name = "radioPentagone";
            this.radioPentagone.Size = new System.Drawing.Size(97, 24);
            this.radioPentagone.TabIndex = 10;
            this.radioPentagone.TabStop = true;
            this.radioPentagone.Text = "Pentagone";
            this.radioPentagone.UseVisualStyleBackColor = true;
            // 
            // radioSquare
            // 
            this.radioSquare.AutoSize = true;
            this.radioSquare.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioSquare.Location = new System.Drawing.Point(163, 23);
            this.radioSquare.Name = "radioSquare";
            this.radioSquare.Size = new System.Drawing.Size(73, 24);
            this.radioSquare.TabIndex = 9;
            this.radioSquare.TabStop = true;
            this.radioSquare.Text = "Square";
            this.radioSquare.UseVisualStyleBackColor = true;
            // 
            // radioTriangle
            // 
            this.radioTriangle.AutoSize = true;
            this.radioTriangle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioTriangle.Location = new System.Drawing.Point(77, 22);
            this.radioTriangle.Name = "radioTriangle";
            this.radioTriangle.Size = new System.Drawing.Size(80, 24);
            this.radioTriangle.TabIndex = 8;
            this.radioTriangle.TabStop = true;
            this.radioTriangle.Text = "Triangle";
            this.radioTriangle.UseVisualStyleBackColor = true;
            // 
            // radioCircle
            // 
            this.radioCircle.AutoSize = true;
            this.radioCircle.Checked = true;
            this.radioCircle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioCircle.Location = new System.Drawing.Point(7, 23);
            this.radioCircle.Name = "radioCircle";
            this.radioCircle.Size = new System.Drawing.Size(64, 24);
            this.radioCircle.TabIndex = 7;
            this.radioCircle.TabStop = true;
            this.radioCircle.Text = "Circle";
            this.radioCircle.UseVisualStyleBackColor = true;
            this.radioCircle.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // buttonBorderColor
            // 
            this.buttonBorderColor.BackColor = System.Drawing.Color.Black;
            this.buttonBorderColor.Location = new System.Drawing.Point(137, 277);
            this.buttonBorderColor.Name = "buttonBorderColor";
            this.buttonBorderColor.Size = new System.Drawing.Size(90, 30);
            this.buttonBorderColor.TabIndex = 6;
            this.buttonBorderColor.UseVisualStyleBackColor = false;
            this.buttonBorderColor.Click += new System.EventHandler(this.buttonBorderColor_Click);
            // 
            // buttonFillColor
            // 
            this.buttonFillColor.BackColor = System.Drawing.Color.White;
            this.buttonFillColor.Location = new System.Drawing.Point(137, 236);
            this.buttonFillColor.Name = "buttonFillColor";
            this.buttonFillColor.Size = new System.Drawing.Size(90, 30);
            this.buttonFillColor.TabIndex = 5;
            this.buttonFillColor.UseVisualStyleBackColor = false;
            this.buttonFillColor.Click += new System.EventHandler(this.buttonFillColor_Click);
            // 
            // labelBorderColor
            // 
            this.labelBorderColor.AutoSize = true;
            this.labelBorderColor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBorderColor.Location = new System.Drawing.Point(8, 276);
            this.labelBorderColor.Name = "labelBorderColor";
            this.labelBorderColor.Size = new System.Drawing.Size(123, 30);
            this.labelBorderColor.TabIndex = 4;
            this.labelBorderColor.Text = "BorderColor";
            this.labelBorderColor.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // labelFillColor
            // 
            this.labelFillColor.AutoSize = true;
            this.labelFillColor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFillColor.Location = new System.Drawing.Point(7, 236);
            this.labelFillColor.Name = "labelFillColor";
            this.labelFillColor.Size = new System.Drawing.Size(87, 30);
            this.labelFillColor.TabIndex = 3;
            this.labelFillColor.Text = "FillColor";
            this.labelFillColor.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(-18, 105);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(231, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            // 
            // groupBoxHistory
            // 
            this.groupBoxHistory.Controls.Add(this.buttonSave);
            this.groupBoxHistory.Controls.Add(this.buttonClear);
            this.groupBoxHistory.Controls.Add(this.buttonUndo);
            this.groupBoxHistory.Controls.Add(this.listBoxHistory);
            this.groupBoxHistory.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxHistory.Location = new System.Drawing.Point(629, 0);
            this.groupBoxHistory.Name = "groupBoxHistory";
            this.groupBoxHistory.Size = new System.Drawing.Size(866, 450);
            this.groupBoxHistory.TabIndex = 4;
            this.groupBoxHistory.TabStop = false;
            this.groupBoxHistory.Text = "History";
            this.groupBoxHistory.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(792, 408);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(65, 30);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonClear.Location = new System.Drawing.Point(722, 408);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(64, 30);
            this.buttonClear.TabIndex = 14;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Enabled = false;
            this.buttonUndo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUndo.Location = new System.Drawing.Point(7, 408);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(64, 30);
            this.buttonUndo.TabIndex = 12;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // listBoxHistory
            // 
            this.listBoxHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxHistory.FormattingEnabled = true;
            this.listBoxHistory.ItemHeight = 20;
            this.listBoxHistory.Location = new System.Drawing.Point(7, 22);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(850, 364);
            this.listBoxHistory.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 450);
            this.Controls.Add(this.groupBoxHistory);
            this.Controls.Add(this.groupBoxEdit);
            this.Controls.Add(this.FiguresBox);
            this.MaximumSize = new System.Drawing.Size(1511, 489);
            this.MinimumSize = new System.Drawing.Size(1511, 489);
            this.Name = "MainForm";
            this.Text = "Lab2";
            ((System.ComponentModel.ISupportInitialize)(this.FiguresBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            this.groupBoxEdit.ResumeLayout(false);
            this.groupBoxEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBorderSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBoxHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FiguresBox;
        private System.Windows.Forms.Label labelSizeFigure;
        private System.Windows.Forms.TrackBar trackBarSize;
        private System.Windows.Forms.Label FuigureSize;
        private System.Windows.Forms.GroupBox groupBoxEdit;
        private System.Windows.Forms.Label labelFillColor;
        private System.Windows.Forms.Label labelBorderColor;
        private System.Windows.Forms.Button buttonBorderColor;
        private System.Windows.Forms.Button buttonFillColor;
        private System.Windows.Forms.RadioButton radioCircle;
        private System.Windows.Forms.RadioButton radioTriangle;
        private System.Windows.Forms.RadioButton radioHexagon;
        private System.Windows.Forms.RadioButton radioPentagone;
        private System.Windows.Forms.RadioButton radioSquare;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBoxHistory;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.ListBox listBoxHistory;
        private System.Windows.Forms.Button buttonRec;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.Label labelSizeBorder;
        private System.Windows.Forms.TrackBar trackBarBorderSize;
        private System.Windows.Forms.Label BorderSize;
        private System.Windows.Forms.Button buttonBorderSize;
        private System.Windows.Forms.Button buttonSize;
        private System.Windows.Forms.Button buttonBorder;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonRun;
        //private System.Windows.Forms.RadioButton radioButton3;
    }
}

