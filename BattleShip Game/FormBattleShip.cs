using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

/*  *  *  *  *  *  *  *  *  *  *  *
 * BattleShip Game v1.0.3         * 
 * Author: Mateusz Klencner       * 
 * Creation date: 07-08.06.2018   * 
 * Creation time: ~24h            * 
 *  *  *  *  *  *  *  *  *  *  *  */

namespace BattleShip_Game
{
    public partial class FormBattleShip : Form
    {
        public FormBattleShip()
        {
            InitializeComponent();

            comboBoxLevelPC.SelectedItem = "Trudny";

            TransparentChange(grideMy, labelBlockMyGride, 50, Color.Black);
            TransparentChange(grideEnemy, labelBlockEnemyGride, 50, Color.Black);
        }

        private void TransparentChange(PictureBox PictureBoxName, Label LabelName, int alpha, Color color)
        {
            var pos = this.PointToScreen(LabelName.Location);
            pos = PictureBoxName.PointToClient(pos);
            LabelName.Parent = PictureBoxName;
            LabelName.Location = pos;
            LabelName.BackColor = Color.FromArgb(alpha, color);
        }

        private string etapProgramu = "null";

        private void button_Click(object sender, EventArgs e)
        {
            if (button.Text == "Rozpocznij grę")
            {
                button.Enabled = false;
                comboBoxLevelPC.Enabled = false;
                ComputerPlaning();
                //labelBlockEnemyGride.Visible = false;---przeniesione
            }

            if (button.Text == "Ustaw flotę")
            {
                button.Enabled = false;
                labelBlockMyGride.Visible = false;
                etapProgramu = "Ustawianie floty";
                buttonFleetOrient.Enabled = true;
                listBoxFleet.SelectedIndex = 0;
                StatusLabel.Text = "Wybierz pozycję dla statku: " + listBoxFleet.SelectedItem.ToString();
                button.Text = "Rozpocznij grę";
            }
        }

        int currentFleetSize = -1;
        int currentFleetOrient = 0;
        private string currnetSelectBox = "-";
        Dictionary<string, PictureBox> grideMy_tempPictureBox = new Dictionary<string, PictureBox> { };
        Dictionary<string, PictureBox> grideMy_MyFleetPictureBox = new Dictionary<string, PictureBox> { };
        private string nowMousePosBoxName = "-";
        private void grideMy_MouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
            Point pos = grideMy.PointToClient(Cursor.Position);

            int poleX = ((pos.X - 35) / 34) + 1;
            int poleY = ((pos.Y - 35) / 33) + 1;
            if ((pos.X - 35) < 0 || (pos.Y - 35) < 0 || pos.X > 373 || pos.Y > 362)
            {
                currnetSelectBox = "-";
                toolStatus_PoleID.Text = currnetSelectBox;
                nowMousePosBoxName = currnetSelectBox;
                if (grideMy_tempPictureBox.Count > 0)
                {
                    foreach (KeyValuePair<string, PictureBox> item in grideMy_tempPictureBox)
                    {
                        grideMy.Controls.Remove(item.Value);
                        item.Value.Dispose();
                    }
                    grideMy_tempPictureBox = new Dictionary<string, PictureBox> { };
                }
                return;
            }

            currnetSelectBox = cfg.letter[poleY] + poleX.ToString();
            toolStatus_PoleID.Text = currnetSelectBox;
            if (nowMousePosBoxName == currnetSelectBox)
                return;

            nowMousePosBoxName = currnetSelectBox;

            if (grideMy_tempPictureBox.Count > 0)
            {
                foreach (KeyValuePair<string, PictureBox> item in grideMy_tempPictureBox)
                {
                    grideMy.Controls.Remove(item.Value);
                    item.Value.Dispose();
                }
                grideMy_tempPictureBox = new Dictionary<string, PictureBox> { };
            }

            if (etapProgramu == "Ustawianie floty" && listBoxFleet.SelectedIndex > -1)
            {
                StatusLabel.Text = "Wybierz pozycję dla statku: " + listBoxFleet.SelectedItem.ToString();
                switch (listBoxFleet.SelectedIndex)
                {
                    case 0: currentFleetSize = 5; break;
                    case 1: currentFleetSize = 4; break;
                    case 2: currentFleetSize = 3; break;
                    case 3: currentFleetSize = 3; break;
                    case 4: currentFleetSize = 2; break;
                    default: currentFleetSize = -1; break;
                }
                int[] idPole = func.grideMy_GetIdBox(currnetSelectBox);
                if (currentFleetOrient == 0)
                {
                    if (idPole[0] > 11)
                        return;
                    else if (idPole[0] + currentFleetSize > 11)
                    {
                        idPole[0] -= (idPole[0] + currentFleetSize - 11);
                    }
                }
                else
                {
                    if (idPole[1] > 11)
                        return;
                    else if (idPole[1] + currentFleetSize > 11)
                    {
                        idPole[1] -= (idPole[1] + currentFleetSize - 11);
                    }
                }
                for (int i = 0; i < currentFleetSize; i++)
                {
                    if (i > 0)
                    {
                        if (currentFleetOrient == 0)
                        {
                            idPole[0]++;
                        }
                        else
                        {
                            idPole[1]++;
                        }
                    }
                    int[] nowStartPosBox = func.grideMy_GetStartPos(idPole);
                    PictureBox tempObjectAdd1 = grideMy_CreateColorBox(nowStartPosBox[0], nowStartPosBox[1]);
                    grideMy_tempPictureBox.Add(idPole[0] + "," + idPole[1], tempObjectAdd1);
                }
            }
        }

        private PictureBox grideMy_CreateColorBox(int StartPosBoxX, int StartPosBoxY)
        {
            PictureBox pictureBoxCheck = new PictureBox();
            pictureBoxCheck.BackColor = SystemColors.ControlDark; //SystemColors.ControlDark
            pictureBoxCheck.Location = new Point(StartPosBoxX, StartPosBoxY);
            pictureBoxCheck.Name = "pictureName";
            pictureBoxCheck.Size = new System.Drawing.Size(33, 32);
            pictureBoxCheck.TabIndex = 0;
            pictureBoxCheck.TabStop = false;
            pictureBoxCheck.Visible = true;
            pictureBoxCheck.MouseMove += new MouseEventHandler(grideMy_MouseMove);
            pictureBoxCheck.Click += new EventHandler(grideMy_Click);

            grideMy.Controls.Add(pictureBoxCheck);
            return pictureBoxCheck;
        }

        //////////////f


        private void grideMy_MouseLeave(object sender, EventArgs e)
        {
            currnetSelectBox = "-";
            toolStatus_PoleID.Text = currnetSelectBox;
        }

        private List<string> grideMy_BlockedBoxes = new List<string>();
        Dictionary<int,List<string>> grideMy_IdPosStripsInIdStrip = new Dictionary<int,List<string>> { };
        private void grideMy_Click(object sender, EventArgs e)
        {
            if (etapProgramu == "Ustawianie floty")
            {
                if (nowMousePosBoxName != "-" && grideMy_tempPictureBox.Count > 0)
                {
                    foreach (KeyValuePair<string, PictureBox> itemT in grideMy_tempPictureBox)
                    {
                        if (grideMy_BlockedBoxes.FindIndex(item => item == itemT.Key) >= 0)
                            return;
                    }
                    foreach (KeyValuePair<string, PictureBox> item in grideMy_tempPictureBox)
                    {
                        int[] idPole = item.Key.Split(',').Select(Int32.Parse).ToArray();
                        grideMy_BlockedBoxes.Add((idPole[0] - 1) + "," + (idPole[1] - 1));
                        grideMy_BlockedBoxes.Add((idPole[0] - 1) + "," + (idPole[1]));
                        grideMy_BlockedBoxes.Add((idPole[0] - 1) + "," + (idPole[1] + 1));

                        grideMy_BlockedBoxes.Add((idPole[0]) + "," + (idPole[1] - 1));
                        grideMy_BlockedBoxes.Add((idPole[0]) + "," + (idPole[1]));//grideMy_BlockedBoxes.Add(item.Key);
                        grideMy_BlockedBoxes.Add((idPole[0]) + "," + (idPole[1] + 1));

                        grideMy_BlockedBoxes.Add((idPole[0] + 1) + "," + (idPole[1] - 1));
                        grideMy_BlockedBoxes.Add((idPole[0] + 1) + "," + (idPole[1]));
                        grideMy_BlockedBoxes.Add((idPole[0] + 1) + "," + (idPole[1] + 1));
                    }
                    foreach (KeyValuePair<string, PictureBox> item in grideMy_tempPictureBox)
                    {
                        item.Value.BackColor = Color.LightSkyBlue;
                        grideMy_MyFleetPictureBox.Add(item.Key, item.Value);//idPole[0] + "," + idPole[1]

                        /////BEGIN/////comboBoxLevelPC.SelectedItem == "Średni" || "Trudny"; EDIT -> allow ALL
                        //if (comboBoxLevelPC.SelectedItem.ToString() == "Średni" || comboBoxLevelPC.SelectedItem.ToString() == "Trudny")
                        //{
                        List<string> valList = new List<string>();
                            if (grideMy_IdPosStripsInIdStrip.ContainsKey(listBoxFleet.SelectedIndex))
                            {
                                valList = grideMy_IdPosStripsInIdStrip.FirstOrDefault(t => t.Key == listBoxFleet.SelectedIndex).Value;
                                valList.Add(item.Key);
                                grideMy_IdPosStripsInIdStrip[listBoxFleet.SelectedIndex] = valList;
                            }
                            else
                            {
                                valList.Add(item.Key);
                                grideMy_IdPosStripsInIdStrip.Add(listBoxFleet.SelectedIndex, valList);
                            }
                        //}
                        /////END/////comboBoxLevelPC.SelectedItem == "Średni" || "Trudny"; EDIT -> allow ALL
                    }
                    grideMy_tempPictureBox = new Dictionary<string, PictureBox> { };

                    if (listBoxFleet.SelectedIndex < listBoxFleet.Items.Count - 1)
                    {
                        listBoxFleet.SelectedIndex = listBoxFleet.SelectedIndex + 1;
                        StatusLabel.Text = "Wybierz pozycję dla statku: " + listBoxFleet.SelectedItem.ToString();
                    }
                    else
                    {
                        StatusLabel.Text = "Twoje statki są gotowe do boju! Kliknij \"Rozpocznij grę\" gdy będziesz gotowy. :D";
                        listBoxFleet.SelectedIndex = -1;
                        button.Enabled = true;
                        buttonFleetOrient.Enabled = false;
                        //>>>>"Start gry"
                    }
                }
            }
        }

        private void ShowFleet_OnGrideEnemy()
        {
            foreach (KeyValuePair<string, PictureBox> item in grideEnemy_FleetPictureBox_Enemy)
                item.Value.Visible = true;
        }

        private void buttonFleetOrient_Click(object sender, EventArgs e)
        {
            if (currentFleetOrient == 0)
            {
                currentFleetOrient = 1;
                buttonFleetOrient.Text = "Orientacja statku: Pionowo";
            }
            else
            {
                currentFleetOrient = 0;
                buttonFleetOrient.Text = "Orientacja statku: Poziomo";
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////
        ////////////// ROZSTAWIENIE STATKOW KOMPUTERA
        //////////////////////////////////////////////////////////////////////////////////////////////

        Random random = new Random();
        private void ComputerPlaning()
        {
            int PC_FleetSize = -1;
            int i = 0;
            foreach (var item in listBoxFleet.Items)
            {
                StatusLabel.Text = "Czekaj, przeciwnik ustawia pozycje statku: " + item.ToString();
                Application.DoEvents();
                switch (i)
                {
                    case 0: PC_FleetSize = 5; break;
                    case 1: PC_FleetSize = 4; break;
                    case 2: PC_FleetSize = 3; break;
                    case 3: PC_FleetSize = 3; break;
                    case 4: PC_FleetSize = 2; break;
                    default: PC_FleetSize = -1; break;
                }

                int PC_FleetOrient = random.Next(0, 2);
                ComputerSetFleetStep1(i, PC_FleetSize - 1, PC_FleetOrient);

                i++;
            }

            if (random.Next(0, 2) == 0)
            {
                StatusLabel.Text = "Przeciwnik rozmieścił wszystkie swoje statki. Możemy zaczynać bitwę! Pierwszy ruch należy do Ciebie.";
            }
            else
            {
                StatusLabel.Text = "Przygotuj się! Przeciwnik rozmieścił wszystkie swoje statki i zaraz wykona pierwszy ruch. Zaczekaj chwilę. ;)";
                EnemyRound_PC_randomHit();
                StatusLabel.Text = "Zaczynamy bitwę! Przeciwnik rozmieścił wszystkie swoje statki i wykonał pierwszy ruch. Teraz ty!";
            }
            labelBlockEnemyGride.Visible = false;
        }

        private List<string> grideEnemy_BlockedBoxes = new List<string>();
        Dictionary<string, int> grideEnemy_FleetBoxesArray = new Dictionary<string, int> { };
        ArrayList grideEnemy_FleetBoxesPosStrip1 = new ArrayList();
        ArrayList grideEnemy_FleetBoxesPosStrip2 = new ArrayList();
        ArrayList grideEnemy_FleetBoxesPosStrip3 = new ArrayList();
        ArrayList grideEnemy_FleetBoxesPosStrip4 = new ArrayList();
        ArrayList grideEnemy_FleetBoxesPosStrip5 = new ArrayList();
        private void ComputerSetFleetStep1(int IdShip, int FleetSize, int PC_FleetOrient)
        {
            int Start_posX = 0;
            int Start_posY = 0;
            if (PC_FleetOrient == 0)
            {
                Start_posX = random.Next(1, 11 - FleetSize);
                Start_posY = random.Next(1, 11);
            }
            else
            {
                Start_posX = random.Next(1, 11);
                Start_posY = random.Next(1, 11 - FleetSize);
            }

            ComputerSetFleetStep2(IdShip, FleetSize, PC_FleetOrient, Start_posX, Start_posY);
        }

        private void ComputerSetFleetStep2(int IdShip, int FleetSize, int PC_FleetOrient, int Start_posX, int Start_posY)
        {
            for (int i = 0; i <= FleetSize; i++)
            {
                int posX = Start_posX;
                int posY = Start_posY;
                if (PC_FleetOrient == 0)
                    posX += i;
                else
                    posY += i;
                if (grideEnemy_BlockedBoxes.FindIndex(item => item == (posX + "," + posY)) >= 0)
                {
                    ComputerSetFleetStep1(IdShip, FleetSize, PC_FleetOrient);
                    return;
                }
            }

            for (int i = 0; i <= FleetSize; i++)
            {
                int posX = Start_posX;
                int posY = Start_posY;
                if (PC_FleetOrient == 0)
                    posX += i;
                else
                    posY += i;

                grideEnemy_FleetBoxesArray.Add((posX) + "," + (posY), IdShip);

                int[] idPole = new int[] { posX, posY };
                int[] nowStartPosBox = func.grideMy_GetStartPos(idPole);

                PictureBox ObjectAdd1 = grideEnemy_CreateColorBox(nowStartPosBox[0], nowStartPosBox[1]);////////box view
                grideEnemy_FleetPictureBox_Enemy.Add(idPole[0] + "," + idPole[1], ObjectAdd1);

                grideEnemy_BlockedBoxes.Add((posX - 1) + "," + (posY - 1));
                grideEnemy_BlockedBoxes.Add((posX - 1) + "," + (posY));
                grideEnemy_BlockedBoxes.Add((posX - 1) + "," + (posY + 1));

                grideEnemy_BlockedBoxes.Add((posX) + "," + (posY - 1));
                grideEnemy_BlockedBoxes.Add((posX) + "," + (posY));//grideMy_BlockedBoxes.Add(item.Key);
                grideEnemy_BlockedBoxes.Add((posX) + "," + (posY + 1));

                grideEnemy_BlockedBoxes.Add((posX + 1) + "," + (posY - 1));
                grideEnemy_BlockedBoxes.Add((posX + 1) + "," + (posY));
                grideEnemy_BlockedBoxes.Add((posX + 1) + "," + (posY + 1));
            }
        }

        private PictureBox grideEnemy_CreateColorBox(int StartPosBoxX, int StartPosBoxY)
        {
            PictureBox pictureBoxCheck = new PictureBox();
            pictureBoxCheck.BackColor = Color.Gainsboro; //SystemColors.ControlDark
            pictureBoxCheck.Location = new Point(StartPosBoxX, StartPosBoxY);
            pictureBoxCheck.Name = "pictureName";
            pictureBoxCheck.Size = new System.Drawing.Size(33, 32);
            pictureBoxCheck.TabIndex = 0;
            pictureBoxCheck.TabStop = false;
            pictureBoxCheck.Visible = false;
            pictureBoxCheck.MouseMove += new MouseEventHandler(grideEnemy_MouseMove);
            pictureBoxCheck.Click += new EventHandler(grideEnemy_Click);

            grideEnemy.Controls.Add(pictureBoxCheck);

            return pictureBoxCheck;
        }

        private int[] StripHitted_Enemy = new int[5] { 0, 0, 0, 0, 0 };
        private int[] StripHittedMax_Enemy = new int[5] { 5, 4, 3, 3, 2 };
        private int StripFullHittedCount_onEnemyGride = 0;

        private bool grideEnemy_BlockClicking = false;
        private void grideEnemy_BlockClicking_change(bool isblock)
        {
            grideEnemy_BlockClicking = isblock;
        }

        private void grideEnemy_Click(object sender, EventArgs e)
        {
            if (nowMousePosBoxName_Enemy != "-" && grideEnemy_BlockClicking == false)
            {
                grideEnemy_BlockClicking_change(true);

                int[] idPole_Enemy = func.grideMy_GetIdBox(nowMousePosBoxName_Enemy);

                if (grideEnemy_FleetBoxesHitted.FindIndex(item => item == (idPole_Enemy[0] + "," + idPole_Enemy[1])) >= 0)
                {
                    /////////////jesli klikasz w juz raz trafione pole przeciwnika
                    StatusLabel.Text = "Po co wybierasz już raz trafione pole? Wybierz inne!";
                    grideEnemy_BlockClicking_change(false);
                    return;
                }

                if (grideEnemy_FleetBoxesArray.ContainsKey(idPole_Enemy[0] + "," + idPole_Enemy[1]))
                {
                    //jezeli trafiasz w statek
                    int IdStripHitted = grideEnemy_FleetBoxesArray.FirstOrDefault(x => x.Key == (idPole_Enemy[0] + "," + idPole_Enemy[1])).Value;
                    StripHitted_Enemy[IdStripHitted]++;

                    switch (IdStripHitted)
                    {
                        case 0: grideEnemy_FleetBoxesPosStrip1.Add(idPole_Enemy[0] + "," + idPole_Enemy[1]); break;
                        case 1: grideEnemy_FleetBoxesPosStrip2.Add(idPole_Enemy[0] + "," + idPole_Enemy[1]); break;
                        case 2: grideEnemy_FleetBoxesPosStrip3.Add(idPole_Enemy[0] + "," + idPole_Enemy[1]); break;
                        case 3: grideEnemy_FleetBoxesPosStrip4.Add(idPole_Enemy[0] + "," + idPole_Enemy[1]); break;
                        case 4: grideEnemy_FleetBoxesPosStrip5.Add(idPole_Enemy[0] + "," + idPole_Enemy[1]); break;
                    }

                    if (StripHitted_Enemy[IdStripHitted] >= StripHittedMax_Enemy[IdStripHitted])
                    {
                        ArrayList FleetBoxesPosStrip = null;
                        switch (IdStripHitted)
                        {
                            case 0: FleetBoxesPosStrip = grideEnemy_FleetBoxesPosStrip1; break;
                            case 1: FleetBoxesPosStrip = grideEnemy_FleetBoxesPosStrip2; break;
                            case 2: FleetBoxesPosStrip = grideEnemy_FleetBoxesPosStrip3; break;
                            case 3: FleetBoxesPosStrip = grideEnemy_FleetBoxesPosStrip4; break;
                            case 4: FleetBoxesPosStrip = grideEnemy_FleetBoxesPosStrip5; break;
                        }
                        if (FleetBoxesPosStrip == null) { MessageBox.Show("[E:1] Nieoczekiwany błąd! Zalecamy restart aplikacji."); }

                        foreach (string item_idPole in FleetBoxesPosStrip)
                        {
                            PictureBox pictureBoxFullStripHitted = grideEnemy_FleetPictureBox_Enemy.FirstOrDefault(x => x.Key == item_idPole).Value;
                            pictureBoxFullStripHitted.BackColor = Color.Red;
                            pictureBoxFullStripHitted.Visible = true;
                        }

                        StripFullHittedCount_onEnemyGride += StripHitted_Enemy[IdStripHitted];
                        if (StripFullHittedCount_onEnemyGride >= 17)
                        {
                            /////////////// koniec gry
                            StatusLabel.Text = "Hura!!! Odnieśliśmy zwycięstwo! Możesz być z siebie dumny. :D";
                            MessageBox.Show("Wygrałeś! Gratulacje! :)");
                            grideEnemy_BlockClicking = true;
                            return;
                        }
                    }
                    else
                    {
                        PictureBox pictureBoxHitted = grideEnemy_FleetPictureBox_Enemy.FirstOrDefault(x => x.Key == (idPole_Enemy[0] + "," + idPole_Enemy[1])).Value;
                        pictureBoxHitted.BackColor = Color.LightSalmon;
                        pictureBoxHitted.Visible = true;
                    }
                }

                int[] nowStartPosBox_Enemy = func.grideMy_GetStartPos(idPole_Enemy);
                int drawPosX = nowStartPosBox_Enemy[0] + 12;
                int drawPosY = nowStartPosBox_Enemy[1] + 11;

                drawline(grideEnemy, drawPosX, drawPosY, drawPosX + 8, drawPosY + 8, Color.Gray, 4);
                drawline(grideEnemy, drawPosX, drawPosY + 8, drawPosX + 8, drawPosY, Color.Gray, 4);

                grideEnemy_FleetBoxesHitted.Add(idPole_Enemy[0] + "," + idPole_Enemy[1]);
                PlayerRound_changePC();
            }
        }

        private void PlayerRound_changePC()
        {
            StatusLabel.Text = "Wykonałeś swoj ruch. Teraz czekamy na ruch komputera!";
            timerEnemyRound.Enabled = true;
        }

        private List<string> grideMy_FleetBoxesHitted_FromPC = new List<string>();

        private void timerEnemyRound_Tick(object sender, EventArgs e)
        {
            timerEnemyRound.Enabled = false;
            EnemyRound_PC_randomHit();
            grideEnemy_BlockClicking_change(false);
            StatusLabel.Text = "Komputer wykonał ruch. Teraz ty!";
        }
        private void buttonTestRandomHit_Click(object sender, EventArgs e)
        {
            EnemyRound_PC_randomHit();
        }

        Dictionary<string, int> grideMy_FleetBoxesArray = new Dictionary<string, int> { };
        ArrayList grideMy_FleetBoxesPosStrip1 = new ArrayList();
        ArrayList grideMy_FleetBoxesPosStrip2 = new ArrayList();
        ArrayList grideMy_FleetBoxesPosStrip3 = new ArrayList();
        ArrayList grideMy_FleetBoxesPosStrip4 = new ArrayList();
        ArrayList grideMy_FleetBoxesPosStrip5 = new ArrayList();

        private int StripFullHittedCount_onMyGride = 0;

        private int[] first_lastHitStrip_PoleID = null;
        private int[] lastHitStrip_PoleID = null;
        private bool lastHitStrip = false;
        private int HittingStrip_lengthFull = 10;
        private int HittedStrip_lengthNow = 0;
        private char lastHitStrip_onWhatAxis = '-';
        private int HittingStrip_StripId = -1;

        private void EnemyRound_PC_randomHit()
        {
            int[] idPole_My = null;
            try
            {
                /////BEGIN/////comboBoxLevelPC.SelectedItem == "Średni" || "Trudny";
                if ((comboBoxLevelPC.SelectedItem.ToString() == "Średni" || comboBoxLevelPC.SelectedItem.ToString() == "Trudny") && first_lastHitStrip_PoleID != null)
                {
                    if (lastHitStrip_PoleID == first_lastHitStrip_PoleID)
                    {
                        int value;
                        lastHitStrip_onWhatAxis = (random.Next(0, 2) == 0) ? 'X' : 'Y';

                        if (lastHitStrip_PoleID[(lastHitStrip_onWhatAxis == 'X') ? 0 : 1] >= 10)
                            value = -1;
                        else if (lastHitStrip_PoleID[(lastHitStrip_onWhatAxis == 'X') ? 0 : 1] <= 1)
                            value = 1;
                        else
                            value = (random.Next(0, 2) == 0) ? -1 : 1;

                        if (lastHitStrip_onWhatAxis == 'X')
                            idPole_My = new int[2] { lastHitStrip_PoleID[0] + value, lastHitStrip_PoleID[1] };
                        else
                            idPole_My = new int[2] { lastHitStrip_PoleID[0], lastHitStrip_PoleID[1] + value };

                        foreach (KeyValuePair<int, List<string>> entry in grideMy_IdPosStripsInIdStrip)
                        {
                            if (entry.Value.Contains(first_lastHitStrip_PoleID[0] + "," + first_lastHitStrip_PoleID[1]) == true)
                            {
                                //jezli znajdzie
                                HittingStrip_StripId = entry.Key;
                                switch (entry.Key)
                                {
                                    case 0: HittingStrip_lengthFull = 5; break;
                                    case 1: HittingStrip_lengthFull = 4; break;
                                    case 2: HittingStrip_lengthFull = 3; break;
                                    case 3: HittingStrip_lengthFull = 3; break;
                                    case 4: HittingStrip_lengthFull = 2; break;
                                }
                            }
                        }
                        if (HittingStrip_lengthFull == 10) { MessageBox.Show("[E:2] Nieoczekiwany błąd! Zalecamy restart aplikacji."); }
                    }
                    else
                    {
                        int value;
                        if (lastHitStrip == false)
                        {//jesli NIE trafiony byl to...
                            if (lastHitStrip_onWhatAxis == 'X')
                            {
                                value = (first_lastHitStrip_PoleID[0] < lastHitStrip_PoleID[0]) ? -1 : 1;
                                idPole_My = new int[2] { first_lastHitStrip_PoleID[0] + value, first_lastHitStrip_PoleID[1] };
                            }
                            else
                            {
                                value = (first_lastHitStrip_PoleID[1] < lastHitStrip_PoleID[1]) ? -1 : 1;
                                idPole_My = new int[2] { first_lastHitStrip_PoleID[0], first_lastHitStrip_PoleID[1] + value };
                            }
                        }
                        else
                        {
                            if (lastHitStrip_PoleID[(lastHitStrip_onWhatAxis == 'X') ? 0 : 1] >= 10)
                                value = -1;
                            else if (lastHitStrip_PoleID[(lastHitStrip_onWhatAxis == 'X') ? 0 : 1] <= 1)
                                value = 1;
                            else
                                value = (random.Next(0, 2) == 0) ? -1 : 1;

                            if (lastHitStrip_onWhatAxis == 'X')
                                idPole_My = new int[2] { lastHitStrip_PoleID[0] + value, lastHitStrip_PoleID[1] };
                            else
                                idPole_My = new int[2] { lastHitStrip_PoleID[0], lastHitStrip_PoleID[1] + value };


                            if (grideMy_FleetBoxesHitted_FromPC.FindIndex(item => item == (idPole_My[0] + "," + idPole_My[1])) >= 0)
                            {
                                if (lastHitStrip_PoleID[(lastHitStrip_onWhatAxis == 'X') ? 0 : 1] >= 10)
                                    value = -1;
                                else if (lastHitStrip_PoleID[(lastHitStrip_onWhatAxis == 'X') ? 0 : 1] <= 1)
                                    value = 1;
                                else
                                    value = (value == 1) ? -1 : 1;

                                if (lastHitStrip_onWhatAxis == 'X')
                                    idPole_My = new int[2] { lastHitStrip_PoleID[0] + value, lastHitStrip_PoleID[1] };
                                else
                                    idPole_My = new int[2] { lastHitStrip_PoleID[0], lastHitStrip_PoleID[1] + value };

                                int val_i = 0;
                                while (grideMy_FleetBoxesHitted_FromPC.FindIndex(item => item == (idPole_My[0] + "," + idPole_My[1])) >= 0)
                                {
                                    val_i++;
                                    if (lastHitStrip_onWhatAxis == 'X')
                                    {
                                        if(lastHitStrip_PoleID[0] < first_lastHitStrip_PoleID[0])
                                            idPole_My = new int[2] { lastHitStrip_PoleID[0] + val_i, lastHitStrip_PoleID[1] };
                                        else
                                            idPole_My = new int[2] { lastHitStrip_PoleID[0] - val_i, lastHitStrip_PoleID[1] };
                                    }
                                    else
                                    {
                                        if (lastHitStrip_PoleID[1] < first_lastHitStrip_PoleID[1])
                                            idPole_My = new int[2] { lastHitStrip_PoleID[0], lastHitStrip_PoleID[1] + val_i };
                                        else
                                            idPole_My = new int[2] { lastHitStrip_PoleID[0], lastHitStrip_PoleID[1] - val_i };
                                    }
                                }
                            }
                        }
                    }
                }
                /////END/////comboBoxLevelPC.SelectedItem == "Średni" || "Trudny";
                else
                {
                    idPole_My = new int[2] { random.Next(1, 11), random.Next(1, 11) };
                }

                if (grideMy_FleetBoxesHitted_FromPC.FindIndex(item => item == (idPole_My[0] + "," + idPole_My[1])) >= 0)
                {
                    /////////////jesli PC wybierze juz raz trafione moje pole
                    ////////// blad w if() gdy wszystkie wybrane
                    EnemyRound_PC_randomHit();
                    return;
                }

                if (grideMy_MyFleetPictureBox.ContainsKey(idPole_My[0] + "," + idPole_My[1]))
                {
                    //jezeli PC - trafi w statek
                    PictureBox pictureBoxFullStripHitted = grideMy_MyFleetPictureBox.FirstOrDefault(x => x.Key == (idPole_My[0] + "," + idPole_My[1])).Value;
                    pictureBoxFullStripHitted.BackColor = Color.LightSalmon;
                    //pictureBoxFullStripHitted.Visible = true;
                    StripFullHittedCount_onMyGride++;
                    if (StripFullHittedCount_onMyGride >= 17)
                    {
                        /////////////// koniec gry
                        StatusLabel.Text = "O nie! Wróg zniszczył nasz ostatni statek! Ponieśliśmy porażkę...";
                        MessageBox.Show("Przegrałeś. Przeciwnik zniszczył wszystkie twoje statki.");
                        grideEnemy_BlockClicking = true;
                        ShowFleet_OnGrideEnemy();
                        return;
                    }

                    HittedStrip_lengthNow++;

                    /////BEGIN/////comboBoxLevelPC.SelectedItem == "Łatwy";
                    if (comboBoxLevelPC.SelectedItem.ToString() == "Łatwy")
                    {//////////edit! -- kolorowanie statku na czerwono na twoim polu gdy jest caly trafiony (do dokonczenia)
                        foreach (KeyValuePair<int, List<string>> entry in grideMy_IdPosStripsInIdStrip)
                        {
                            if (entry.Value.Contains(idPole_My[0] + "," + idPole_My[1]) == true)
                            {
                                //jezli znajdzie
                                bool stripHittedFull = true;
                                foreach (string item_posID in grideMy_IdPosStripsInIdStrip[entry.Key])
                                {
                                    if (stripHittedFull == false)
                                        break;

                                    if (item_posID != (idPole_My[0] + "," + idPole_My[1]) && grideMy_FleetBoxesHitted_FromPC.FindIndex(item => item == (item_posID)) < 0)
                                        stripHittedFull = false;
                                }

                                if (stripHittedFull == true)
                                {
                                    foreach (string item_posID in grideMy_IdPosStripsInIdStrip[entry.Key])
                                    {
                                        PictureBox picture = grideMy_MyFleetPictureBox.FirstOrDefault(x => x.Key == item_posID).Value;
                                        picture.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    /////END /////comboBoxLevelPC.SelectedItem == "Łatwy";

                    /////BEGIN/////comboBoxLevelPC.SelectedItem == "Trudny" || "Średni";
                    if (comboBoxLevelPC.SelectedItem.ToString() == "Średni" || comboBoxLevelPC.SelectedItem.ToString() == "Trudny")
                    {
                        if (HittedStrip_lengthNow >= HittingStrip_lengthFull)
                        {
                            foreach (string item_posID in grideMy_IdPosStripsInIdStrip[HittingStrip_StripId])
                            {
                                PictureBox picture = grideMy_MyFleetPictureBox.FirstOrDefault(x => x.Key == item_posID).Value;
                                picture.BackColor = Color.Red;
                            }
                            /////BEGIN/////comboBoxLevelPC.SelectedItem == "Trudny";
                            if (comboBoxLevelPC.SelectedItem.ToString() == "Trudny")
                            {
                                foreach (var ship_posId in grideMy_IdPosStripsInIdStrip[HittingStrip_StripId])
                                {
                                    int[] idPole_My_BOT = ship_posId.Split(',').Select(Int32.Parse).ToArray();

                                    grideMy_FleetBoxesHitted_FromPC.Add((idPole_My_BOT[0] - 1) + "," + (idPole_My_BOT[1] - 1));
                                    grideMy_FleetBoxesHitted_FromPC.Add((idPole_My_BOT[0] - 1) + "," + (idPole_My_BOT[1]));
                                    grideMy_FleetBoxesHitted_FromPC.Add((idPole_My_BOT[0] - 1) + "," + (idPole_My_BOT[1] + 1));

                                    grideMy_FleetBoxesHitted_FromPC.Add((idPole_My_BOT[0]) + "," + (idPole_My_BOT[1] - 1));
                                    grideMy_FleetBoxesHitted_FromPC.Add((idPole_My_BOT[0]) + "," + (idPole_My_BOT[1]));//grideMy_BlockedBoxes.Add(item.Key);
                                    grideMy_FleetBoxesHitted_FromPC.Add((idPole_My_BOT[0]) + "," + (idPole_My_BOT[1] + 1));

                                    grideMy_FleetBoxesHitted_FromPC.Add((idPole_My_BOT[0] + 1) + "," + (idPole_My_BOT[1] - 1));
                                    grideMy_FleetBoxesHitted_FromPC.Add((idPole_My_BOT[0] + 1) + "," + (idPole_My_BOT[1]));
                                    grideMy_FleetBoxesHitted_FromPC.Add((idPole_My_BOT[0] + 1) + "," + (idPole_My_BOT[1] + 1));
                                }

                            }
                            /////END/////comboBoxLevelPC.SelectedItem == "Trudny";

                            first_lastHitStrip_PoleID = null;
                            lastHitStrip_PoleID = null;
                            lastHitStrip = false;
                            HittingStrip_lengthFull = 10;
                            HittedStrip_lengthNow = 0;
                            lastHitStrip_onWhatAxis = '-';
                            HittingStrip_StripId = -1;
                            
                        }
                        else
                        {
                            lastHitStrip_PoleID = new int[2] { idPole_My[0], idPole_My[1] };
                            if (first_lastHitStrip_PoleID == null)
                                first_lastHitStrip_PoleID = lastHitStrip_PoleID;
                            lastHitStrip = true;
                        }
                    }
                    /////END /////comboBoxLevelPC.SelectedItem == "Trudny" || "Średni";
                }
                else
                { //jezeli PC - NIE trafi w statek
                    lastHitStrip = false;
                }
                int[] StartPosBox_My = func.grideMy_GetStartPos(idPole_My);
                int drawPosX = StartPosBox_My[0] + 12;
                int drawPosY = StartPosBox_My[1] + 11;

                drawline(grideMy, drawPosX, drawPosY, drawPosX + 8, drawPosY + 8, Color.Gray, 4);
                drawline(grideMy, drawPosX, drawPosY + 8, drawPosX + 8, drawPosY, Color.Gray, 4);

                grideMy_FleetBoxesHitted_FromPC.Add(idPole_My[0] + "," + idPole_My[1]);
            }
            catch (IOException e)
            {
                // Extract some information from this exception, and then   
                // throw it to the parent method.  
                MessageBox.Show("IOException source: " + e.Source);
                throw;
            }
            catch (InvalidCastException e)
            {
                // Perform some action here, and then throw a new exception.  
                MessageBox.Show("InvalidCastException: " + e);
            }
        }

        public void drawline(PictureBox pb, int x1, int y1, int x2, int y2, Color c1, float Bwidth)
        {
            //refresh the picture box
            pb.Refresh();
            //create a new Bitmap object
            Bitmap map = (Bitmap)pb.Image;
            //create a graphics object
            Graphics g = Graphics.FromImage(map);
            //create a pen object and setting the color and width for the pen
            Pen p = new Pen(c1, Bwidth);
            //draw line between  point p1 and p2
            Point p1 = new Point();
            p1.X = x1; p1.Y = y1;
            Point p2 = new Point();
            p2.X = x2; p2.Y = y2;
            g.DrawLine(p, p1, p2);
            pb.Image = map;
            //dispose pen and graphics object
            p.Dispose();
            g.Dispose();
        }

        private string currnetSelectBox_Enemy = "-";
        private string nowMousePosBoxName_Enemy = "-";
        Dictionary<string, PictureBox> grideEnemy_FleetPictureBox_Enemy = new Dictionary<string, PictureBox> { };
        private List<string> grideEnemy_FleetBoxesHitted = new List<string>();
        private void grideEnemy_MouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
            Point pos = grideEnemy.PointToClient(Cursor.Position);

            int poleX = ((pos.X - 35) / 34) + 1;
            int poleY = ((pos.Y - 35) / 33) + 1;
            if ((pos.X - 35) < 0 || (pos.Y - 35) < 0 || pos.X > 373 || pos.Y > 362)
            {
                currnetSelectBox_Enemy = "-";
                toolStatus_PoleID.Text = currnetSelectBox_Enemy;
                nowMousePosBoxName_Enemy = currnetSelectBox_Enemy;
                return;
            }
            currnetSelectBox_Enemy = cfg.letter[poleY] + poleX.ToString();
            toolStatus_PoleID.Text = currnetSelectBox_Enemy;
            if (nowMousePosBoxName_Enemy == currnetSelectBox_Enemy)
                return;

            nowMousePosBoxName_Enemy = currnetSelectBox_Enemy;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Bierząca gra zostanie zamknięta." + Environment.NewLine + Environment.NewLine + "Czy napewno chcesz zacząć od nowa?", "Nowa gra",MessageBoxButtons.YesNoCancel))
                Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnemyRound_PC_randomHit();
        }
    }
}
