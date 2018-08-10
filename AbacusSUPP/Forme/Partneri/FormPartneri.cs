using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbacusSUPP
{
    public partial class FormPartneri : DevExpress.XtraEditors.XtraForm
    {
        public Panel MainPanel { get { return this.panel1; } }
        public bool datechanged = false;
        AbacusSUPEntities Baza { get; set; }
        public FormPartneri()
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Partneri.ToList();
            gridView1.RefreshData();

            dateEdit2.DateTime = DateTime.Today.Date;
            dateEdit1.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).Date;
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Partneri partner = new Partneri();
            FormDodajPartnera fdp = new FormDodajPartnera(partner.id);
            var res = fdp.ShowDialog();
            if (res == DialogResult.OK)
            {
                Baza = new AbacusSUPEntities();
                gridControl1.DataSource = Baza.Partneri.ToList();
                gridView1.RefreshData();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Partneri partner = (Partneri)gridView1.GetRow(gridView1.FocusedRowHandle);

            if (partner!=null)
            {
                FormDodajPartnera fdp = new FormDodajPartnera(partner.id);
                var res = fdp.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Baza = new AbacusSUPEntities();
                    gridControl1.DataSource = Baza.Partneri.ToList();
                    gridView1.RefreshData();
                } 
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Partneri partner = (Partneri)gridView1.GetRow(gridView1.FocusedRowHandle);
            FormPregledTaskova frmpregled = new FormPregledTaskova(partner);
            frmpregled.ShowDialog();
        }

        private void GenerisiChartove(Partneri partner)
        {
            var datumPocetni= new DateTime();
            var datumKraj=new DateTime();
            if (datechanged==false)
            {
                datumPocetni = DateTime.Today.AddMonths(-3);
                datumKraj = DateTime.Today;
            }
            else
            {
                datumPocetni = dateEdit1.DateTime;
                datumKraj = dateEdit2.DateTime;
            }
            
            GenerisiChartove(partner, datumPocetni, datumKraj);
        }

        private void GenerisiChartove(Partneri partner, DateTime datumPocetni, DateTime datumKraj)
        {
            Series series1 = new Series("Aktivnih taskova po danu:"+System.Environment.NewLine+"["+partner.naziv+"]", ViewType.SplineArea);
            var db = new AbacusSUPEntities();
            

            List<Task> listataskova = db.Task.Where(qq=> qq.id_partner == partner.id).ToList();
            
            listataskova = listataskova.Where(qq => qq.id_partner == partner.id && ((qq.datum.Value.Date >= datumPocetni.Date && qq.datum.Value.Date <= datumKraj.Date) || (qq.datum_zatv.HasValue && (qq.datum_zatv.Value.Date >= datumPocetni.Date && qq.datum_zatv.Value.Date <= datumKraj.Date)) || (qq.datum.HasValue && (!qq.datum_zatv.HasValue || qq.datum_zatv>datumKraj.Date)))).ToList();
            for (DateTime i = datumPocetni; i <= datumKraj; i = i.AddDays(1))
            {
                
                int broj = listataskova.Where(qq => qq.datum.Value.Date <= i.Date && ((qq.datum_zatv.HasValue && qq.datum_zatv.Value.Date >= i.Date ) || !qq.datum_zatv.HasValue)).ToList().Count();
                series1.Points.Add(new SeriesPoint(i, broj));
                //series2.Points.Add(new SeriesPoint(i, trajanje2 / 60));


            }
            
           
            
            series1.ArgumentScaleType = ScaleType.DateTime;
            //((SplineAreaSeriesView)series1.View).FillStyle.FillMode = FillMode.Gradient;
            //((SplineAreaSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            //((SplineAreaSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Solid;
            //((SplineAreaSeriesView)series1.View).SeriesAnimation = new XYSeriesUnwindAnimation
            //{
            //    Direction = AnimationDirection.FromLeft,
            //    Duration = new TimeSpan(0, 0, 5)
            //};
            
            chartControl1.Series.Add(series1);
            chartControl1.Animate();
            //chartControl1.Titles.Add(new ChartTitle());
            //chartControl1.Titles[0].Text = "Aktivnih taskova po danu:";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Partneri partner = (Partneri)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (gridView1.SelectedRowsCount < 2) chartControl1.Series.Clear();
            GenerisiChartove(partner);
            chartControl1.Refresh();
        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            datechanged = true;
        }

        private void dateEdit2_DateTimeChanged(object sender, EventArgs e)
        {
            datechanged = true;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Partneri partner = (Partneri)gridView1.GetRow(gridView1.FocusedRowHandle);
            chartControl1.Series.Clear();
            GenerisiChartove(partner, dateEdit1.DateTime.Date, dateEdit2.DateTime.Date);
            chartControl1.Refresh();
        }
    }
}
