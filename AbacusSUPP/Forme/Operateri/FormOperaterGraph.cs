using DevExpress.XtraCharts;
using System;
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
    public partial class FormOperaterGraph : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        Login login;
        
        public FormOperaterGraph(Login _login)
        {
            InitializeComponent();
            login = _login;
            this.Text = "Taskovi: " + login.username;
            dateEdit1.DateTime = DateTime.Now.AddMonths(-2);
            dateEdit2.DateTime = DateTime.Now;

            GenerisiChartove(login, dateEdit1.DateTime, dateEdit2.DateTime);
        }
        private void GenerisiChartove(Login login, DateTime datumPocetni, DateTime datumKraj)
        {
            chartControl1.Series.Clear();
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            Series series1 = new Series("Novih taskova po danu:", ViewType.Bar);
            Series series2 = new Series("Zatvorenih taskova po danu:", ViewType.Bar);
            
            var db = new AbacusSUPEntities();

            

            List<Task> listataskova = db.Task.ToList();

            listataskova = listataskova.Where(qq => (qq.login_id == login.id || qq.login_id_zatv==login.id) && ((qq.datum.Value.Date >= datumPocetni.Date && qq.datum.Value.Date <= datumKraj.Date) || ( qq.datum_zatv.HasValue && qq.datum_zatv.Value.Date >= datumPocetni.Date && qq.datum_zatv.Value.Date <= datumKraj.Date))).ToList();
            
            for (DateTime i = datumPocetni.Date; i <= datumKraj.Date; i = i.AddDays(1))
            {

                int brojnovih = listataskova.Where(qq => qq.datum.Value.Date == i.Date && qq.login_id==login.id).ToList().Count();
               
                series1.Points.Add(new SeriesPoint(i, brojnovih));

                int brojzatvorenih = listataskova.Where(qq => qq.datum_zatv.HasValue && qq.datum_zatv.Value.Date == i.Date && qq.login_id_zatv == login.id).ToList().Count();
                
                series2.Points.Add(new SeriesPoint(i, brojzatvorenih));

            }



            series1.ArgumentScaleType = ScaleType.DateTime;
            ((SideBySideBarSeriesView)series1.View).Animation.Enabled = true;
            chartControl1.Series.Add(series1);
            series2.ArgumentScaleType = ScaleType.DateTime;
            ((SideBySideBarSeriesView)series2.View).Animation.Enabled = true;
            chartControl1.Series.Add(series2);

            chartControl1.Animate();
            //chartControl1.Titles.Add(new ChartTitle());
            //chartControl1.Titles[0].Text = "Aktivnih taskova po danu:";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GenerisiChartove(login, dateEdit1.DateTime, dateEdit2.DateTime);
        }
    }
}
