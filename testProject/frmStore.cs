using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testProject
{
    public partial class frmStore : Form
    {

        Dictionary<Button, string> fruitMap = new Dictionary<Button, string>();
        Dictionary<Button, string> vegetablesMap = new Dictionary<Button, string>();
        Dictionary<Button, string> sweetsMap = new Dictionary<Button, string>();

        public List<Dictionary<Button, string>> foodList = new List<Dictionary<Button, string>>(); 

        Dictionary<string, double> fruitPricesMap = new Dictionary<string, double>();
        Dictionary<string, double> vegetablePricesMap = new Dictionary<string, double>();
        Dictionary<string, double> sweetsPricesMap = new Dictionary<string, double>();

        public List<Dictionary<string, double>> pricesList = new List<Dictionary<string, double>>();

        public double totalPrice = 0.0;

        List<Button> articleBtns = new List<Button>();
        List<Button> foodTypeBtns = new List<Button>();
        bool pickedType = false;

        public int[] timesBoughtFruit = new int[] { 0, 0, 0, 0, 0 };
        public int[] timesBoughtVegetable = new int[] { 0, 0, 0, 0, 0 };
        public int[] timesBoughtSweets = new int[] { 0, 0, 0, 0, 0 };

        List<Point> ogBtnLocation = new List<Point>();

        public int[] timesBoughtCurrentType;
        public List<int[]> timesBoughtList = new List<int[]>();

         

        

        public frmStore()
        {
            InitializeComponent();
        }

        public Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public void foodTypeClick(Button btn, Dictionary<Button, string> map, Button btnType)
        {
            if (!pickedType)
            {
                pickedType = true;
                foreach (Button button in articleBtns)
                    button.Enabled = true;

                //btnEdit.Enabled = true;
            }

            if (map[btn] != "")
            {
                btn.Visible = true;
                toWords(btn, map);
            }
            else
                btn.Visible = false;

            if (rbIcons.Checked && btn.Visible)
            {
                toIcons(btn);
            }

            int atFoodType = 0;
            foreach(Button btnCurrentType in foodTypeBtns)
            {
                if(btnCurrentType.Text == btnType.Text)
                {
                    break;
                }

                atFoodType++;
            }

            timesBoughtCurrentType = timesBoughtList.ElementAt(atFoodType);



        }

        public void toIcons(Button btn)
        {
            btn.Image = resizeImage(Image.FromFile("..\\..\\..\\..\\hrana_ikone\\" + btn.Text + ".png"), new Size(30, 30));
            btn.ImageAlign = ContentAlignment.MiddleRight;
            btn.TextAlign = ContentAlignment.MiddleLeft;
        }

        public void toWords(Button btn, Dictionary<Button, string> map)
        {
            btn.Text = map[btn];
            btn.Image = null;
            btn.TextAlign = ContentAlignment.MiddleCenter;
        }

        public void toWords(Button btn)
        {
            btn.Image = null;
            btn.TextAlign = ContentAlignment.MiddleCenter;
        }


        public void expandButton(Button btn)
        {
            btn.Location = new Point(btn.Location.X - (int)(0.1 * btn.Width / 2), btn.Location.Y - (int)(0.1 * btn.Height / 2));

            btn.Width = (int)(1.1 * btn.Width);
            btn.Height = (int)(1.1 * btn.Height);
        }

        public void shrinkButton(Button btn)
        {
            btn.Size = btn.MinimumSize;
            btn.Location = ogBtnLocation[getCurrentArticleNo(btn)];
        }
        public void hoverOver(Button btn)
        {
            expandButton(btn);
            
            toWords(btn);
            Image backgroundImage = Image.FromFile("..\\..\\..\\..\\hrana_ikone\\hoverBackgrounds\\" + btn.Text + ".jpg");
            btn.BackgroundImage = backgroundImage;
        }
      
        public void hoverExit(Button btn)
        {
            shrinkButton(btn);

            btn.BackgroundImage = null;
            if (rbIcons.Checked) 
                toIcons(btn);
            else 
                toWords(btn);

            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            articleBtns.Add(btnArticle1);
            articleBtns.Add(btnArticle2);
            articleBtns.Add(btnArticle3);
            articleBtns.Add(btnArticle4);
            articleBtns.Add(btnArticle5);

            foodTypeBtns.Add(btnFruit);
            foodTypeBtns.Add(btnVegetables);
            foodTypeBtns.Add(btnSweets);


            fruitMap.Add(btnArticle1, "Apple");
            fruitMap.Add(btnArticle2, "Banana");
            fruitMap.Add(btnArticle3, "Pear");
            fruitMap.Add(btnArticle4, "Watermelon");
            fruitMap.Add(btnArticle5, "Cherries");

            vegetablesMap.Add(btnArticle1, "Potato");
            vegetablesMap.Add(btnArticle2, "Celery");
            vegetablesMap.Add(btnArticle3, "Broccoli");
            vegetablesMap.Add(btnArticle4, "Tomato");
            vegetablesMap.Add(btnArticle5, "Cucumber");

            sweetsMap.Add(btnArticle1, "Chocolate");
            sweetsMap.Add(btnArticle2, "Candy");
            sweetsMap.Add(btnArticle3, "GummyBears");
            sweetsMap.Add(btnArticle4, "Raffaello");
            sweetsMap.Add(btnArticle5, "");

            foodList.Add(fruitMap);
            foodList.Add(vegetablesMap);
            foodList.Add(sweetsMap);

            foreach(Button btn in articleBtns)
            {
                btn.MinimumSize = btn.Size;
                ogBtnLocation.Add(btn.Location);             
            }


            timesBoughtList.Add(timesBoughtFruit);
            timesBoughtList.Add(timesBoughtVegetable);
            timesBoughtList.Add(timesBoughtSweets);

            fruitPricesMap.Add("Apple", 1.99);
            fruitPricesMap.Add("Banana", 1.49);
            fruitPricesMap.Add("Pear", 2.19);
            fruitPricesMap.Add("Watermelon", 24.99);
            fruitPricesMap.Add("Cherries", 3.99);

            vegetablePricesMap.Add("Potato", 3.49);
            vegetablePricesMap.Add("Celery", 4.99);
            vegetablePricesMap.Add("Broccoli", 6.99);
            vegetablePricesMap.Add("Tomato", 3.49);
            vegetablePricesMap.Add("Cucumber", 5.99);

            sweetsPricesMap.Add("Chocolate", 9.99);
            sweetsPricesMap.Add("Candy", 6.99);
            sweetsPricesMap.Add("GummyBears", 5.49);
            sweetsPricesMap.Add("Raffaello", 11.99);

            pricesList.Add(fruitPricesMap);
            pricesList.Add(vegetablePricesMap);
            pricesList.Add(sweetsPricesMap);


            lblPrice.Text += totalPrice;

        }

        private void btnFruit_Click(object sender, EventArgs e)
        {
            btnFruit.Enabled = false;
            btnVegetables.Enabled = true;
            btnSweets.Enabled = true;

            foreach(Button btn in articleBtns)
            {
                foodTypeClick(btn, fruitMap, (Button)sender);
            }

        }

        private void btnVegetables_Click(object sender, EventArgs e)
        {
            btnFruit.Enabled = true;
            btnVegetables.Enabled = false;
            btnSweets.Enabled = true;

            foreach (Button btn in articleBtns)
            {
                foodTypeClick(btn, vegetablesMap, (Button)sender);
            }
        }

        private void btnSweets_Click(object sender, EventArgs e)
        {
            btnFruit.Enabled = true;
            btnVegetables.Enabled = true;
            btnSweets.Enabled = false;

            foreach (Button btn in articleBtns)
            {
                foodTypeClick(btn, sweetsMap, (Button)sender);
            }
        }

        private void rbIcons_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWords.Checked) _ = !rbIcons.Checked;
            if(rbIcons.Checked && pickedType)
                foreach (Button btn in articleBtns) toIcons(btn);
            
        }

        private void rbWords_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIcons.Checked) _ = !rbWords.Checked;
            if(rbWords.Checked && pickedType)
                foreach (Button btn in articleBtns) toWords(btn);
        }

        private void btnArticle1_Click(object sender, EventArgs e)
        {
            whenArticleClicked((Button)sender, timesBoughtCurrentType);
        }

        private void btnArticle2_Click(object sender, EventArgs e)
        {
            whenArticleClicked((Button)sender, timesBoughtCurrentType);
        }

        private void btnArticle3_Click(object sender, EventArgs e)
        {
            whenArticleClicked((Button)sender, timesBoughtCurrentType);
        }

        private void btnArticle4_Click(object sender, EventArgs e)
        {
            whenArticleClicked((Button)sender, timesBoughtCurrentType);
        }


        private void btnArticle5_Click(object sender, EventArgs e)
        {
            whenArticleClicked((Button)sender, timesBoughtCurrentType);

        }


        private void btnArticle1_MouseHover(object sender, EventArgs e)
        {
            hoverOver((Button)sender);
        }

        private void btnArticle2_MouseHover(object sender, EventArgs e)
        {
            hoverOver((Button)sender);
        }

        private void btnArticle3_MouseHover(object sender, EventArgs e)
        {
            hoverOver((Button)sender);
        }

        private void btnArticle4_MouseHover(object sender, EventArgs e)
        {
            hoverOver((Button)sender);
        }


        private void btnArticle5_MouseHover(object sender, EventArgs e)
        {
            hoverOver((Button)sender);
        }


        private void btnArticle1_MouseLeave(object sender, EventArgs e)
        {
            hoverExit((Button)sender);
        }

        private void btnArticle2_MouseLeave(object sender, EventArgs e)
        {
            hoverExit((Button)sender);
        }

        private void btnArticle3_MouseLeave(object sender, EventArgs e)
        {
            hoverExit((Button)sender);
        }

        private void btnArticle4_MouseLeave(object sender, EventArgs e)
        {
            hoverExit((Button)sender);
        }

        private void btnArticle5_MouseLeave(object sender, EventArgs e)
        {
            hoverExit((Button)sender);
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            frmEditForm frm = new frmEditForm();
            frm.Show();
        }


        private void whenArticleClicked(Button btn, int[] currentTypeIntArray)
        {
            btnEdit.Enabled = true;
            
            int currentArticleNo = getCurrentArticleNo(btn);
            int currentArticleTimesBought = ++currentTypeIntArray[currentArticleNo];

            //lblTest.Text = currentArticleNo.ToString() + " " + currentArticleTimesBought;

            if (currentArticleTimesBought == 1)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(btn.Text + "\r\n");
                txtBill.Text += sb;
            }
            else
            {
                string newText;
        
                if (currentArticleTimesBought == 2)
                {
                    newText = txtBill.Text.Replace(btn.Text, btn.Text + " x2");
                }
                else
                {
                    newText = txtBill.Text.Replace(btn.Text + " x" + --currentArticleTimesBought, btn.Text + " x" + ++currentArticleTimesBought);
                }
              
                txtBill.Text = newText;
            }

            double priceOfArticle = getArticlePrice(btn);
            totalPrice += priceOfArticle;

            lblPrice.Text = "Total: " + Math.Round(totalPrice, 2);



        }

        public int getCurrentArticleNo(Button btn)
        {
            int i = 0;
            foreach(Button btnSearch in articleBtns)
            {
                if(btn == btnSearch)
                {
                    break;
                }

                i++;
            }

            return i;
        }

        public int getCurrentArticleNo(string key)
        {
            int i = 0;
            foreach (Button btnSearch in articleBtns)
            {
                if (key == btnSearch.Text)
                {
                    break;
                }

                i++;
            }

            return i;
        }

        private double getArticlePrice(Button btn)
        {
            double articlePrice = 0; 

            foreach(Dictionary<string, double> foodMap in pricesList)
            {
                foreach(string foodName in foodMap.Keys)
                {
                    if(foodName == btn.Text)
                    {
                        articlePrice = foodMap.ElementAt(getCurrentArticleNo(btn)).Value;
                        break;
                    }
                }
            }

            return articlePrice;
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (txtBill.Text.Equals(""))
            {
                MessageBox.Show("Your cart is empty.");
            }
            else
            {
                frmPayment frm = new frmPayment();
                frm.Show();
            }
            
        }
    }
}

