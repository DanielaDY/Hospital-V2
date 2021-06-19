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
    public partial class Distancia : Form
    {
        //declaración de variables
        int NcPS = 0, CaG = 3, GL = 1;
        int contR = 0;
        bool contA = false;
        double[] nps;

        double FE = 0, FE2 = 0, FE3 = 0, FOc1 = 0, FOc2 = 0, FOc3 = 0, pro1 = 0, pro2 = 0, pro3 = 0, teta = 0, totalFO = 0;

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AyudaDistancia ayuda = new AyudaDistancia();
            ayuda.Show();
        }

        private void Linf_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == '-')
            {
                e.Handled = true;
                MessageBox.Show("No se permiten valores negativos");
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                MessageBox.Show("No se permite más de un punto");
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //intervalos

        double ValorCA = 0, valorT = 0, VaSig = 0, intinf = 0, intsup = 0;
        string txt;
        int ad;

        public static double a;
        public static double c;
        public static double Xo;
        public static double M;
        double n, modulo, m = 0;

        double[] random = new double[100000];
        public Distancia()
        {
            InitializeComponent();
            comboBox1.Items.Add("0.995");
            comboBox1.Items.Add("0.990");
            comboBox1.Items.Add("0.975");
            comboBox1.Items.Add("0.950");
            comboBox1.Items.Add("0.500");
            comboBox1.Items.Add("0.050");
            comboBox1.Items.Add("0.25");
            comboBox1.Items.Add("0.010");
            comboBox1.Items.Add("0.005");
        }
        private void StartPF_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ValorCA = 0;
            valorT = 0;
            VaSig = 0;
            intinf = 0;
            intsup = 0;
            FE = 0;
            FE2 = 0;
            FE3 = 0;
            FOc1 = 0;
            FOc2 = 0;
            FOc3 = 0;
            pro1 = 0;
            pro2 = 0;
            pro3 = 0;
            teta = 0;
            totalFO = 0;
            //obtención de los números pseudoaleatorios
            {
                //optención de valores para las variables
                double.TryParse(tbA2.Text, out a);
                double.TryParse(tbC2.Text, out c);
                double.TryParse(tbXo2.Text, out Xo);
                double.TryParse(tbM2.Text, out M);
                double.TryParse(tbn2.Text, out n);



                //int.TryParse(tbn2.Text, out NcPS);
                NcPS = Convert.ToInt32(n);
                //n = nn.Text();
                nps = new double[NcPS];
                //int.TryParse(CanGr.Text, out CaG);
                double.TryParse(comboBox1.Text, out VaSig);
                //generar numeros 
                for (int i = 0; i < n; i++)
                {
                    modulo = (a * Xo + c) % M;
                    random[i] = modulo / M;
                    double redoneado = (Math.Round(random[i], 5));
                    ad = dataGridView3.Rows.Add();
                    dataGridView3.Rows[ad].Cells[0].Value = (i + 1).ToString();
                    dataGridView3.Rows[ad].Cells[1].Value = redoneado.ToString();

                    nps[i] = redoneado;
                    m = modulo;
                    Xo = m;
                }
            }


            //validación para comenzar la prueba
            if (nn.Text == "" || comboBox1.Text == "" || Linf.Text == "" || Lsup.Text == "" || Linf.Text == "" || Double.Parse(Linf.Text) < 0 && Double.Parse(Linf.Text) > 1 || Double.Parse(Lsup.Text) < 0 && Double.Parse(Lsup.Text) > 1)
            {
                MessageBox.Show("Para realizar la prueba es necesario que introduzca los valores en los campos correctamente");
            }
            else
            {
                if (Double.Parse(Lsup.Text) > Double.Parse(Linf.Text))
                {
                    //valores de los intervalos

                    double.TryParse(Linf.Text, out intinf);
                    double.TryParse(Lsup.Text, out intsup);


                    LimIn.Text = intinf.ToString();

                    LimSup.Text = intsup.ToString();
                    teta = intsup - intinf;
                    AlphM.Text = teta.ToString();

                    //comparación de los numeros pseudoaleatorios y la probabilidad acumulada
                    for (int i = 0; i < NcPS; i++)
                    {
                        //comparación de rango
                        if (nps[i] < intinf)
                        {
                            contR++;
                        }
                        else if (nps[i] >= intinf && nps[i] <= intsup)
                        {
                            contA = true;
                        }
                        else if (nps[i] > intsup)
                        {
                            contR++;
                        }
                        //conteo de distancia // Optener FO
                        if (contA == true || i == NcPS - 1)
                        {
                            if (contR == 0)
                            {
                                FOc1++;
                                contR = 0;
                                contA = false;
                            }
                            else if (contR == 1)
                            {
                                FOc2++;
                                contR = 0;
                                contA = false;
                            }
                            else if (contR >= 2)
                            {
                                FOc3++;
                                contR = 0;
                                contA = false;
                            }


                        }

                    }
                    // optener probabilidad
                    pro1 = teta * (Math.Pow((1 - teta), 0));
                    pro2 = teta * (Math.Pow((1 - teta), 1));
                    pro3 = 1 - (pro1 + pro2); /*(Math.Pow((1 - teta), 2));*/

                    //optener FE
                    totalFO = FOc1 + FOc2 + FOc3;
                    FE = totalFO * pro1;
                    FE2 = totalFO * pro2;
                    FE3 = totalFO * pro3;
                    //Obtención del valor calculado.
                    ValorCA = ((Math.Pow((FOc1 - FE), 2)) / FE) + ((Math.Pow((FOc2 - FE2), 2)) / FE2) + ((Math.Pow((FOc3 - FE3), 2)) / FE3);
                    ValorCA = (Math.Round(ValorCA, 5));

                    //Mostrar resutados en la tabla.
                    for (int ro = 0; ro < 3; ro++)
                    {
                        dataGridView1.Rows.Add();
                    }
                    dataGridView1.Rows[0].Cells[0].Value = 0;
                    dataGridView1.Rows[0].Cells[1].Value = FOc1;
                    dataGridView1.Rows[0].Cells[2].Value = (Math.Round(pro1, 5));
                    dataGridView1.Rows[0].Cells[3].Value = (Math.Round(FE, 5));

                    dataGridView1.Rows[1].Cells[0].Value = 1;
                    dataGridView1.Rows[1].Cells[1].Value = FOc2;
                    dataGridView1.Rows[1].Cells[2].Value = (Math.Round(pro2, 5));
                    dataGridView1.Rows[1].Cells[3].Value = (Math.Round(FE2, 5));

                    dataGridView1.Rows[2].Cells[0].Value = "2 a +";
                    dataGridView1.Rows[2].Cells[1].Value = FOc3;
                    dataGridView1.Rows[2].Cells[2].Value = (Math.Round(pro3, 5));
                    dataGridView1.Rows[2].Cells[3].Value = (Math.Round(FE3, 5));

                    //obtención del valor de tablas.
                    {
                        if (CaG - GL == 1)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 0.000;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 0.000;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 0.000;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 0.000;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 0.45;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 3.85;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 5.02;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 6.63;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 7.88;
                            }
                        }
                        else if (CaG - GL == 2)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 0.01;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 0.02;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 0.05;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 0.10;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 1.39;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 5.99;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 7.38;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 9.21;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 10.60;
                            }
                        }
                        else if (CaG - GL == 3)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 0.07;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 0.11;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 0.22;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 0.35;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 2.37;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 7.81;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 9.35;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 11.34;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 12.84;
                            }
                        }
                        else if (CaG - GL == 4)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 0.21;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 0.30;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 0.48;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 0.71;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 3.36;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 9.49;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 11.14;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 13.28;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 14.86;
                            }
                        }
                        else if (CaG - GL == 5)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 0.41;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 0.55;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 0.83;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 1.15;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 4.35;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 11.07;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 12.83;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 15.09;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 16.75;
                            }
                        }
                        else if (CaG - GL == 6)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 0.68;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 0.87;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 1.24;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 1.64;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 5.35;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 12.59;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 14.45;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 16.81;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 18.55;
                            }
                        }
                        else if (CaG - GL == 7)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 0.99;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 1.24;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 1.69;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 2.17;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 6.35;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 14.07;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 16.01;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 18.48;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 20.28;
                            }
                        }
                        else if (CaG - GL == 8)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 1.34;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 1.65;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 2.18;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 2.73;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 7.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 15.51;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 17.53;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 20.09;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 21.96;
                            }
                        }
                        else if (CaG - GL == 9)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 1.73;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 2.09;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 2.70;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 3.33;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 8.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 16.92;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 19.02;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 21.67;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 23.59;
                            }
                        }
                        else if (CaG - GL == 10)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 2.16;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 2.56;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 3.25;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 3.94;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 9.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 18.31;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 20.48;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 23.21;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 25.19;
                            }
                        }
                        if (CaG - GL == 11)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 2.60;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 3.05;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 3.82;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 4.57;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 10.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 19.68;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 21.92;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 24.72;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 26.76;
                            }
                        }
                        else if (CaG - GL == 12)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 3.07;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 3.57;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 4.40;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 5.23;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 11.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 21.03;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 23.34;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 26.22;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 28.30;
                            }
                        }
                        else if (CaG - GL == 13)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 3.57;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 4.11;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 5.01;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 5.89;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 12.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 22.36;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 24.74;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 27.69;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 29.82;
                            }
                        }
                        else if (CaG - GL == 14)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 4.07;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 4.66;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 5.63;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 6.57;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 13.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 23.68;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 26.12;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 29.14;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 31.32;
                            }
                        }
                        else if (CaG - GL == 15)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 4.60;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 5.23;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 6.27;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 7.26;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 14.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 25.00;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 27.49;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 30.58;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 32.80;
                            }
                        }
                        else if (CaG - GL == 16)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 5.14;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 5.81;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 6.91;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 7.96;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 15.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 26.30;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 28.85;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 32.00;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 34.27;
                            }
                        }
                        else if (CaG - GL == 17)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 5.70;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 6.41;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 7.56;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 8.67;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 16.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 27.59;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 30.19;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 33.41;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 35.72;
                            }
                        }
                        else if (CaG - GL == 18)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 6.26;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 7.01;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 8.23;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 9.39;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 17.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 28.87;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 31.53;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 34.81;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 37.16;
                            }
                        }
                        else if (CaG - GL == 19)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 6.84;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 7.63;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 8.91;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 10.12;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 18.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 30.14;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 32.85;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 36.19;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 38.58;
                            }
                        }
                        else if (CaG - GL == 20)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 7.43;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 8.26;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 9.59;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 10.85;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 19.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 31.41;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 34.17;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 37.57;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 40.00;
                            }
                        }
                        else if (CaG - GL == 25)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 10.52;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 11.52;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 13.12;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 14.61;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 24.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 37.65;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 40.65;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 44.31;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 46.93;
                            }
                        }
                        else if (CaG - GL == 30)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 13.79;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 14.95;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 16.79;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 18.49;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 20.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 43.77;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 46.98;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 50.89;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 53.67;
                            }
                        }
                        else if (CaG - GL == 40)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 20.71;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 22.16;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 24.43;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 26.51;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 39.34;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 55.76;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 59.34;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 63.69;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 66.77;
                            }
                        }
                        else if (CaG - GL == 50)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 27.99;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 29.71;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 32.36;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 34.76;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 49.33;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 67.50;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 71.42;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 76.15;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 79.49;
                            }
                        }
                        else if (CaG - GL == 60)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 35.53;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 37.48;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 40.48;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 43.19;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 59.33;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 79.08;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 83.30;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 88.38;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 91.95;
                            }
                        }
                        else if (CaG - GL == 70)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 43.28;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 45.44;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 48.76;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 51.74;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 69.33;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 90.53;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 95.02;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 100.42;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 104.22;
                            }
                        }
                        else if (CaG - GL == 80)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 51.17;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 53.54;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 57.15;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 60.39;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 79.33;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 101.88;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 106.63;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 112.33;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 116.32;
                            }
                        }
                        else if (CaG - GL == 90)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 59.20;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 61.75;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 65.65;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 69.13;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 89.33;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 113.14;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 118.14;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 124.12;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 128.30;
                            }
                        }
                        else if (CaG - GL == 100)
                        {
                            if (VaSig == 0.995)
                            {
                                valorT = 67.33;
                            }
                            else if (VaSig == 0.990)
                            {
                                valorT = 70.06;
                            }
                            else if (VaSig == 0.975)
                            {
                                valorT = 74.22;
                            }
                            else if (VaSig == 0.950)
                            {
                                valorT = 77.93;
                            }
                            else if (VaSig == 0.500)
                            {
                                valorT = 99.33;
                            }
                            else if (VaSig == 0.050)
                            {
                                valorT = 124.34;
                            }
                            else if (VaSig == 0.25)
                            {
                                valorT = 129.56;
                            }
                            else if (VaSig == 0.010)
                            {
                                valorT = 135.81;
                            }
                            else if (VaSig == 0.005)
                            {
                                valorT = 140.17;
                            }
                        }
                    }
                    Math.Round(ValorCA, 5);
                    R2.Text = ValorCA.ToString();
                    R1.Text = valorT.ToString();
                    if (ValorCA <= valorT)
                    {
                        txt = "SI Estan distribuidos uniformemente.";
                        R3.Text = txt;
                    }
                    else
                    {
                        txt = "NO estan distribuidos uniformemente.";
                        R3.Text = txt;
                    }
                }
                else
                {
                    MessageBox.Show("El valor del limite superior debe ser mayor que el limite inferior");
                }

            }
        }

    }
}
