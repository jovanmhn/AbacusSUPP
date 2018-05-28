﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbacusSUPP
{
    public partial class FormOperater : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        public FormOperater()
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Login.ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            FormDodajOperatera fdo = new FormDodajOperatera(login.id);
            fdo.ShowDialog();
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Login.ToList();
            gridView1.RefreshData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Login login = (Login)gridView1.GetRow(gridView1.FocusedRowHandle);
            FormDodajOperatera fdo = new FormDodajOperatera(login.id);
            fdo.ShowDialog();
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Login.ToList();
            gridView1.RefreshData();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Login login = (Login)gridView1.GetRow(gridView1.FocusedRowHandle);
            Baza.Login.Remove(login);
            Baza.SaveChanges();
            gridControl1.DataSource = Baza.Login.ToList();
            gridView1.RefreshData();
        }
    }
}
