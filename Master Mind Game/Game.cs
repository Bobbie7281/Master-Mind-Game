using System.Data;

namespace Master_Mind_Game
{
    public partial class Game : Form
    {
        readonly Game_Functionality obj = new();
        List<Label> results = new();
        readonly List<Label> secretCode = new();
        List<int> guesses = new();
        bool reset_Board = false;
        int test = 0;
        int previousValue = 0;
        int currentValue = 0;
        public Game()
        {
            InitializeComponent();
        }

        private void Game2_Load(object sender, EventArgs e)
        {
            obj.SetSecretCode();
            secretCode.Add(Lbl_SecretCode_One);
            secretCode.Add(Lbl_SecretCode_Two);
            secretCode.Add(Lbl_SecretCode_Three);
            secretCode.Add(Lbl_SecretCode_Four);

            Gpb_Result_Row_One.Enabled = true;
        }
        private void CheckGuess(object sender, EventArgs e)
        {
            if (obj.FirstNum > 0 && obj.SecondNum > 0 && obj.ThirdNum > 0 && obj.FourthNum > 0)
            {
                SetResultsAndGuessesLists(obj.ResOne, obj.ResTwo, obj.ResThree, obj.ResFour,
                          obj.FirstNum, obj.SecondNum, obj.ThirdNum, obj.FourthNum);

                obj.RowNumber++;
                bool gameResult = DisplayResult(obj.RowNumber);

                if (!gameResult)
                {
                    switch (obj.RowNumber)
                    {
                        case 1:
                            EnableAndDisableRows(Gpb_Row_One, Gpb_Row_Two, Gpb_Result_Row_Two, Nud_Num_One_Row_One, Nud_Num_Two_Row_One, Nud_Num_Three_Row_One,
                                Nud_Num_Four_Row_One, Nud_Num_One_Row_Two, Nud_Num_Two_Row_Two, Nud_Num_Three_Row_Two, Nud_Num_Four_Row_Two, Btn_Check_Row_One,
                                Btn_Check_Row_Two);
                            break;
                        case 2:
                            EnableAndDisableRows(Gpb_Row_Two, Gpb_Row_Three, Gpb_Result_Row_Three, Nud_Num_One_Row_Two, Nud_Num_Two_Row_Two, Nud_Num_Three_Row_Two,
                                Nud_Num_Four_Row_Two, Nud_Num_One_Row_Three, Nud_Num_Two_Row_Three, Nud_Num_Three_Row_Three, Nud_Num_Four_Row_Three, Btn_Check_Row_Two,
                                Btn_Check_Row_Three);
                            break;
                        case 3:
                            EnableAndDisableRows(Gpb_Row_Three, Gpb_Row_Four, Gpb_Result_Row_Four, Nud_Num_One_Row_Three, Nud_Num_Two_Row_Three, Nud_Num_Three_Row_Three,
                                Nud_Num_Four_Row_Three, Nud_Num_One_Row_Four, Nud_Num_Two_Row_Four, Nud_Num_Three_Row_Four, Nud_Num_Four_Row_Four, Btn_Check_Row_Three,
                                Btn_Check_Row_Four);
                            break;
                        case 4:
                            EnableAndDisableRows(Gpb_Row_Four, Gpb_Row_Five, Gpb_Result_Row_Five, Nud_Num_One_Row_Four, Nud_Num_Two_Row_Four, Nud_Num_Three_Row_Four,
                                Nud_Num_Four_Row_Four, Nud_Num_One_Row_Five, Nud_Num_Two_Row_Five, Nud_Num_Three_Row_Five, Nud_Num_Four_Row_Five, Btn_Check_Row_Four,
                                Btn_Check_Row_Five);
                            break;
                        case 5:
                            EnableAndDisableRows(Gpb_Row_Five, Gpb_Row_Six, Gpb_Result_Row_Six, Nud_Num_One_Row_Five, Nud_Num_Two_Row_Five, Nud_Num_Three_Row_Five,
                                Nud_Num_Four_Row_Five, Nud_Num_One_Row_Six, Nud_Num_Two_Row_Six, Nud_Num_Three_Row_Six, Nud_Num_Four_Row_Six, Btn_Check_Row_Five,
                                Btn_Check_Row_Six);
                            break;
                        case 6:
                            EnableAndDisableRows(Gpb_Row_Six, Gpb_Row_Seven, Gpb_Result_Row_Seven, Nud_Num_One_Row_Six, Nud_Num_Two_Row_Six, Nud_Num_Three_Row_Six,
                                Nud_Num_Four_Row_Six, Nud_Num_One_Row_Seven, Nud_Num_Two_Row_Seven, Nud_Num_Three_Row_Seven, Nud_Num_Four_Row_Seven, Btn_Check_Row_Six,
                                Btn_Check_Row_Seven);
                            break;
                        case 7:
                            EnableAndDisableRows(Gpb_Row_Seven, Gpb_Row_Eight, Gpb_Result_Row_Eight, Nud_Num_One_Row_Seven, Nud_Num_Two_Row_Seven, Nud_Num_Three_Row_Seven,
                                Nud_Num_Four_Row_Seven, Nud_Num_One_Row_Eight, Nud_Num_Two_Row_Eight, Nud_Num_Three_Row_Eight, Nud_Num_Four_Row_Eight, Btn_Check_Row_Seven,
                                Btn_Check_Row_Eight);
                            break;
                        case 8:
                            EnableAndDisableRows(Gpb_Row_Eight, Gpb_Row_Nine, Gpb_Result_Row_Nine, Nud_Num_One_Row_Eight, Nud_Num_Two_Row_Eight, Nud_Num_Three_Row_Eight,
                                Nud_Num_Four_Row_Eight, Nud_Num_One_Row_Nine, Nud_Num_Two_Row_Nine, Nud_Num_Three_Row_Nine, Nud_Num_Four_Row_Nine, Btn_Check_Row_Eight,
                                Btn_Check_Row_Nine);
                            break;
                        case 9:
                            EnableAndDisableRows(Gpb_Row_Nine, Gpb_Row_Ten, Gpb_Result_Row_Ten, Nud_Num_One_Row_Nine, Nud_Num_Two_Row_Nine, Nud_Num_Three_Row_Nine,
                                Nud_Num_Four_Row_Nine, Nud_Num_One_Row_Ten, Nud_Num_Two_Row_Ten, Nud_Num_Three_Row_Ten, Nud_Num_Four_Row_Ten, Btn_Check_Row_Nine,
                                Btn_Check_Row_Ten);
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("0's are not accepted. Please choose a number from 1 to 8", "Input not valid!!");
            }
        }
        private void SetResultsAndGuessesLists(Label resOne, Label resTwo, Label resThree, Label resFour,
            int numOne, int numTwo, int numThree, int numFour)
        {
            /*resOne.Text = "-";
            resTwo.Text = "-";
            resThree.Text = "-";
            resFour.Text = "-";*/

            results = new List<Label>()
            {
              resOne,
              resTwo,
              resThree,
              resFour,
            };
            guesses = new List<int>()
            {
               numOne,
               numTwo,
               numThree,
               numFour,
            };
        }
        private void EnableAndDisableRows(GroupBox currentRow, GroupBox nextRow, GroupBox nextResult,
            NumericUpDown firstNumCurrentRow, NumericUpDown secondNumCurrentRow, NumericUpDown thirdNumCurrentRow, NumericUpDown fourthNumCurrentRow,
            NumericUpDown firstNumNextRow, NumericUpDown secondNumNextRow, NumericUpDown thirdNumNextRow, NumericUpDown fouthNumNextRow, Button currentCheck,
            Button nextCheck)
        {
            nextResult.Enabled = true;
            currentRow.Enabled = false;

            /*firstNumCurrentRow.BackColor = Color.Gray;
            secondNumCurrentRow.BackColor = Color.Gray;
            thirdNumCurrentRow.BackColor = Color.Gray;
            fourthNumCurrentRow.BackColor = Color.Gray;

            firstNumNextRow.BackColor = Color.Green;
            secondNumNextRow.BackColor = Color.Green;
            thirdNumNextRow.BackColor = Color.Green;
            fouthNumNextRow.BackColor = Color.Green;*/

            nextRow.Enabled = true;
            currentRow.Enabled = false;

            nextCheck.Enabled = true;
            currentCheck.Enabled = false;

            obj.FirstNum = 0;
            obj.SecondNum = 0;
            obj.ThirdNum = 0;
            obj.FourthNum = 0;
        }
        private bool DisplayResult(int rowNumber)
        {
            var result = obj.CheckGuess(guesses).OrderByDescending(x => x).ToList();

            int goodGuesses = 0;
            bool gameResult = false;

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] == 1) { goodGuesses++; }
                results[i].Text = result[i].ToString();
            }
            if (goodGuesses == 4)
            {
                ShowSecretCode();
                MessageBox.Show("Well Done! You Cracked the Code! :)", "Code Cracked :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gameResult = true;
            }
            else if (goodGuesses < 4 && rowNumber == 10)
            {
                ShowSecretCode();
                MessageBox.Show("Code Not Cracked!! Better Luck Next Time!!", "Game Over!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gameResult = true;
            }
            return gameResult;
        }
        private void ShowSecretCode()
        {
            for (int i = 0; i < secretCode.Count; i++)
            {
                secretCode[i].Text = obj.SecretCodes[i].ToString();
            }
        }
        private void Btn_Reset_Board_Click(object sender, EventArgs e)
        {
            reset_Board = true;
            List<GroupBox> resultGpb = new List<GroupBox>()
            { Gpb_Result_Row_One, Gpb_Result_Row_Two, Gpb_Result_Row_Three,
            Gpb_Result_Row_Four,Gpb_Result_Row_Five,Gpb_Result_Row_Six,Gpb_Result_Row_Seven,
            Gpb_Result_Row_Eight,Gpb_Result_Row_Nine,Gpb_Result_Row_Ten};

            List<GroupBox> rowGpb = new List<GroupBox>()
            { Gpb_Row_One,Gpb_Row_Two,Gpb_Row_Three,Gpb_Row_Four,Gpb_Row_Five,
            Gpb_Row_Six,Gpb_Row_Seven,Gpb_Row_Eight,Gpb_Row_Nine,Gpb_Row_Ten};

            List<Button> checkBtn = new List<Button>()
            { Btn_Check_Row_One,Btn_Check_Row_Two, Btn_Check_Row_Three, Btn_Check_Row_Four,Btn_Check_Row_Five,
            Btn_Check_Row_Six,Btn_Check_Row_Seven,Btn_Check_Row_Eight, Btn_Check_Row_Nine,Btn_Check_Row_Ten};

            foreach (GroupBox gpb in resultGpb)
            {
                gpb.Enabled = false;
            }
            foreach (GroupBox gpb in rowGpb)
            {
                if (!gpb.Enabled)
                {
                    gpb.Enabled = true;
                    gpb.Enabled = false;
                }
                else
                {
                    gpb.Enabled = false;
                }
            }
            foreach (Button btn in checkBtn)
            {
                btn.Enabled = false;
            }
            reset_Board = false;

            obj.RowNumber = 0;
            Lbl_SecretCode_One.Text = "?";
            Lbl_SecretCode_Two.Text = "?";
            Lbl_SecretCode_Three.Text = "?";
            Lbl_SecretCode_Four.Text = "?";

            obj.SetSecretCode();
            Gpb_Result_Row_One.Enabled = true;
            Gpb_Row_One.Enabled = true;
            Btn_Check_Row_One.Enabled = true;

        }

        //Event triggers when the value of the first numeric up down is changed
        private void NumOne(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            obj.FirstNum = Value_Check_And_reset(nud);
        }
        //Event triggers when the value of the second numeric up down is changed
        private void NumTwo(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            obj.SecondNum = Value_Check_And_reset(nud);
        }
        //Event triggers when the value of the third numeric up down is changed
        private void NumThree(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            obj.ThirdNum = Value_Check_And_reset(nud);
        }
        //Event triggers when the value of the fourth numeric up down is changed
        private void NumFour(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            obj.FourthNum = Value_Check_And_reset(nud);
        }
        private int Value_Check_And_reset(NumericUpDown nud)
        {
            if (nud.Value == 9)
            {
                nud.Value = 1;
            }
            else if (nud.Value == 0 || nud.Value == -1)
            {
                //To check when the value is being changed to 0 by a reset to prevent
                //the Numeric up downs values to change to 8 instead of a 0
                if (!reset_Board) { nud.Value = 8; }
                else { nud.Value = 0; }

            }
            return (int)nud.Value;
        }

        //Event triggers when the first result is either enabled or disabled.
        private void ResultOne(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Enabled)
            {
                obj.ResOne = lbl;
            }
            else { lbl.Text = "-"; }

        }
        //Event triggers when the second result is either enabled or disabled.
        private void ResultTwo(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Enabled)
            {
                obj.ResTwo = lbl;
            }
            else { lbl.Text = "-"; }

        }
        //Event triggers when the third result is either enabled or disabled.
        private void ResultThree(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Enabled)
            {
                obj.ResThree = lbl;
            }
            else { lbl.Text = "-"; }
        }
        //Event triggers when the fourth result is either enabled or disabled.
        private void ResultFour(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Enabled)
            {
                obj.ResFour = lbl;
            }
            else { lbl.Text = "-"; }
        }

        private void Result_Hover(object sender, EventArgs e)
        {
            GroupBox gpb = (GroupBox)sender;

            Result_Caption.SetToolTip(gpb, "Display result for the current row." +
                "\n1= One of the numbers is the right guess & in the right position." +
                "\n0= One of the numbers is the right guess but in the wrong position." +
                "\n-= Number/s are not part of the secret code");
        }
        private void Btn_Check_Hover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Check_Btn_Caption.SetToolTip(btn, "Check Your Guess!!");
        }


        //Event triggers when the first numeric up down button is either enabled or disabled.
        private void Num_One_Enabled_Changed(object sender, EventArgs e)
        {
            NumericUpDown nup = (NumericUpDown)sender;
            if (nup.Enabled && !reset_Board)
            {
                Set_Guess_BackColor(nup);
            }
            else if (!nup.Enabled)
            {
                Set_Guess_BackColor(nup);
            }
        }
        //Event triggers when the second numeric up down button is either enabled or disabled.
        private void Num_Two_Enabled_Changed(object sender, EventArgs e)
        {
            NumericUpDown nup = (NumericUpDown)sender;
            if (nup.Enabled && !reset_Board)
            {
                Set_Guess_BackColor(nup);
            }
            else if (!nup.Enabled)
            {
                Set_Guess_BackColor(nup);
            }
        }
        //Event triggers when the third numeric up down button is either enabled or disabled.
        private void Num_Three_Enabled_Changed(object sender, EventArgs e)
        {
            NumericUpDown nup = (NumericUpDown)sender;
            if (nup.Enabled && !reset_Board)
            {
                Set_Guess_BackColor(nup);
            }
            else if (!nup.Enabled)
            {
                Set_Guess_BackColor(nup);
            }
        }
        //Event triggers when the fourth numeric up down button is either enabled or disabled.
        private void Num_Four_Enabled_Changed(object sender, EventArgs e)
        {
            NumericUpDown nup = (NumericUpDown)sender;
            if (nup.Enabled && !reset_Board)
            {
                Set_Guess_BackColor(nup);
            }
            else if (!nup.Enabled)
            {
                Set_Guess_BackColor(nup);
            }
        }
        private void Set_Guess_BackColor(NumericUpDown nup)
        {
            if (nup.Enabled && !reset_Board) { nup.BackColor = Color.Green; }
            else
            {
                if (!reset_Board)
                {
                    nup.BackColor = Color.Gray;
                }
                else
                {
                    nup.Value = 0;
                    nup.BackColor = Color.Gray;
                }

            }
        }
    }
}

