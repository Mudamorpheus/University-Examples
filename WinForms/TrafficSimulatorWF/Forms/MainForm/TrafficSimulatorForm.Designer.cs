namespace TrafficSimulatorWF
{
    partial class TrafficSimulatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrafficSimulatorForm));
            this.TableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutTools = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutZoom = new System.Windows.Forms.TableLayoutPanel();
            this.TrackBarZoom = new System.Windows.Forms.TrackBar();
            this.LabelZoom = new System.Windows.Forms.Label();
            this.TreeViewEdges = new System.Windows.Forms.TreeView();
            this.TableLayoutSimulation = new System.Windows.Forms.TableLayoutPanel();
            this.TreeViewAgents = new System.Windows.Forms.TreeView();
            this.TableLayoutAgentsInterface = new System.Windows.Forms.TableLayoutPanel();
            this.DataGridAgentInfo = new System.Windows.Forms.DataGridView();
            this.ColumnStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.MenuUpItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSubItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSubItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.авторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.ButtonVertex = new System.Windows.Forms.Button();
            this.ButtonCursor = new System.Windows.Forms.Button();
            this.ButtonEdge = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonMove = new System.Windows.Forms.Button();
            this.PictureBoxMain = new System.Windows.Forms.PictureBox();
            this.ButtonAgentCopy = new System.Windows.Forms.Button();
            this.ButtonAgentAdd = new System.Windows.Forms.Button();
            this.ButtonAgentRemove = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.TableLayoutMain.SuspendLayout();
            this.TableLayoutTools.SuspendLayout();
            this.TableLayoutZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarZoom)).BeginInit();
            this.TableLayoutSimulation.SuspendLayout();
            this.TableLayoutAgentsInterface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridAgentInfo)).BeginInit();
            this.MenuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutMain
            // 
            this.TableLayoutMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutMain.AutoSize = true;
            this.TableLayoutMain.ColumnCount = 4;
            this.TableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutMain.Controls.Add(this.ButtonStop, 3, 1);
            this.TableLayoutMain.Controls.Add(this.TableLayoutTools, 0, 0);
            this.TableLayoutMain.Controls.Add(this.TableLayoutZoom, 0, 1);
            this.TableLayoutMain.Controls.Add(this.TreeViewEdges, 2, 0);
            this.TableLayoutMain.Controls.Add(this.PictureBoxMain, 1, 0);
            this.TableLayoutMain.Controls.Add(this.TableLayoutSimulation, 3, 0);
            this.TableLayoutMain.Controls.Add(this.DataGridAgentInfo, 1, 1);
            this.TableLayoutMain.Controls.Add(this.ButtonStart, 2, 1);
            this.TableLayoutMain.Location = new System.Drawing.Point(12, 27);
            this.TableLayoutMain.Name = "TableLayoutMain";
            this.TableLayoutMain.RowCount = 2;
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.80061F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.19939F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutMain.Size = new System.Drawing.Size(1240, 642);
            this.TableLayoutMain.TabIndex = 0;
            // 
            // TableLayoutTools
            // 
            this.TableLayoutTools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutTools.ColumnCount = 2;
            this.TableLayoutTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutTools.Controls.Add(this.ButtonVertex, 0, 1);
            this.TableLayoutTools.Controls.Add(this.ButtonCursor, 0, 0);
            this.TableLayoutTools.Controls.Add(this.ButtonEdge, 0, 2);
            this.TableLayoutTools.Controls.Add(this.ButtonDelete, 0, 3);
            this.TableLayoutTools.Controls.Add(this.ButtonMove, 1, 0);
            this.TableLayoutTools.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutTools.Name = "TableLayoutTools";
            this.TableLayoutTools.RowCount = 8;
            this.TableLayoutTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutTools.Size = new System.Drawing.Size(118, 525);
            this.TableLayoutTools.TabIndex = 1;
            // 
            // TableLayoutZoom
            // 
            this.TableLayoutZoom.ColumnCount = 1;
            this.TableLayoutZoom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutZoom.Controls.Add(this.TrackBarZoom, 0, 0);
            this.TableLayoutZoom.Controls.Add(this.LabelZoom, 0, 1);
            this.TableLayoutZoom.Location = new System.Drawing.Point(3, 534);
            this.TableLayoutZoom.Name = "TableLayoutZoom";
            this.TableLayoutZoom.RowCount = 2;
            this.TableLayoutZoom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutZoom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutZoom.Size = new System.Drawing.Size(118, 100);
            this.TableLayoutZoom.TabIndex = 3;
            // 
            // TrackBarZoom
            // 
            this.TrackBarZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackBarZoom.Location = new System.Drawing.Point(3, 3);
            this.TrackBarZoom.Maximum = 200;
            this.TrackBarZoom.Minimum = 1;
            this.TrackBarZoom.Name = "TrackBarZoom";
            this.TrackBarZoom.Size = new System.Drawing.Size(112, 44);
            this.TrackBarZoom.TabIndex = 2;
            this.TrackBarZoom.TabStop = false;
            this.TrackBarZoom.TickFrequency = 10;
            this.TrackBarZoom.Value = 100;
            this.TrackBarZoom.Scroll += new System.EventHandler(this.TrackBarZoom_Scroll);
            this.TrackBarZoom.ValueChanged += new System.EventHandler(this.TrackBarZoom_ValueChanged);
            // 
            // LabelZoom
            // 
            this.LabelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelZoom.AutoSize = true;
            this.LabelZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelZoom.Location = new System.Drawing.Point(3, 50);
            this.LabelZoom.Name = "LabelZoom";
            this.LabelZoom.Size = new System.Drawing.Size(112, 50);
            this.LabelZoom.TabIndex = 3;
            this.LabelZoom.Text = "100%";
            this.LabelZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TreeViewEdges
            // 
            this.TreeViewEdges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewEdges.CheckBoxes = true;
            this.TreeViewEdges.Location = new System.Drawing.Point(995, 3);
            this.TreeViewEdges.Name = "TreeViewEdges";
            this.TreeViewEdges.Size = new System.Drawing.Size(118, 525);
            this.TreeViewEdges.TabIndex = 4;
            this.TreeViewEdges.TabStop = false;
            // 
            // TableLayoutSimulation
            // 
            this.TableLayoutSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutSimulation.ColumnCount = 1;
            this.TableLayoutSimulation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutSimulation.Controls.Add(this.TreeViewAgents, 0, 1);
            this.TableLayoutSimulation.Controls.Add(this.TableLayoutAgentsInterface, 0, 0);
            this.TableLayoutSimulation.Location = new System.Drawing.Point(1119, 3);
            this.TableLayoutSimulation.Name = "TableLayoutSimulation";
            this.TableLayoutSimulation.RowCount = 2;
            this.TableLayoutSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TableLayoutSimulation.Size = new System.Drawing.Size(118, 525);
            this.TableLayoutSimulation.TabIndex = 6;
            // 
            // TreeViewAgents
            // 
            this.TreeViewAgents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewAgents.CheckBoxes = true;
            this.TreeViewAgents.Location = new System.Drawing.Point(3, 134);
            this.TreeViewAgents.Name = "TreeViewAgents";
            this.TreeViewAgents.Size = new System.Drawing.Size(112, 388);
            this.TreeViewAgents.TabIndex = 5;
            this.TreeViewAgents.TabStop = false;
            this.TreeViewAgents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewAgents_AfterSelect);
            // 
            // TableLayoutAgentsInterface
            // 
            this.TableLayoutAgentsInterface.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutAgentsInterface.ColumnCount = 2;
            this.TableLayoutAgentsInterface.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutAgentsInterface.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutAgentsInterface.Controls.Add(this.ButtonAgentCopy, 0, 1);
            this.TableLayoutAgentsInterface.Controls.Add(this.ButtonAgentAdd, 0, 0);
            this.TableLayoutAgentsInterface.Controls.Add(this.ButtonAgentRemove, 1, 0);
            this.TableLayoutAgentsInterface.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutAgentsInterface.Name = "TableLayoutAgentsInterface";
            this.TableLayoutAgentsInterface.RowCount = 2;
            this.TableLayoutAgentsInterface.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutAgentsInterface.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutAgentsInterface.Size = new System.Drawing.Size(112, 125);
            this.TableLayoutAgentsInterface.TabIndex = 6;
            // 
            // DataGridAgentInfo
            // 
            this.DataGridAgentInfo.AllowUserToAddRows = false;
            this.DataGridAgentInfo.AllowUserToDeleteRows = false;
            this.DataGridAgentInfo.AllowUserToResizeColumns = false;
            this.DataGridAgentInfo.AllowUserToResizeRows = false;
            this.DataGridAgentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridAgentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridAgentInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStart,
            this.ColumnEnd,
            this.ColumnSpeed});
            this.DataGridAgentInfo.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DataGridAgentInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DataGridAgentInfo.Location = new System.Drawing.Point(127, 534);
            this.DataGridAgentInfo.MultiSelect = false;
            this.DataGridAgentInfo.Name = "DataGridAgentInfo";
            this.DataGridAgentInfo.RowHeadersVisible = false;
            this.DataGridAgentInfo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridAgentInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridAgentInfo.ShowCellErrors = false;
            this.DataGridAgentInfo.Size = new System.Drawing.Size(862, 105);
            this.DataGridAgentInfo.TabIndex = 7;
            this.DataGridAgentInfo.TabStop = false;
            this.DataGridAgentInfo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridAgentInfo_CellEndEdit);
            // 
            // ColumnStart
            // 
            this.ColumnStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnStart.HeaderText = "Точка отбытия";
            this.ColumnStart.Name = "ColumnStart";
            // 
            // ColumnEnd
            // 
            this.ColumnEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnEnd.HeaderText = "Точка прибытия";
            this.ColumnEnd.Name = "ColumnEnd";
            // 
            // ColumnSpeed
            // 
            this.ColumnSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSpeed.HeaderText = "Скорость";
            this.ColumnSpeed.Name = "ColumnSpeed";
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUpItemFile,
            this.информацияToolStripMenuItem});
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Size = new System.Drawing.Size(1264, 24);
            this.MenuStripMain.TabIndex = 1;
            this.MenuStripMain.Text = "menuStrip1";
            // 
            // MenuUpItemFile
            // 
            this.MenuUpItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSubItemClose});
            this.MenuUpItemFile.Name = "MenuUpItemFile";
            this.MenuUpItemFile.Size = new System.Drawing.Size(48, 20);
            this.MenuUpItemFile.Text = "Файл";
            // 
            // MenuSubItemClose
            // 
            this.MenuSubItemClose.Name = "MenuSubItemClose";
            this.MenuSubItemClose.Size = new System.Drawing.Size(120, 22);
            this.MenuSubItemClose.Text = "Закрыть";
            this.MenuSubItemClose.Click += new System.EventHandler(this.MenuSubItemClose_Click);
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(48, 20);
            this.MenuItemFile.Text = "Файл";
            // 
            // MenuSubItemExit
            // 
            this.MenuSubItemExit.Name = "MenuSubItemExit";
            this.MenuSubItemExit.Size = new System.Drawing.Size(180, 22);
            this.MenuSubItemExit.Text = "Выход";
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.авторToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.информацияToolStripMenuItem.Text = "Информация";
            // 
            // авторToolStripMenuItem
            // 
            this.авторToolStripMenuItem.Name = "авторToolStripMenuItem";
            this.авторToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.авторToolStripMenuItem.Text = "Автор";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // ButtonStop
            // 
            this.ButtonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStop.BackgroundImage = global::TrafficSimulatorWF.Properties.Resources.tool_stop;
            this.ButtonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonStop.Enabled = false;
            this.ButtonStop.Location = new System.Drawing.Point(1119, 534);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(118, 105);
            this.ButtonStop.TabIndex = 8;
            this.ButtonStop.TabStop = false;
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // ButtonVertex
            // 
            this.ButtonVertex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonVertex.BackgroundImage = global::TrafficSimulatorWF.Properties.Resources.tool_vertex;
            this.ButtonVertex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonVertex.Location = new System.Drawing.Point(3, 68);
            this.ButtonVertex.Name = "ButtonVertex";
            this.ButtonVertex.Size = new System.Drawing.Size(53, 59);
            this.ButtonVertex.TabIndex = 0;
            this.ButtonVertex.TabStop = false;
            this.ButtonVertex.UseVisualStyleBackColor = true;
            // 
            // ButtonCursor
            // 
            this.ButtonCursor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCursor.BackgroundImage = global::TrafficSimulatorWF.Properties.Resources.tool_cursor;
            this.ButtonCursor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonCursor.Location = new System.Drawing.Point(3, 3);
            this.ButtonCursor.Name = "ButtonCursor";
            this.ButtonCursor.Size = new System.Drawing.Size(53, 59);
            this.ButtonCursor.TabIndex = 1;
            this.ButtonCursor.TabStop = false;
            this.ButtonCursor.UseVisualStyleBackColor = true;
            // 
            // ButtonEdge
            // 
            this.ButtonEdge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonEdge.BackgroundImage = global::TrafficSimulatorWF.Properties.Resources.tool_edge;
            this.ButtonEdge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonEdge.Location = new System.Drawing.Point(3, 133);
            this.ButtonEdge.Name = "ButtonEdge";
            this.ButtonEdge.Size = new System.Drawing.Size(53, 59);
            this.ButtonEdge.TabIndex = 2;
            this.ButtonEdge.TabStop = false;
            this.ButtonEdge.UseVisualStyleBackColor = true;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDelete.BackgroundImage = global::TrafficSimulatorWF.Properties.Resources.tool_delete;
            this.ButtonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDelete.Location = new System.Drawing.Point(3, 198);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(53, 59);
            this.ButtonDelete.TabIndex = 3;
            this.ButtonDelete.TabStop = false;
            this.ButtonDelete.UseVisualStyleBackColor = true;
            // 
            // ButtonMove
            // 
            this.ButtonMove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMove.BackgroundImage = global::TrafficSimulatorWF.Properties.Resources.tool_move;
            this.ButtonMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonMove.Location = new System.Drawing.Point(62, 3);
            this.ButtonMove.Name = "ButtonMove";
            this.ButtonMove.Size = new System.Drawing.Size(53, 59);
            this.ButtonMove.TabIndex = 4;
            this.ButtonMove.TabStop = false;
            this.ButtonMove.UseVisualStyleBackColor = true;
            // 
            // PictureBoxMain
            // 
            this.PictureBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBoxMain.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.PictureBoxMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBoxMain.Location = new System.Drawing.Point(127, 3);
            this.PictureBoxMain.Name = "PictureBoxMain";
            this.PictureBoxMain.Size = new System.Drawing.Size(862, 525);
            this.PictureBoxMain.TabIndex = 5;
            this.PictureBoxMain.TabStop = false;
            this.PictureBoxMain.Click += new System.EventHandler(this.PictureBoxMain_Click);
            this.PictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMain_MouseDown);
            this.PictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMain_MouseMove);
            this.PictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMain_MouseUp);
            // 
            // ButtonAgentCopy
            // 
            this.ButtonAgentCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAgentCopy.BackgroundImage = global::TrafficSimulatorWF.Properties.Resources.tool_copy;
            this.ButtonAgentCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonAgentCopy.Location = new System.Drawing.Point(3, 65);
            this.ButtonAgentCopy.Name = "ButtonAgentCopy";
            this.ButtonAgentCopy.Size = new System.Drawing.Size(50, 57);
            this.ButtonAgentCopy.TabIndex = 4;
            this.ButtonAgentCopy.TabStop = false;
            this.ButtonAgentCopy.UseVisualStyleBackColor = true;
            this.ButtonAgentCopy.Click += new System.EventHandler(this.ButtonCopy_Click);
            // 
            // ButtonAgentAdd
            // 
            this.ButtonAgentAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAgentAdd.BackgroundImage = global::TrafficSimulatorWF.Properties.Resources.tool_plus;
            this.ButtonAgentAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonAgentAdd.Location = new System.Drawing.Point(3, 3);
            this.ButtonAgentAdd.Name = "ButtonAgentAdd";
            this.ButtonAgentAdd.Size = new System.Drawing.Size(50, 56);
            this.ButtonAgentAdd.TabIndex = 2;
            this.ButtonAgentAdd.TabStop = false;
            this.ButtonAgentAdd.UseVisualStyleBackColor = true;
            this.ButtonAgentAdd.Click += new System.EventHandler(this.ButtonAgentAdd_Click);
            // 
            // ButtonAgentRemove
            // 
            this.ButtonAgentRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAgentRemove.BackgroundImage = global::TrafficSimulatorWF.Properties.Resources.tool_minus;
            this.ButtonAgentRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonAgentRemove.Location = new System.Drawing.Point(59, 3);
            this.ButtonAgentRemove.Name = "ButtonAgentRemove";
            this.ButtonAgentRemove.Size = new System.Drawing.Size(50, 56);
            this.ButtonAgentRemove.TabIndex = 3;
            this.ButtonAgentRemove.TabStop = false;
            this.ButtonAgentRemove.UseVisualStyleBackColor = true;
            this.ButtonAgentRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStart.BackgroundImage = global::TrafficSimulatorWF.Properties.Resources.tool_start;
            this.ButtonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonStart.Location = new System.Drawing.Point(995, 534);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(118, 105);
            this.ButtonStart.TabIndex = 3;
            this.ButtonStart.TabStop = false;
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // TrafficSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.TableLayoutMain);
            this.Controls.Add(this.MenuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStripMain;
            this.Name = "TrafficSimulatorForm";
            this.Text = "Traffic Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TableLayoutMain.ResumeLayout(false);
            this.TableLayoutTools.ResumeLayout(false);
            this.TableLayoutZoom.ResumeLayout(false);
            this.TableLayoutZoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarZoom)).EndInit();
            this.TableLayoutSimulation.ResumeLayout(false);
            this.TableLayoutAgentsInterface.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridAgentInfo)).EndInit();
            this.MenuStripMain.ResumeLayout(false);
            this.MenuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel TableLayoutTools;
        private System.Windows.Forms.Button ButtonVertex;
        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuSubItemExit;
        private System.Windows.Forms.Button ButtonCursor;
        private System.Windows.Forms.ToolStripMenuItem MenuUpItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuSubItemClose;
        private System.Windows.Forms.TrackBar TrackBarZoom;
        private System.Windows.Forms.TableLayoutPanel TableLayoutZoom;
        private System.Windows.Forms.Label LabelZoom;
        private System.Windows.Forms.Button ButtonEdge;
        private System.Windows.Forms.TreeView TreeViewEdges;
        private System.Windows.Forms.PictureBox PictureBoxMain;
        private System.Windows.Forms.TableLayoutPanel TableLayoutSimulation;
        private System.Windows.Forms.TreeView TreeViewAgents;
        private System.Windows.Forms.TableLayoutPanel TableLayoutAgentsInterface;
        private System.Windows.Forms.Button ButtonAgentAdd;
        private System.Windows.Forms.DataGridView DataGridAgentInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpeed;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonAgentRemove;
        private System.Windows.Forms.Button ButtonAgentCopy;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonMove;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem авторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
    }
}

