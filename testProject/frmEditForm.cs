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

namespace testProject
{
    public partial class frmEditForm : Form
    {
        frmStore frm = Application.OpenForms.OfType<frmStore>().FirstOrDefault();

        int current = 0;
        Dictionary<string, int> editFoodMap = new Dictionary<string, int>();
        Dictionary<string, int> editFoodMapNew;
        string[] foodLine;

        double newTotal = 0.0;

        public frmEditForm()
        {
            InitializeComponent();
        }

        private void enableBoth()
        {
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
        }

        private void setValues()
        {
            txtName.Text = editFoodMapNew.Keys.ElementAt(current);
            txtQuantity.Text = editFoodMapNew.Values.ElementAt(current).ToString();
        }

        private void frmEditForm_Load(object sender, EventArgs e)
        {
            frm.Enabled = false;
            
            foreach (string line in frm.txtBill.Lines)
            {
                if (line.Length <= 1) break;
                foodLine = line.Split(' ');

                if (foodLine.Length > 1)
                {
                    int curQuantity = Convert.ToInt32(line.Substring(line.IndexOf('x') + 1));
                    editFoodMap.Add(foodLine[0], curQuantity);
                }
                else
                {
                    editFoodMap.Add(foodLine[0], 1);
                }


            }


            editFoodMapNew = new Dictionary<string, int>(editFoodMap);

            btnLeft.BackgroundImage = frm.resizeImage(Image.FromFile("C:\\Users\\lukaz\\OneDrive\\Desktop\\hrana_ikone\\hoverBackgrounds\\LeftArrow.png"), new Size(100, 40));
            btnRight.BackgroundImage = frm.resizeImage(Image.FromFile("C:\\Users\\lukaz\\OneDrive\\Desktop\\hrana_ikone\\hoverBackgrounds\\RightArrow.png"), new Size(100, 40));


            setValues();

            if (current == 0) btnLeft.Enabled = false;

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            --current;

            if (current == 0)
            {
                btnLeft.Enabled = false;
            }
            else
            {
                enableBoth();
            }

            setValues();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            current++;

            if(current == editFoodMap.Count-1)
            {
                btnRight.Enabled = false;
            }
            else
            {
                enableBoth();
            }


            setValues();
        }



        private void btnMinus_Click(object sender, EventArgs e)
        {
        
            if(editFoodMapNew[txtName.Text] > 0)
            {
                editFoodMapNew[txtName.Text]--;
            }

            txtQuantity.Text = editFoodMapNew[txtName.Text].ToString();


        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            editFoodMapNew[txtName.Text]++;
            txtQuantity.Text = editFoodMapNew[txtName.Text].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            setNewQuantities();
            updateTextBox();
            
            this.Close();
        }


        private void updateTotal(string key)
        {
            foreach (Dictionary<string, double> prices in frm.pricesList)
            {
                if (prices.ContainsKey(key))
                {
                    newTotal += editFoodMapNew[key] * prices[key];
                }

            }

        }

        private void updateTextBox()
        {
            frm.txtBill.Text = null;
            
            foreach (string key in editFoodMapNew.Keys)
            {
                if (editFoodMapNew[key] > 1)
                {
                    frm.txtBill.Text += (key + " x" + editFoodMapNew[key] + "\r\n");
                }
                else if(editFoodMapNew[key] == 1)
                {
                    frm.txtBill.Text += (key + "\r\n");
                }

                updateTotal(key);
            }

            frm.totalPrice = Math.Round(newTotal, 2);
            frm.lblPrice.Text = "Total: " + frm.totalPrice.ToString();
            

        }

        private void setNewQuantities()
        {
            foreach(string key in editFoodMapNew.Keys)
            {
                int currentArticleNo = 0;
                bool found = false;

                foreach (Dictionary<string, double> map in frm.pricesList)
                {
                    foreach(string food in map.Keys)
                    {
                        if (!key.Equals(food) && !found)
                        {
                            currentArticleNo++;
                        }
                        else
                        {
                            found = true;
                            break;
                        }

                        if (found)
                        {
                            break;
                        }
                    }
                }

                //frm.txtClose.Text += (currentArticleNo.ToString() + " ");
                switch (currentArticleNo)
                {
                    case < 5:
                        frm.timesBoughtFruit[currentArticleNo] = editFoodMapNew[key];
                        frm.timesBoughtList.ElementAt(0)[currentArticleNo] = editFoodMapNew[key];                    
                        break;

                    case < 10:
                        frm.timesBoughtVegetable[currentArticleNo % 5] = editFoodMapNew[key];
                        frm.timesBoughtList.ElementAt(1)[currentArticleNo % 5] = editFoodMapNew[key];                        
                        break;

                    default:
                        frm.timesBoughtSweets[currentArticleNo % 5] = editFoodMapNew[key];
                        frm.timesBoughtList.ElementAt(2)[currentArticleNo % 5] = editFoodMapNew[key];                        
                        break;
                }
                
            }


        }
        private void frmEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frm.timesBoughtCurrentType = null;
            frm.Enabled = true;

            if(frm.txtBill.Text.Length == 0)
            {
                frm.btnEdit.Enabled = false;
            }
        }
    }
}
