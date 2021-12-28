using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace ROUNDS_Card_Maker
{
    public partial class Editor : Form
    {
        static String AppFileDir = Path.GetFullPath(Application.StartupPath);
        static String CardFolder = "\\Cards";
        static String NewCardName;
        String CardFileDir = (AppFileDir + CardFolder);
        String TemplateDir = (AppFileDir + CardFolder + "\\Template.cs");
        static String NewCardDir = (AppFileDir + CardFolder + "//" + NewCardName + ".cs");
        String Card;
        String GunStats;
        String GunStat;
        String GunStatValue;
        String NewGunStats;
        String StatTemplate = "             sgun.stat = num;";
        String GunStatOperation;
        String DefaultInfoStat =
            "            return new CardInfoStat[] { new CardInfoStat() { positive = true, stat = \"Effect\", amount = \"No\", simepleAmount = CardInfoStat.SimpleAmount.notAssigned } };";
        String NewInfoStat;
        String InfoStats;
        String RawInfoStat;
        String FormattedInfoStats;
        String DefaultRarity = "        CardInfo.Rarity rarity = CardInfo.Rarity.Common;";
        String NewRarity;
        String DefaultDescription = "        String description = \"TemplateDescription\";";
        String NewDescription;
        String ModID;
        String DefaultModID = "namespace TemplateModID.Cards";
        String NewModID;
        String CardID;
        String DefaultCardID = "    class TemplateCardID : CustomCard";
        String NewCardID;
        String ModInitials;
        String DefaultModInitials = "TInitials";
        String NewModInitials;
        String InfoStatSimpleAmount;
        String DefaultModInitialsCall = "            return \"TemplateModID.ModInitial\";";
        String NewModInitialsCall;
        String ModInitialsCall;
        String DefaultModName = "        String title = \"TemplateCardName\";";
        String NewModName;
        String ModName;
        String TemplateModInitials = "TemplateModID.ModInitials";
        String DefaultTheme = "CardThemeColor.CardThemeColorType theme = CardThemeColor.CardThemeColorType.ColdBlue;";
        String ExportPath = "";
        bool InfoStatsPositive;
        bool IsEnd = false;
        int InfoStatNum = 0;


        public Editor()
        {
            InitializeComponent();
            
        }

        private void siticoneGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(TemplateDir);
            NewCardName = siticoneTextBox4.Text;
            NewCardDir = (AppFileDir + CardFolder + "//" + NewCardName + ".cs");

            File.Copy(TemplateDir, NewCardDir);
            //File.Move(TemplateDir, NewCardDir);

            Card = File.ReadAllText(NewCardDir);


            RefreshCardTextView();

        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Editor_Load(object sender, EventArgs e)
        {
          
        }

        private void siticoneTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            File.Delete(NewCardDir);
            Card = "";
            FormattedInfoStats = "";
            GunStats = "";
            RefreshCardTextView();
            RefreshGunStats();
            RefreshInfoStats();
        }

        private void siticoneComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void siticoneButton9_Click(object sender, EventArgs e)
        {

            ModInitials = siticoneTextBox15.Text;
            NewModInitials = ModInitials;

            Card = Card.Replace(DefaultModInitials, NewModInitials);
            DefaultModInitials = NewModInitials;

            CardID = siticoneTextBox4.Text.Replace(" ", "");
            NewCardID = "    class " + CardID + ModInitials + " : CustomCard";

            Card = Card.Replace(DefaultCardID, NewCardID);
            DefaultCardID = NewCardID;
            siticoneTextBox13.Text = NewCardID;

            ModID = siticoneTextBox14.Text;
            NewModID = "namespace " + ModID + ".Cards";

            Card = Card.Replace(DefaultModID, NewModID);
            DefaultModID = NewModID;

            NewModInitialsCall = "            return \"" + ModID + ".ModInitials\";";

            ModInitialsCall = NewModInitialsCall;

            Card = Card.Replace(DefaultModInitialsCall, ModInitialsCall);
            DefaultModInitialsCall = ModInitialsCall;

            NewModName = "        String title = \"" + CardID + "\";";
            ModName = NewModName;

            Card = Card.Replace(DefaultModName, ModName);
            DefaultModName = ModName;

            Card = Card.Replace(TemplateModInitials, ModID + ".ModInitials");
            TemplateModInitials = ModID + ".ModInitials";

            String Data = Card.ToString();
            File.WriteAllText(NewCardDir, Data);

            RefreshCardTextView();
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Triggered");
            String Description = siticoneTextBox6.Text;
            NewDescription = "        String description = " + Description + ";";

            Card = Card.Replace(DefaultDescription, NewDescription);
            System.Diagnostics.Debug.WriteLine("String description = \"Template\";");
            System.Diagnostics.Debug.WriteLine("        String description = " + Description + ";");
            System.Diagnostics.Debug.WriteLine(Card);
            System.Diagnostics.Debug.WriteLine(Card.Contains("        String description = \"Template\";"));
            DefaultDescription = NewDescription;
            RefreshCardTextView();
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Triggered");
            String Rarity = siticoneComboBox2.Text;
            NewRarity = "        CardInfo.Rarity rarity = CardInfo.Rarity." + Rarity + ";";

            Card = Card.Replace(DefaultRarity, NewRarity);
            System.Diagnostics.Debug.WriteLine(Card.Contains(DefaultRarity));
            DefaultRarity = NewRarity;
            RefreshCardTextView();
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
            String Stat = siticoneTextBox7.Text;
            
            String Amount = siticoneTextBox5.Text;

            InfoStatSimpleAmount = siticoneComboBox5.Text;

            if (siticoneComboBox4.Text == "Positive")
            {
                InfoStatsPositive = true;
            } 
            else
            {
                InfoStatsPositive = false;
            }

            String TemplateInfoStat = 
            "return new CardInfoStat[]" +
            System.Environment.NewLine +
            "{" +
            System.Environment.NewLine +
            "    new CardInfoStat()" +
            System.Environment.NewLine +
            "    {" +
            System.Environment.NewLine +
            "        positive = true," +
            System.Environment.NewLine +
            "        stat = " + "\"" + "Effect" + "\"," +
            System.Environment.NewLine +
            "        amount = " + "\"" + "No" + "\"," +
            System.Environment.NewLine +
            "        simepleAmount = CardInfoStat.SimpleAmount.notAssigned" +
            System.Environment.NewLine +
            "    }" +
            System.Environment.NewLine +
            "};" +
            System.Environment.NewLine;

            Card = Card.Replace(DefaultInfoStat, TemplateInfoStat);

            DefaultInfoStat = TemplateInfoStat;

            //DefaultInfoStat =
            //"return new CardInfoStat[]" +
            //System.Environment.NewLine +
            //"{" +
            //System.Environment.NewLine +
            //"    new CardInfoStat()" +
            //System.Environment.NewLine +
            //"    {" +
            //System.Environment.NewLine +
            //"        positive = true," +
            //System.Environment.NewLine +
            //"        stat = " + "\"" + "Effect" + "\"," +
            //System.Environment.NewLine +
            //"        amount = " + "\"" + "No" + "\"," +
            //System.Environment.NewLine +
            //"        simepleAmount = CardInfoStat.SimpleAmount.notAssigned" +
            //System.Environment.NewLine +
            //"    }" +
            //System.Environment.NewLine +
            //"};" +
            //System.Environment.NewLine;

            RawInfoStat =
             "    new CardInfoStat()" +
            System.Environment.NewLine +
            "    {" +
            System.Environment.NewLine +
            "        positive = " + InfoStatsPositive.ToString().ToLower() + "," +
            System.Environment.NewLine +
            "        stat = " + "\"" + Stat + "\"," +
            System.Environment.NewLine +
            "        amount = " + "\"" + Amount + "\"," +
            System.Environment.NewLine +
            "        simepleAmount = CardInfoStat.SimpleAmount." + InfoStatSimpleAmount +
            System.Environment.NewLine +
            "    }";

            NewInfoStat =
            "return new CardInfoStat[]" +
            System.Environment.NewLine +
            "{" +
            System.Environment.NewLine +
            RawInfoStat +
            System.Environment.NewLine +
            "};" +
            System.Environment.NewLine;

            if (InfoStatNum >= 1)
                IsEnd = true;
            if (IsEnd)
            {
                InfoStats = InfoStats + "," + System.Environment.NewLine + RawInfoStat;
            }
            else
            {
                InfoStats = InfoStats + System.Environment.NewLine + RawInfoStat;
                InfoStatNum += 1;
            }

            FormattedInfoStats =
            "return new CardInfoStat[]" +
            System.Environment.NewLine +
            "{" +
            System.Environment.NewLine +
            InfoStats +
            System.Environment.NewLine +
            "};" +
            System.Environment.NewLine;

            RefreshInfoStats();
            // String InfoStats =
            //             "return new CardInfoStat[]" +
            // "{" +
            // "    new CardInfoStat()" +
            // "    {" +
            // "        positive = true," +
            // "        stat = " + "\"" + Stat + "\""," +
            // "        amount = " + "\"" + Amount + "\"," +
            // "        simepleAmount = CardInfoStat.SimpleAmount.notAssigned" +
            // "    }" +
            //"}; "
            //;

            // Card.Replace("" +
            // "return new CardInfoStat[]" +
            // "{" +
            // "    new CardInfoStat()" +
            // "    {" +
            // "        positive = true," +
            // "        stat = \"Effect\"," +
            // "        amount = \"No\"," +
            // "        simepleAmount = CardInfoStat.SimpleAmount.notAssigned" +
            // "    }" +
            //"}; ",
            // InfoStats
            //);
        }

        private void siticoneTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        public void RefreshGunStats()
        {
            siticoneTextBox11.Text = "";
            siticoneTextBox11.Text = GunStats;
        }

        public void RefreshInfoStats()
        {
            siticoneTextBox12.Text = "";
            siticoneTextBox12.Text = FormattedInfoStats;
        }

        public void RefreshCardTextView()
        {
            siticoneTextBox9.Text = "";
            siticoneTextBox9.Text = Card;
            siticoneTextBox9.TextAlign = HorizontalAlignment.Left;
            //siticoneTextBox1.Font = new Font("Microsoft Sans Serif", 15);
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            StatTemplate = "            gun.stat = num;";
            //GunStats = (GunStats + StatTemplate);
            System.Diagnostics.Debug.WriteLine(GunStats);
            Card = Card.Replace(StatTemplate, GunStats);
            StatTemplate = GunStats;

            RefreshCardTextView();
            RefreshGunStats();
        }

        private void siticoneTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton10_Click(object sender, EventArgs e)
        {
            GunStat = siticoneComboBox1.Text;
            GunStatOperation = siticoneComboBox3.Text;
            GunStatValue = siticoneTextBox8.Text;
            NewGunStats = "            gun." + GunStat + " " + GunStatOperation + " " + GunStatValue + ";";
            GunStats = GunStats + System.Environment.NewLine + NewGunStats;

            RefreshCardTextView();
            RefreshGunStats();
        }

        private void siticoneTextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Card.Contains(DefaultInfoStat.ToString()));

            Card = Card.Replace(DefaultInfoStat, FormattedInfoStats);

            System.Diagnostics.Debug.WriteLine(DefaultInfoStat);
            System.Diagnostics.Debug.WriteLine(FormattedInfoStats);

            DefaultInfoStat = FormattedInfoStats;

            System.Diagnostics.Debug.WriteLine(DefaultInfoStat);

            RefreshCardTextView();
            RefreshInfoStats();
        }

        private void siticoneTextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton12_Click(object sender, EventArgs e)
        {
            if (siticoneButton12.Checked)
            {
                IsEnd = true;
            } 
            else
            {
                IsEnd = false;
            }
        }

        private void siticoneButton12_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(TemplateDir);
            NewCardName = siticoneTextBox4.Text;
            NewCardDir = (AppFileDir + CardFolder + "//" + NewCardName + ".cs");

            //File.Copy(TemplateDir, NewCardDir);
            //File.Move(TemplateDir, NewCardDir);

            Card = File.ReadAllText(NewCardDir);

            RefreshCardTextView();
        }

        private void siticoneTextBox14_Enter(object sender, EventArgs e)
        {
            //ModID = siticoneTextBox14.Text;
            //NewModID = "namespace " + ModID + ModInitials + ".Cards";

            //Card = Card.Replace(DefaultModID, NewModID);
            //DefaultModID = NewModID;
        }

        private void siticoneTextBox13_Enter(object sender, EventArgs e)
        {
            //CardID = siticoneTextBox13.Text;
            //NewCardID = "    class " + CardID + " : CustomCard";

            //Card = Card.Replace(DefaultCardID, NewCardID);
            //DefaultCardID = NewCardID;
        }

        private void siticoneTextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox15_Enter(object sender, EventArgs e)
        {
            //ModInitials = siticoneTextBox15.Text;
            //NewModInitials = ModInitials;

            //Card = Card.Replace(DefaultModInitials, NewModInitials);
            //DefaultModInitials = NewModInitials;
        }

        private void siticoneComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton13_Click(object sender, EventArgs e)
        {
            if (ExportPath == "")
            {
                FolderBrowserDialog ExportDialog = new FolderBrowserDialog();

                ExportDialog.Description = "Please open your mod project's card folder.";

                DialogResult DR = ExportDialog.ShowDialog();

                if (DR == DialogResult.OK)
                {
                    ExportPath = ExportDialog.SelectedPath;

                    File.Copy(NewCardDir, ExportPath + "\\" + NewCardName + ".cs");
                }
            }
            else
            {
                File.Copy(NewCardDir, ExportPath + "\\" + NewCardName + ".cs");
            }
        }

        private void siticoneButton14_Click(object sender, EventArgs e)
        {
            String Theme = siticoneComboBox6.Text;

            String NewTheme = "        CardThemeColor.CardThemeColorType theme = CardThemeColor.CardThemeColorType." + Theme + ";";

            System.Diagnostics.Debug.WriteLine(Card.Contains(DefaultTheme));
            Card = Card.Replace(DefaultTheme, NewTheme);
            DefaultTheme = NewTheme;

            RefreshCardTextView();
        }

        private void siticoneComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
