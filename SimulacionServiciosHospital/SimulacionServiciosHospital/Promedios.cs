using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulacionServiciosHospital
{
    public partial class Promedios : Form
    {
        double area;
        double columnatabla, filatabla, vtablas, area2, VaSig;
        int indexC = 0, indexR = 0;
        bool vtpasar = false;

        private void txtNivelSignificancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten letras.");
            }
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios.");
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AyudaPromedio ayuda = new AyudaPromedio();
            ayuda.Show();
        }

        double cct, rrt, cct2;
        private void btnPromedio_Click(object sender, EventArgs e)
        {
            lblpromedio2.Visible = true;
            lbldisnor.Visible = true;
            double vcalculado = double.Parse(lbldisnor.Text);
            if (vcalculado <= vtablas)
            {
                lblRespuesta.Text = "Los números están distribuidos uniformemente de acuerdo a la prueba de promedios.";
            }
            else if (vcalculado > vtablas && vtablas != 0)
            {
                lblRespuesta.Text = "Los números NO están distribuidos uniformemente de acuerdo a la prueba de promedios.";

            }
            else if (vtablas == 0)
            {
                lblRespuesta.Text = "Calcula el valor de tablas para saber si los números están distribuidos uniformemente o no.";

            }
        }



        public Promedios()
        {
            InitializeComponent();
        }

        private void btnPruebaPromedio_Click(object sender, EventArgs e)
        {
            if (txtNivelSignificancia.TextLength == 0)
            {
                MessageBox.Show("Rellena los campos faltantes");
            }
            else
            {
                double numa = 0.0;
                area = 0;
                columnatabla = 0; filatabla = 0; vtablas = 0; area2 = 0;
                indexC = 0; indexR = 0;
                vtpasar = false;
                cct = 0; rrt = 0; cct2 = 0;
                dataGridView2.Rows.Clear();

                for (int i = 0; i < 30; i++)
                {
                    dataGridView2.Rows.Add();

                    dataGridView2.Rows[i].Cells[0].Value = numa;
                    numa = numa + 0.1;
                }

                //fila .00
                dataGridView2.Rows[0].Cells[1].Value = 0.0000;
                dataGridView2.Rows[0].Cells[2].Value = 0.0040;
                dataGridView2.Rows[0].Cells[3].Value = 0.0080;
                dataGridView2.Rows[0].Cells[4].Value = 0.0120;
                dataGridView2.Rows[0].Cells[5].Value = 0.0160;
                dataGridView2.Rows[0].Cells[6].Value = 0.0199;
                dataGridView2.Rows[0].Cells[7].Value = 0.0239;
                dataGridView2.Rows[0].Cells[8].Value = 0.0279;
                dataGridView2.Rows[0].Cells[9].Value = 0.0319;
                dataGridView2.Rows[0].Cells[10].Value = 0.0359;

                //fila .01
                dataGridView2.Rows[1].Cells[1].Value = 0.0398;
                dataGridView2.Rows[1].Cells[2].Value = 0.0438;
                dataGridView2.Rows[1].Cells[3].Value = 0.0478;
                dataGridView2.Rows[1].Cells[4].Value = 0.0517;
                dataGridView2.Rows[1].Cells[5].Value = 0.0557;
                dataGridView2.Rows[1].Cells[6].Value = 0.0596;
                dataGridView2.Rows[1].Cells[7].Value = 0.0636;
                dataGridView2.Rows[1].Cells[8].Value = 0.0675;
                dataGridView2.Rows[1].Cells[9].Value = 0.0714;
                dataGridView2.Rows[1].Cells[10].Value = 0.0753;

                //fila .02
                dataGridView2.Rows[2].Cells[1].Value = 0.0793;
                dataGridView2.Rows[2].Cells[2].Value = 0.0832;
                dataGridView2.Rows[2].Cells[3].Value = 0.0871;
                dataGridView2.Rows[2].Cells[4].Value = 0.0910;
                dataGridView2.Rows[2].Cells[5].Value = 0.0948;
                dataGridView2.Rows[2].Cells[6].Value = 0.0987;
                dataGridView2.Rows[2].Cells[7].Value = 0.1026;
                dataGridView2.Rows[2].Cells[8].Value = 0.1064;
                dataGridView2.Rows[2].Cells[9].Value = 0.1103;
                dataGridView2.Rows[2].Cells[10].Value = 0.1141;

                //fila .3
                dataGridView2.Rows[3].Cells[1].Value = 0.1179;
                dataGridView2.Rows[3].Cells[2].Value = 0.1217;
                dataGridView2.Rows[3].Cells[3].Value = 0.1255;
                dataGridView2.Rows[3].Cells[4].Value = 0.1293;
                dataGridView2.Rows[3].Cells[5].Value = 0.1331;
                dataGridView2.Rows[3].Cells[6].Value = 0.1368;
                dataGridView2.Rows[3].Cells[7].Value = 0.1406;
                dataGridView2.Rows[3].Cells[8].Value = 0.1443;
                dataGridView2.Rows[3].Cells[9].Value = 0.1480;
                dataGridView2.Rows[3].Cells[10].Value = 0.1517;

                //fila .4
                dataGridView2.Rows[4].Cells[1].Value = 0.1554;
                dataGridView2.Rows[4].Cells[2].Value = 0.1591;
                dataGridView2.Rows[4].Cells[3].Value = 0.1628;
                dataGridView2.Rows[4].Cells[4].Value = 0.1664;
                dataGridView2.Rows[4].Cells[5].Value = 0.1700;
                dataGridView2.Rows[4].Cells[6].Value = 0.1736;
                dataGridView2.Rows[4].Cells[7].Value = 0.1772;
                dataGridView2.Rows[4].Cells[8].Value = 0.1808;
                dataGridView2.Rows[4].Cells[9].Value = 0.1844;
                dataGridView2.Rows[4].Cells[10].Value = 0.1879;

                //fila .5
                dataGridView2.Rows[5].Cells[1].Value = 0.1915;
                dataGridView2.Rows[5].Cells[2].Value = 0.1950;
                dataGridView2.Rows[5].Cells[3].Value = 0.1985;
                dataGridView2.Rows[5].Cells[4].Value = 0.2019;
                dataGridView2.Rows[5].Cells[5].Value = 0.2054;
                dataGridView2.Rows[5].Cells[6].Value = 0.2088;
                dataGridView2.Rows[5].Cells[7].Value = 0.2123;
                dataGridView2.Rows[5].Cells[8].Value = 0.2157;
                dataGridView2.Rows[5].Cells[9].Value = 0.2190;
                dataGridView2.Rows[5].Cells[10].Value = 0.2224;

                //fila .6
                dataGridView2.Rows[6].Cells[1].Value = 0.2257;
                dataGridView2.Rows[6].Cells[2].Value = 0.2291;
                dataGridView2.Rows[6].Cells[3].Value = 0.2324;
                dataGridView2.Rows[6].Cells[4].Value = 0.2357;
                dataGridView2.Rows[6].Cells[5].Value = 0.2389;
                dataGridView2.Rows[6].Cells[6].Value = 0.2422;
                dataGridView2.Rows[6].Cells[7].Value = 0.2454;
                dataGridView2.Rows[6].Cells[8].Value = 0.2486;
                dataGridView2.Rows[6].Cells[9].Value = 0.2517;
                dataGridView2.Rows[6].Cells[10].Value = 0.2549;

                //fila .7
                dataGridView2.Rows[7].Cells[1].Value = 0.2580;
                dataGridView2.Rows[7].Cells[2].Value = 0.2611;
                dataGridView2.Rows[7].Cells[3].Value = 0.2642;
                dataGridView2.Rows[7].Cells[4].Value = 0.2673;
                dataGridView2.Rows[7].Cells[5].Value = 0.2703;
                dataGridView2.Rows[7].Cells[6].Value = 0.2734;
                dataGridView2.Rows[7].Cells[7].Value = 0.2764;
                dataGridView2.Rows[7].Cells[8].Value = 0.2794;
                dataGridView2.Rows[7].Cells[9].Value = 0.2833;
                dataGridView2.Rows[7].Cells[10].Value = 0.2852;

                //fila .8
                dataGridView2.Rows[8].Cells[1].Value = 0.2881;
                dataGridView2.Rows[8].Cells[2].Value = 0.2910;
                dataGridView2.Rows[8].Cells[3].Value = 0.2939;
                dataGridView2.Rows[8].Cells[4].Value = 0.2967;
                dataGridView2.Rows[8].Cells[5].Value = 0.2995;
                dataGridView2.Rows[8].Cells[6].Value = 0.3023;
                dataGridView2.Rows[8].Cells[7].Value = 0.3051;
                dataGridView2.Rows[8].Cells[8].Value = 0.3078;
                dataGridView2.Rows[8].Cells[9].Value = 0.3106;
                dataGridView2.Rows[8].Cells[10].Value = 0.3133;

                //fila .9
                dataGridView2.Rows[9].Cells[1].Value = 0.3159;
                dataGridView2.Rows[9].Cells[2].Value = 0.3186;
                dataGridView2.Rows[9].Cells[3].Value = 0.3212;
                dataGridView2.Rows[9].Cells[4].Value = 0.3238;
                dataGridView2.Rows[9].Cells[5].Value = 0.3264;
                dataGridView2.Rows[9].Cells[6].Value = 0.3289;
                dataGridView2.Rows[9].Cells[7].Value = 0.3315;
                dataGridView2.Rows[9].Cells[8].Value = 0.3340;
                dataGridView2.Rows[9].Cells[9].Value = 0.3365;
                dataGridView2.Rows[9].Cells[10].Value = 0.3389;

                //fila 1.0
                dataGridView2.Rows[10].Cells[1].Value = 0.3413;
                dataGridView2.Rows[10].Cells[2].Value = 0.3438;
                dataGridView2.Rows[10].Cells[3].Value = 0.3461;
                dataGridView2.Rows[10].Cells[4].Value = 0.3485;
                dataGridView2.Rows[10].Cells[5].Value = 0.3508;
                dataGridView2.Rows[10].Cells[6].Value = 0.3531;
                dataGridView2.Rows[10].Cells[7].Value = 0.3554;
                dataGridView2.Rows[10].Cells[8].Value = 0.3577;
                dataGridView2.Rows[10].Cells[9].Value = 0.3599;
                dataGridView2.Rows[10].Cells[10].Value = 0.3621;

                //fila 1.1
                dataGridView2.Rows[11].Cells[1].Value = 0.3643;
                dataGridView2.Rows[11].Cells[2].Value = 0.3665;
                dataGridView2.Rows[11].Cells[3].Value = 0.3686;
                dataGridView2.Rows[11].Cells[4].Value = 0.3708;
                dataGridView2.Rows[11].Cells[5].Value = 0.3729;
                dataGridView2.Rows[11].Cells[6].Value = 0.3749;
                dataGridView2.Rows[11].Cells[7].Value = 0.3770;
                dataGridView2.Rows[11].Cells[8].Value = 0.3790;
                dataGridView2.Rows[11].Cells[9].Value = 0.3810;
                dataGridView2.Rows[11].Cells[10].Value = 0.3830;

                //fila 1.2
                dataGridView2.Rows[12].Cells[1].Value = 0.3849;
                dataGridView2.Rows[12].Cells[2].Value = 0.3869;
                dataGridView2.Rows[12].Cells[3].Value = 0.3888;
                dataGridView2.Rows[12].Cells[4].Value = 0.3907;
                dataGridView2.Rows[12].Cells[5].Value = 0.3925;
                dataGridView2.Rows[12].Cells[6].Value = 0.3944;
                dataGridView2.Rows[12].Cells[7].Value = 0.3962;
                dataGridView2.Rows[12].Cells[8].Value = 0.3980;
                dataGridView2.Rows[12].Cells[9].Value = 0.3997;
                dataGridView2.Rows[12].Cells[10].Value = 0.4015;

                //fila 1.3
                dataGridView2.Rows[13].Cells[1].Value = 0.4032;
                dataGridView2.Rows[13].Cells[2].Value = 0.4049;
                dataGridView2.Rows[13].Cells[3].Value = 0.4066;
                dataGridView2.Rows[13].Cells[4].Value = 0.4082;
                dataGridView2.Rows[13].Cells[5].Value = 0.4099;
                dataGridView2.Rows[13].Cells[6].Value = 0.4115;
                dataGridView2.Rows[13].Cells[7].Value = 0.4131;
                dataGridView2.Rows[13].Cells[8].Value = 0.4147;
                dataGridView2.Rows[13].Cells[9].Value = 0.4162;
                dataGridView2.Rows[13].Cells[10].Value = 0.4177;

                //fila 1.4
                dataGridView2.Rows[14].Cells[1].Value = 0.4192;
                dataGridView2.Rows[14].Cells[2].Value = 0.4207;
                dataGridView2.Rows[14].Cells[3].Value = 0.4222;
                dataGridView2.Rows[14].Cells[4].Value = 0.4236;
                dataGridView2.Rows[14].Cells[5].Value = 0.4251;
                dataGridView2.Rows[14].Cells[6].Value = 0.4265;
                dataGridView2.Rows[14].Cells[7].Value = 0.4279;
                dataGridView2.Rows[14].Cells[8].Value = 0.4292;
                dataGridView2.Rows[14].Cells[9].Value = 0.4306;
                dataGridView2.Rows[14].Cells[10].Value = 0.4319;

                //fila 1.5
                dataGridView2.Rows[15].Cells[1].Value = 0.4332;
                dataGridView2.Rows[15].Cells[2].Value = 0.4345;
                dataGridView2.Rows[15].Cells[3].Value = 0.4357;
                dataGridView2.Rows[15].Cells[4].Value = 0.4370;
                dataGridView2.Rows[15].Cells[5].Value = 0.4382;
                dataGridView2.Rows[15].Cells[6].Value = 0.4394;
                dataGridView2.Rows[15].Cells[7].Value = 0.4406;
                dataGridView2.Rows[15].Cells[8].Value = 0.4418;
                dataGridView2.Rows[15].Cells[9].Value = 0.4429;
                dataGridView2.Rows[15].Cells[10].Value = 0.4441;

                //fila 1.6
                dataGridView2.Rows[16].Cells[1].Value = 0.4452;
                dataGridView2.Rows[16].Cells[2].Value = 0.4463;
                dataGridView2.Rows[16].Cells[3].Value = 0.4474;
                dataGridView2.Rows[16].Cells[4].Value = 0.4484;
                dataGridView2.Rows[16].Cells[5].Value = 0.4495;
                dataGridView2.Rows[16].Cells[6].Value = 0.4505;
                dataGridView2.Rows[16].Cells[7].Value = 0.4515;
                dataGridView2.Rows[16].Cells[8].Value = 0.4525;
                dataGridView2.Rows[16].Cells[9].Value = 0.4535;
                dataGridView2.Rows[16].Cells[10].Value = 0.4545;

                //fila 1.7
                dataGridView2.Rows[17].Cells[1].Value = 0.4554;
                dataGridView2.Rows[17].Cells[2].Value = 0.4564;
                dataGridView2.Rows[17].Cells[3].Value = 0.4573;
                dataGridView2.Rows[17].Cells[4].Value = 0.4582;
                dataGridView2.Rows[17].Cells[5].Value = 0.4591;
                dataGridView2.Rows[17].Cells[6].Value = 0.4599;
                dataGridView2.Rows[17].Cells[7].Value = 0.4608;
                dataGridView2.Rows[17].Cells[8].Value = 0.4616;
                dataGridView2.Rows[17].Cells[9].Value = 0.4625;
                dataGridView2.Rows[17].Cells[10].Value = 0.4633;

                //fila 1.8
                dataGridView2.Rows[18].Cells[1].Value = 0.4641;
                dataGridView2.Rows[18].Cells[2].Value = 0.4649;
                dataGridView2.Rows[18].Cells[3].Value = 0.4656;
                dataGridView2.Rows[18].Cells[4].Value = 0.4664;
                dataGridView2.Rows[18].Cells[5].Value = 0.4671;
                dataGridView2.Rows[18].Cells[6].Value = 0.4678;
                dataGridView2.Rows[18].Cells[7].Value = 0.4686;
                dataGridView2.Rows[18].Cells[8].Value = 0.4693;
                dataGridView2.Rows[18].Cells[9].Value = 0.4699;
                dataGridView2.Rows[18].Cells[10].Value = 0.4706;

                //fila 1.9
                dataGridView2.Rows[19].Cells[1].Value = 0.4713;
                dataGridView2.Rows[19].Cells[2].Value = 0.4719;
                dataGridView2.Rows[19].Cells[3].Value = 0.4726;
                dataGridView2.Rows[19].Cells[4].Value = 0.4732;
                dataGridView2.Rows[19].Cells[5].Value = 0.4738;
                dataGridView2.Rows[19].Cells[6].Value = 0.4744;
                dataGridView2.Rows[19].Cells[7].Value = 0.4750;
                dataGridView2.Rows[19].Cells[8].Value = 0.4756;
                dataGridView2.Rows[19].Cells[9].Value = 0.4761;
                dataGridView2.Rows[19].Cells[10].Value = 0.4767;

                //fila 2.0
                dataGridView2.Rows[20].Cells[1].Value = 0.4772;
                dataGridView2.Rows[20].Cells[2].Value = 0.4778;
                dataGridView2.Rows[20].Cells[3].Value = 0.4783;
                dataGridView2.Rows[20].Cells[4].Value = 0.4788;
                dataGridView2.Rows[20].Cells[5].Value = 0.4793;
                dataGridView2.Rows[20].Cells[6].Value = 0.4898;
                dataGridView2.Rows[20].Cells[7].Value = 0.4803;
                dataGridView2.Rows[20].Cells[8].Value = 0.4808;
                dataGridView2.Rows[20].Cells[9].Value = 0.4812;
                dataGridView2.Rows[20].Cells[10].Value = 0.4817;

                //fila 2.1
                dataGridView2.Rows[21].Cells[1].Value = 0.4821;
                dataGridView2.Rows[21].Cells[2].Value = 0.4826;
                dataGridView2.Rows[21].Cells[3].Value = 0.4830;
                dataGridView2.Rows[21].Cells[4].Value = 0.4834;
                dataGridView2.Rows[21].Cells[5].Value = 0.4838;
                dataGridView2.Rows[21].Cells[6].Value = 0.4842;
                dataGridView2.Rows[21].Cells[7].Value = 0.4846;
                dataGridView2.Rows[21].Cells[8].Value = 0.4850;
                dataGridView2.Rows[21].Cells[9].Value = 0.4854;
                dataGridView2.Rows[21].Cells[10].Value = 0.4857;

                //fila 2.2
                dataGridView2.Rows[22].Cells[1].Value = 0.4861;
                dataGridView2.Rows[22].Cells[2].Value = 0.4864;
                dataGridView2.Rows[22].Cells[3].Value = 0.4868;
                dataGridView2.Rows[22].Cells[4].Value = 0.4871;
                dataGridView2.Rows[22].Cells[5].Value = 0.4875;
                dataGridView2.Rows[22].Cells[6].Value = 0.4878;
                dataGridView2.Rows[22].Cells[7].Value = 0.4881;
                dataGridView2.Rows[22].Cells[8].Value = 0.4884;
                dataGridView2.Rows[22].Cells[9].Value = 0.4887;
                dataGridView2.Rows[22].Cells[10].Value = 0.4890;

                //fila 2.3
                dataGridView2.Rows[23].Cells[1].Value = 0.4893;
                dataGridView2.Rows[23].Cells[2].Value = 0.4896;
                dataGridView2.Rows[23].Cells[3].Value = 0.4898;
                dataGridView2.Rows[23].Cells[4].Value = 0.4901;
                dataGridView2.Rows[23].Cells[5].Value = 0.4904;
                dataGridView2.Rows[23].Cells[6].Value = 0.4906;
                dataGridView2.Rows[23].Cells[7].Value = 0.4909;
                dataGridView2.Rows[23].Cells[8].Value = 0.4911;
                dataGridView2.Rows[23].Cells[9].Value = 0.4913;
                dataGridView2.Rows[23].Cells[10].Value = 0.4916;

                //fila 2.4
                dataGridView2.Rows[24].Cells[1].Value = 0.4918;
                dataGridView2.Rows[24].Cells[2].Value = 0.4920;
                dataGridView2.Rows[24].Cells[3].Value = 0.4922;
                dataGridView2.Rows[24].Cells[4].Value = 0.4925;
                dataGridView2.Rows[24].Cells[5].Value = 0.4927;
                dataGridView2.Rows[24].Cells[6].Value = 0.4929;
                dataGridView2.Rows[24].Cells[7].Value = 0.4931;
                dataGridView2.Rows[24].Cells[8].Value = 0.4932;
                dataGridView2.Rows[24].Cells[9].Value = 0.4934;
                dataGridView2.Rows[24].Cells[10].Value = 0.4936;

                //fila 2.5
                dataGridView2.Rows[25].Cells[1].Value = 0.4938;
                dataGridView2.Rows[25].Cells[2].Value = 0.4940;
                dataGridView2.Rows[25].Cells[3].Value = 0.4941;
                dataGridView2.Rows[25].Cells[4].Value = 0.4943;
                dataGridView2.Rows[25].Cells[5].Value = 0.4945;
                dataGridView2.Rows[25].Cells[6].Value = 0.4946;
                dataGridView2.Rows[25].Cells[7].Value = 0.4948;
                dataGridView2.Rows[25].Cells[8].Value = 0.4949;
                dataGridView2.Rows[25].Cells[9].Value = 0.4951;
                dataGridView2.Rows[25].Cells[10].Value = 0.4952;

                //fila 2.6
                dataGridView2.Rows[26].Cells[1].Value = 0.4953;
                dataGridView2.Rows[26].Cells[2].Value = 0.4955;
                dataGridView2.Rows[26].Cells[3].Value = 0.4956;
                dataGridView2.Rows[26].Cells[4].Value = 0.4957;
                dataGridView2.Rows[26].Cells[5].Value = 0.4959;
                dataGridView2.Rows[26].Cells[6].Value = 0.4960;
                dataGridView2.Rows[26].Cells[7].Value = 0.4961;
                dataGridView2.Rows[26].Cells[8].Value = 0.4962;
                dataGridView2.Rows[26].Cells[9].Value = 0.4963;
                dataGridView2.Rows[26].Cells[10].Value = 0.4964;

                //fila 2.7
                dataGridView2.Rows[27].Cells[1].Value = 0.4965;
                dataGridView2.Rows[27].Cells[2].Value = 0.4966;
                dataGridView2.Rows[27].Cells[3].Value = 0.4967;
                dataGridView2.Rows[27].Cells[4].Value = 0.4968;
                dataGridView2.Rows[27].Cells[5].Value = 0.4969;
                dataGridView2.Rows[27].Cells[6].Value = 0.4970;
                dataGridView2.Rows[27].Cells[7].Value = 0.4971;
                dataGridView2.Rows[27].Cells[8].Value = 0.4972;
                dataGridView2.Rows[27].Cells[9].Value = 0.4973;
                dataGridView2.Rows[27].Cells[10].Value = 0.4974;

                //fila 2.8
                dataGridView2.Rows[28].Cells[1].Value = 0.4974;
                dataGridView2.Rows[28].Cells[2].Value = 0.4975;
                dataGridView2.Rows[28].Cells[3].Value = 0.4976;
                dataGridView2.Rows[28].Cells[4].Value = 0.4977;
                dataGridView2.Rows[28].Cells[5].Value = 0.4977;
                dataGridView2.Rows[28].Cells[6].Value = 0.4978;
                dataGridView2.Rows[28].Cells[7].Value = 0.4979;
                dataGridView2.Rows[28].Cells[8].Value = 0.4979;
                dataGridView2.Rows[28].Cells[9].Value = 0.4980;
                dataGridView2.Rows[28].Cells[10].Value = 0.4981;

                //fila 2.9
                dataGridView2.Rows[29].Cells[1].Value = 0.4981;
                dataGridView2.Rows[29].Cells[2].Value = 0.4982;
                dataGridView2.Rows[29].Cells[3].Value = 0.4982;
                dataGridView2.Rows[29].Cells[4].Value = 0.4983;
                dataGridView2.Rows[29].Cells[5].Value = 0.4984;
                dataGridView2.Rows[29].Cells[6].Value = 0.4984;
                dataGridView2.Rows[29].Cells[7].Value = 0.4985;
                dataGridView2.Rows[29].Cells[8].Value = 0.4985;
                dataGridView2.Rows[29].Cells[9].Value = 0.4986;
                dataGridView2.Rows[29].Cells[10].Value = 0.4986;

                //fila 30
                dataGridView2.Rows[30].Cells[0].Value = 3.0;
                dataGridView2.Rows[30].Cells[1].Value = 0.4987;
                dataGridView2.Rows[30].Cells[2].Value = 0.4987;
                dataGridView2.Rows[30].Cells[3].Value = 0.4987;
                dataGridView2.Rows[30].Cells[4].Value = 0.4988;
                dataGridView2.Rows[30].Cells[5].Value = 0.4988;
                dataGridView2.Rows[30].Cells[6].Value = 0.4989;
                dataGridView2.Rows[30].Cells[7].Value = 0.4989;
                dataGridView2.Rows[30].Cells[8].Value = 0.4989;
                dataGridView2.Rows[30].Cells[9].Value = 0.4990;
                dataGridView2.Rows[30].Cells[10].Value = 0.4990;


                area = 0.50 - (Double.Parse(txtNivelSignificancia.Text) / 2);

                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        area2 = Double.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                        if (area2 == area)
                        {
                            columnatabla = Double.Parse(dataGridView2.Rows[i].Cells[j].OwningColumn.HeaderText);
                            filatabla = Double.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                            vtablas = columnatabla + filatabla;

                            txtVtablas.Text = vtablas.ToString();

                            i = 30;
                            vtpasar = false;
                        }
                        else if (area2 < area)
                        {
                            double.TryParse(dataGridView2.Rows[i].Cells[j].OwningColumn.HeaderText, out cct);
                            double.TryParse(dataGridView2.Rows[i].Cells[0].Value.ToString(), out rrt);

                            cct2 = double.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                            indexC = (dataGridView2.Rows[i].Cells[j].ColumnIndex);
                            indexR = dataGridView2.Rows[i].Cells[j].RowIndex;
                            vtpasar = true;

                        }
                    }
                }
                if (vtpasar == true)
                {
                    double c = double.Parse(dataGridView2.Rows[indexR].Cells[indexC + 1].Value.ToString());
                    double index = double.Parse(dataGridView2.Rows[indexR].Cells[indexC + 1].OwningColumn.HeaderText);
                    double tablasA = cct + rrt;
                    vtablas = (((c - area) * (c - cct2)) / (index - cct)) + tablasA;
                    txtVtablas.Text = vtablas.ToString();
                }
            }
            }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }


    
}
