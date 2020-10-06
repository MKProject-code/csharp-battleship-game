namespace BattleShip_Game
{
    partial class FormBattleShip
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBattleShip));
            this.button = new System.Windows.Forms.Button();
            this.buttonFleetOrient = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStatus_PoleID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelBlockEnemyGride = new System.Windows.Forms.Label();
            this.labelBlockMyGride = new System.Windows.Forms.Label();
            this.timerEnemyRound = new System.Windows.Forms.Timer(this.components);
            this.comboBoxLevelPC = new System.Windows.Forms.ComboBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxInfoFleet = new System.Windows.Forms.PictureBox();
            this.grideMy = new System.Windows.Forms.PictureBox();
            this.grideEnemy = new System.Windows.Forms.PictureBox();
            this.listBoxFleet = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfoFleet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideMy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideEnemy)).BeginInit();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Font = new System.Drawing.Font("Cambria", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button.Location = new System.Drawing.Point(12, 165);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(216, 46);
            this.button.TabIndex = 2;
            this.button.Text = "Ustaw flotę";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonFleetOrient
            // 
            this.buttonFleetOrient.Enabled = false;
            this.buttonFleetOrient.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonFleetOrient.Location = new System.Drawing.Point(234, 165);
            this.buttonFleetOrient.Name = "buttonFleetOrient";
            this.buttonFleetOrient.Size = new System.Drawing.Size(154, 46);
            this.buttonFleetOrient.TabIndex = 11;
            this.buttonFleetOrient.Text = "Orientacja statku: Poziomo";
            this.buttonFleetOrient.UseVisualStyleBackColor = true;
            this.buttonFleetOrient.Click += new System.EventHandler(this.buttonFleetOrient_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStatus_PoleID,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 611);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(820, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(154, 17);
            this.toolStripStatusLabel1.Text = "Aktualnie wskazywane pole:";
            // 
            // toolStatus_PoleID
            // 
            this.toolStatus_PoleID.Name = "toolStatus_PoleID";
            this.toolStatus_PoleID.Size = new System.Drawing.Size(12, 17);
            this.toolStatus_PoleID.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(326, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(313, 17);
            this.toolStripStatusLabel3.Text = "Autorem programu jest Mateusz Klencner --- Wersja: 1.0.3";
            // 
            // labelBlockEnemyGride
            // 
            this.labelBlockEnemyGride.BackColor = System.Drawing.Color.Transparent;
            this.labelBlockEnemyGride.Font = new System.Drawing.Font("Cambria", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBlockEnemyGride.Location = new System.Drawing.Point(465, 268);
            this.labelBlockEnemyGride.Name = "labelBlockEnemyGride";
            this.labelBlockEnemyGride.Size = new System.Drawing.Size(343, 333);
            this.labelBlockEnemyGride.TabIndex = 19;
            this.labelBlockEnemyGride.Text = "Pole przeciwnika";
            this.labelBlockEnemyGride.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBlockMyGride
            // 
            this.labelBlockMyGride.BackColor = System.Drawing.Color.Transparent;
            this.labelBlockMyGride.Font = new System.Drawing.Font("Cambria", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBlockMyGride.Location = new System.Drawing.Point(45, 268);
            this.labelBlockMyGride.Name = "labelBlockMyGride";
            this.labelBlockMyGride.Size = new System.Drawing.Size(343, 333);
            this.labelBlockMyGride.TabIndex = 20;
            this.labelBlockMyGride.Text = "Twoje pole";
            this.labelBlockMyGride.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerEnemyRound
            // 
            this.timerEnemyRound.Interval = 500;
            this.timerEnemyRound.Tick += new System.EventHandler(this.timerEnemyRound_Tick);
            // 
            // comboBoxLevelPC
            // 
            this.comboBoxLevelPC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevelPC.FormattingEnabled = true;
            this.comboBoxLevelPC.Items.AddRange(new object[] {
            "Łatwy",
            "Średni",
            "Trudny"});
            this.comboBoxLevelPC.Location = new System.Drawing.Point(295, 132);
            this.comboBoxLevelPC.Name = "comboBoxLevelPC";
            this.comboBoxLevelPC.Size = new System.Drawing.Size(93, 21);
            this.comboBoxLevelPC.TabIndex = 23;
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonReset.Location = new System.Drawing.Point(12, 124);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(162, 35);
            this.buttonReset.TabIndex = 25;
            this.buttonReset.Text = "Nowa gra";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(180, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = "Poziom trudności:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusLabel.Location = new System.Drawing.Point(83, 215);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(253, 16);
            this.StatusLabel.TabIndex = 27;
            this.StatusLabel.Text = "Ustaw swoją flotę aby rozpocząć grę. ;)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Pomocnik:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(443, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 23);
            this.label12.TabIndex = 30;
            this.label12.Text = "Lotniskowiec";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(426, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 23);
            this.label13.TabIndex = 30;
            this.label13.Text = "Okręt wojenny";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(463, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 23);
            this.label14.TabIndex = 30;
            this.label14.Text = "Krążownik";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(414, 148);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 23);
            this.label15.TabIndex = 30;
            this.label15.Text = "Łódź podwodna";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(461, 181);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 23);
            this.label16.TabIndex = 30;
            this.label16.Text = "Niszczyciel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BattleShip_Game.Properties.Resources.baattleship_logo_fixed;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxInfoFleet
            // 
            this.pictureBoxInfoFleet.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxInfoFleet.Image = global::BattleShip_Game.Properties.Resources.fleet_transparent;
            this.pictureBoxInfoFleet.Location = new System.Drawing.Point(547, 12);
            this.pictureBoxInfoFleet.Name = "pictureBoxInfoFleet";
            this.pictureBoxInfoFleet.Size = new System.Drawing.Size(267, 199);
            this.pictureBoxInfoFleet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxInfoFleet.TabIndex = 3;
            this.pictureBoxInfoFleet.TabStop = false;
            // 
            // grideMy
            // 
            this.grideMy.Image = global::BattleShip_Game.Properties.Resources.grid_v3;
            this.grideMy.Location = new System.Drawing.Point(12, 236);
            this.grideMy.Name = "grideMy";
            this.grideMy.Size = new System.Drawing.Size(376, 365);
            this.grideMy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.grideMy.TabIndex = 0;
            this.grideMy.TabStop = false;
            this.grideMy.Click += new System.EventHandler(this.grideMy_Click);
            this.grideMy.MouseLeave += new System.EventHandler(this.grideMy_MouseLeave);
            this.grideMy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grideMy_MouseMove);
            // 
            // grideEnemy
            // 
            this.grideEnemy.BackColor = System.Drawing.Color.Transparent;
            this.grideEnemy.Image = global::BattleShip_Game.Properties.Resources.grid_v3;
            this.grideEnemy.Location = new System.Drawing.Point(432, 236);
            this.grideEnemy.Name = "grideEnemy";
            this.grideEnemy.Size = new System.Drawing.Size(376, 365);
            this.grideEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.grideEnemy.TabIndex = 1;
            this.grideEnemy.TabStop = false;
            this.grideEnemy.Click += new System.EventHandler(this.grideEnemy_Click);
            this.grideEnemy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grideEnemy_MouseMove);
            // 
            // listBoxFleet
            // 
            this.listBoxFleet.Enabled = false;
            this.listBoxFleet.FormattingEnabled = true;
            this.listBoxFleet.Items.AddRange(new object[] {
            "Lotniskowiec (5 pól)",
            "Okręt wojenny (4 pola)",
            "Krążownik (3 pola)",
            "Łódź podwodna (3 pola)",
            "Niszczyciel (2 pola)"});
            this.listBoxFleet.Location = new System.Drawing.Point(655, 12);
            this.listBoxFleet.Name = "listBoxFleet";
            this.listBoxFleet.Size = new System.Drawing.Size(159, 69);
            this.listBoxFleet.TabIndex = 6;
            this.listBoxFleet.Visible = false;
            // 
            // FormBattleShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(820, 633);
            this.Controls.Add(this.listBoxFleet);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxLevelPC);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelBlockMyGride);
            this.Controls.Add(this.labelBlockEnemyGride);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonFleetOrient);
            this.Controls.Add(this.pictureBoxInfoFleet);
            this.Controls.Add(this.button);
            this.Controls.Add(this.grideMy);
            this.Controls.Add(this.grideEnemy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(836, 672);
            this.MinimumSize = new System.Drawing.Size(836, 672);
            this.Name = "FormBattleShip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BattleShip Game";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfoFleet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideMy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideEnemy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox grideMy;
        private System.Windows.Forms.PictureBox grideEnemy;
        private System.Windows.Forms.PictureBox pictureBoxInfoFleet;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button buttonFleetOrient;
        private System.Windows.Forms.Label labelBlockEnemyGride;
        private System.Windows.Forms.Label labelBlockMyGride;
        private System.Windows.Forms.Timer timerEnemyRound;
        private System.Windows.Forms.ComboBox comboBoxLevelPC;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStatus_PoleID;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListBox listBoxFleet;
    }
}

