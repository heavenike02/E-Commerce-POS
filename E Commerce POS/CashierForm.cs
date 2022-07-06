﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce_POS
{
    public partial class CashierForm : Form
    {
        public CashierForm()
        {
            InitializeComponent();
        }

        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Slide(Button button)
        {
            SlidePanel.BackColor = Color.White;
            SlidePanel.Height = button.Height;
            SlidePanel.Top = button.Top;
        }

        private void NewTransactionButton_Click(object sender, EventArgs e)
        {
            Slide(NewTransactionButton);
        }

        private void SearchProductButton_Click(object sender, EventArgs e)
        {
            Slide(SearchProductButton);
        }

        private void AddDiscountButton_Click(object sender, EventArgs e)
        {
            Slide(AddDiscountButton);
        }

        private void SettlePaymentButton_Click(object sender, EventArgs e)
        {
            Slide(SettlePaymentButton);
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            Slide(ClearCartButton);
        }

        private void DailySalesButton_Click(object sender, EventArgs e)
        {
            Slide(DailySalesButton);
        }

        private void ChangePaswordButton_Click(object sender, EventArgs e)
        {
            Slide(ChangePaswordButton);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Slide(LogoutButton);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}