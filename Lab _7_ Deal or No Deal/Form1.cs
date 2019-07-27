// Jose Cabral
// 12/06/2018
// Lab # 7 - Deal or No Deal
// In this Lab, you will make the game Deal or no Deal.
// Make sure to follow the american rules of Deal or no Deal.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab__7__Deal_or_No_Deal
{
    public partial class Form1 : Form
    {
        double[] arrayDeal = new double[26];
        double[] arrayLiability = new double[26];
        double[] arrayGoldCase = new double[1];

        double CaseAmount = 0, Liability_cash = 0, Offer_Amount = 0;
        int CaseIndex = 0, n = 0;
        int IIndex, FIndex;
        bool isClicked = true;

        int Case_Counter = 26;
        Dictionary<double, Label> LabelChange;


        public Form1()
        {
            InitializeComponent();
        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int i;

            Random numGen = new Random();

            lbl_numCasesLeft.Text = Convert.ToString(Case_Counter);

            List<double> Value = new List<double>() { 0.01, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000, 50000, 75000, 100000, 200000, 300000, 400000, 500000, 750000, 1000000 };

            for (i = 0; i < 26; i++)
            {
                int k = numGen.Next(0, Value.Count);
                arrayDeal[i] = Value[k];
                Value.RemoveAt(k);
                arrayLiability[i] = arrayDeal[i];

            }

            LabelChange = new Dictionary<double, Label>()
            {
                {0.01,lbl_01}, {1, lbl_1 }, {5, lbl_5}, {10, lbl_10}, {25, lbl_25}, {50, lbl_50}, {75, lbl_75}, {100, lbl_100}, {200, lbl_200}, {300, lbl_300},
                {400, lbl_400}, {500, lbl_500}, {750, lbl_750K}, {1000, lbl_1K}, {5000, lbl_5K}, {10000, lbl_10K}, {25000, lbl_25K}, {50000, lbl_50K}, {75000, lbl_75K},
                { 100000, lbl_100K}, {200000, lbl_200K}, {300000, lbl_300K}, {400000, lbl_400K}, {500000, lbl_500K}, {750000, lbl_750K}, {1000000, lbl_1000K},

            };

            lbl_Update.Text = "Choice your golden case.";

        }

        private void LabelControl()
        {

            CaseAmount = Convert.ToDouble(arrayDeal[CaseIndex]);


            if (LabelChange.ContainsKey(CaseAmount) == true)
            {

                LabelChange.TryGetValue(CaseAmount, out Label label);
                label.BackColor = System.Drawing.Color.Gray;
                CaseAmount = 0;
            }
        }


        private void btn_Case_Click(object sender, EventArgs e)
        {
            Button myBtn = (Button)sender;// (sender as Button);
            string clickedNum = (sender as Button).Text;
            CaseIndex = (Convert.ToInt32(clickedNum)) - 1;
            double caseValue = arrayDeal[CaseIndex];

            //Hunt down the value in liability and set to zero
            for (int i = 0; i < arrayLiability.Length - 1; i++)
            {
                if (arrayLiability[i] == caseValue)
                {
                    arrayLiability[i] = 0;
                }
            }

            if ((Case_Counter == 26) && (n == 0))
            {
                lbl_Update.Text = "Eliminate your first round of 6 Cases";
                n++;
                lbl_UrCase.Text = Convert.ToString(clickedNum);
                myBtn.BackColor = Color.Goldenrod;
                arrayGoldCase[0] = arrayDeal[CaseIndex];
            }

            else
            {
                LabelControl();
                Case_Counter--;
            }


            if ((Case_Counter < 26) && (Case_Counter > 21))
                lbl_Update.Text = "Eliminate your first round of 6 Cases";

            if ((Case_Counter < 21)  && (Case_Counter > 16))
                lbl_Update.Text = "Eliminate your second round of 5 Cases";

            if ((Case_Counter < 16) && (Case_Counter > 12))
                lbl_Update.Text = "Eliminate your third round of 4 Cases";

            if ((Case_Counter < 12) && (Case_Counter > 8))
                lbl_Update.Text = "Eliminate your fourth round of 3 Cases";

            if ((Case_Counter == 8) || (Case_Counter == 7))
                lbl_Update.Text = "Eliminate your fifth round of 2 Cases";

            if (Case_Counter == 6 )
                lbl_Update.Text = "Eliminate your sixth round of 1 Cases";

            if (Case_Counter == 5)
                lbl_Update.Text = "Eliminate your seventh round of 1 Cases";

            if (Case_Counter == 4)
                lbl_Update.Text = "Eliminate your eight round round 1 Cases";

            if (Case_Counter ==3)
                lbl_Update.Text = "Eliminate your nineth round of 1 Cases";


            if (Case_Counter == 2)
                lbl_Update.Text = "Do you want to FLIP CASES";

            
            (sender as Button).Enabled = false;
            lbl_PickCase.Text = Convert.ToString(clickedNum);

            lbl_numCasesLeft.Text = Convert.ToString(Case_Counter);

            Liability();

            if (Case_Counter == 20)
            {
                IIndex = 10;
                FIndex = 25;
                BankerOffer();
            }

            if (Case_Counter == 15)
            {
                IIndex = 25;
                FIndex = 40;
                BankerOffer();
            }

            if (Case_Counter == 11)
            {
                IIndex = 30;
                FIndex = 55;
                BankerOffer();
            }

            if (Case_Counter == 8)
            {
                IIndex = 45;
                FIndex = 75;
                BankerOffer();
            }

            if (Case_Counter == 6)
            {
                IIndex = 65;
                FIndex = 85;
                BankerOffer();

            }

            if (Case_Counter == 5)
            {
                IIndex = 75;
                FIndex = 95;
                BankerOffer();
            }

            if (Case_Counter == 4 || Case_Counter == 3)
            {
                IIndex = 85;
                FIndex = 100;
                BankerOffer();

            }

            if (Case_Counter == 2)
            {
                label1.Text = "FLIP CASES";
                lbl_ur_Money.Text = "00";

            }

        }

        private void Not_Deal_Click(object sender, EventArgs e)
        {

            if (isClicked)
            {
                label1.Text = "NO DEAL";

                lbl_ur_Money.Text = Convert.ToString(Offer_Amount);

            }

            if ((isClicked) && (Case_Counter == 2))

            { 
                label1.Text = "YOU WIN !!";

                lbl_ur_Money.Text = Convert.ToString(arrayGoldCase[0]);
                lbl_PickCase.Text = Convert.ToString(arrayGoldCase[0]);

                lbl_numCasesLeft.Text = "0";
            }

        }

        private void Deal_Click(object sender, EventArgs e)
        {
            label1.Text = "YOU WIN !!";

            lbl_ur_Money.Text = Convert.ToString(arrayGoldCase[0]);
            lbl_numCasesLeft.Text = "0";


            if ((isClicked) && (Case_Counter == 2))

            {
                label1.Text = "YOU WIN !!";

                lbl_ur_Money.Text = Convert.ToString(arrayGoldCase[0]);
                lbl_PickCase.Text = "0";

                lbl_numCasesLeft.Text = "0";
            }


        }

        private void Liability()
        {

            Liability_cash = 0;

            for (int m = 0; m < 26; m++)
            {
                Liability_cash = Liability_cash + arrayLiability[m];

            }

            Liability_cash = Liability_cash / Case_Counter;
            //MessageBox.Show(Liability_cash.ToString());

        }

        private void Deal_Not_Deal_Click(object sender, EventArgs e)
        {

            if ((isClicked) && (Case_Counter == 2))
            {
                label1.Text = "YOU WIN !!";
                lbl_ur_Money.Text = Convert.ToString(arrayGoldCase[0]);

            }

        }

        private void BankerOffer()
        {


            string message = "The Banker wants to buy your Golden Case.  An offer is been submited for your consideration";
            string title = "DEAL or NO DEAL";
            MessageBox.Show(message, title);

            Offer_Amount = 0;
            Random r = new Random();
            double rMul = r.Next(IIndex, FIndex);

            Offer_Amount = Liability_cash * (rMul/100);
            label1.Text = "BANKER OFFER";
            Offer_Amount = Convert.ToUInt32(Offer_Amount);
            lbl_ur_Money.Text = Convert.ToString(Offer_Amount);
        }

    }
}
