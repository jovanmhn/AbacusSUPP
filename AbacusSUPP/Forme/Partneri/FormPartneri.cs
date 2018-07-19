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

        AbacusSUPEntities Baza { get; set; }
        public FormPartneri()
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Partneri.ToList();
            gridView1.RefreshData();


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
            var datumPocetni = DateTime.Today.AddMonths(-2);
            var datumKraj = DateTime.Today;
            GenerisiChartove(partner, datumPocetni, datumKraj);
        }

        private void GenerisiChartove(Partneri partner, DateTime datumPocetni, DateTime datumKraj)
        {
            Series series1 = new Series("Aktivnih taskova po danu:"+System.Environment.NewLine+"["+partner.naziv+"]", ViewType.Spline);
            var db = new AbacusSUPEntities();

            //datumPocetni = datumPocetni ?? DateTime.Today.AddMonths(-2);
            //datumKraj = datumKraj ?? DateTime.Today;
            
            List<Task> listataskova = db.Task.Where(qq => qq.id_partner == partner.id && ((qq.datum>=datumPocetni && qq.datum<=datumKraj) || (qq.datum_zatv >= datumPocetni && qq.datum_zatv <= datumKraj))).ToList();
            for (DateTime i = datumPocetni; i <= datumKraj; i = i.AddDays(1))
            {
                
                int broj = listataskova.Where(qq => qq.datum <= i && (qq.datum_zatv >= i || qq.datum_zatv==null)).ToList().Count();
                series1.Points.Add(new SeriesPoint(i, broj));
                //series2.Points.Add(new SeriesPoint(i, trajanje2 / 60));


            }
            
           
            chartControl1.Series.Add(series1);
            series1.ArgumentScaleType = ScaleType.DateTime;
            ((SplineSeriesView)series1.View).LineTensionPercent = 90;
            ((SplineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            ((SplineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Solid;
            ((SplineSeriesView)series1.View).SeriesAnimation = new XYSeriesUnwindAnimation
            {
                Direction = AnimationDirection.FromLeft,
                Duration = new TimeSpan(0, 0, 5)
            };
            //chartControl1.Titles.Add(new ChartTitle());
            //chartControl1.Titles[0].Text = "Aktivnih taskova po danu:";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Partneri partner = (Partneri)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (gridView1.SelectedRowsCount == 1) chartControl1.Series.Clear();
            GenerisiChartove(partner);
            chartControl1.Refresh();
        }
    }
}
