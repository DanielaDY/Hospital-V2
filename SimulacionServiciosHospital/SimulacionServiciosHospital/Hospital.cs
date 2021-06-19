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
    public partial class Hospital : Form
    {

        //variables de la tabla de num pseudoaleatorios
        double modulo, a, c, Xo, M, acumulador = 0, promedio, Zo, gananciast, nsimulados;
        int n;
        double[] numerospseudoaleatorios = new double[100000];
        int ad;

        //variables de probabilidad y precio de servicios
        static double S1Prob = 0.10, S2Prob = 0.20, S3Prob = 0.15, S4Prob = 0.13, S5Prob = 0.17, S6Prob = 0.10, S7Prob = 0.15;

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Informacion inf = new Informacion();
            inf.Show();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AyudaHospital ayuda = new AyudaHospital();
            ayuda.Show();
        }

        double S1Precio = 75, S2Precio = 50, S3Precio = 150, S4Precio = 400, S5Precio = 950, S6Precio = 20, S7Precio = 200;

        //variables para tabla pacientes
        double[] numpacientes = new double[100000];
        double acumpac;


        public Hospital()
        {
            InitializeComponent();
            txtGananciaDecision.Text = "0";
        }

        //Botón para prueba de la distancia
        private void btnDistancia_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                Distancia pd = new Distancia();
                pd.tbA2.Text = txta.Text;
                pd.tbC2.Text = txtc.Text;
                pd.tbM2.Text = txtM.Text;
                pd.tbXo2.Text = txtXo.Text;
                pd.tbn2.Text = txtn.Text;
                pd.nn.Text = txtn.Text;
                pd.Show();

            }
            else
            {
                MessageBox.Show("No se pueden realizar las pruebas sin generar los números pseudoaleatorios.");
            }
            
        }
        //Botón para la prueba de promedios
        private void btnPromedio_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                Promedios pruebas1 = new Promedios();
                pruebas1.lblpromedio2.Text = lblpromedio.Text;
                pruebas1.lbldisnor.Text = lbldisnor2.Text;
                pruebas1.Show();
            }
            else
            {
                MessageBox.Show("No se pueden realizar las pruebas sin generar los números pseudoaleatorios.");
            }
        }
        //Generación de números pseudoaleatorios
        private void btnNumerosPA_Click(object sender, EventArgs e)
        {
            if (txta.TextLength == 0 || txtc.TextLength == 0 || txtXo.TextLength == 0 || txtM.TextLength == 0 || txtn.TextLength == 0)
            {
                MessageBox.Show("Rellena los campos faltantes");
            }
            else
            {
                a = Double.Parse(txta.Text);
                c = Double.Parse(txtc.Text);
                Xo = Double.Parse(txtXo.Text);
                M = Double.Parse(txtM.Text);
                n = int.Parse(txtn.Text);
                double Npaciente = 0;
                acumulador = 0;
                acumpac = 0;
                dataGridView1.Rows.Clear();



                //tabla de num pseudoaleatorios
                for (int i = 0; i < n; i++)
                {
                    modulo = (a * Xo + c) % M;
                    numerospseudoaleatorios[i] = modulo / M;
                    double ri = Math.Round(numerospseudoaleatorios[i],5);
                    double X = 0;

                    ad = dataGridView1.Rows.Add();
                    dataGridView1.Rows[ad].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[ad].Cells[1].Value = ri.ToString();



                    Npaciente = Math.Round(X);
                    numpacientes[i] = Npaciente;
                    //columna número de pacientes por día
                    dataGridView1.Rows[ad].Cells[2].Value = Npaciente.ToString();

                    acumulador += numerospseudoaleatorios[i];
                    acumpac += numpacientes[i];
                    Xo = modulo;
                }

                //obtenemos el promedio de los números pseodoaleatorios
                promedio = acumulador / n;
                lblpromedio.Text = (Math.Round(promedio, 5)).ToString();

                //obtenemos la distribución normal
                Zo = ((Math.Sqrt(n)) * (promedio - 0.5)) / (Math.Sqrt(0.083333333));
                lbldisnor2.Text = (Math.Round(Zo, 5)).ToString();

            }

        }

        //Botón para hacer mandar a llamar los cálculos
        private void btnModa_Click(object sender, EventArgs e)
        {
            Calcular();
            btnDecision.Enabled = true;

        }

        //Cálculos
        public void Calcular()
        {
            if (txtMinimo.TextLength == 0 || txtPromedio.TextLength == 0 || txtMaximo.TextLength == 0)
            {
                MessageBox.Show("Rellena los campos faltantes");
            }
            else
            {
                if (dataGridView1.RowCount > 1)
                {
                    //se inicializan los valores de las variables del generador
                    //para cuando se de clic al botón más de una vez
                    a = Double.Parse(txta.Text);
                    c = Double.Parse(txtc.Text);
                    Xo = Double.Parse(txtXo.Text);
                    M = Double.Parse(txtM.Text);
                    n = int.Parse(txtn.Text);
                    double Npaciente = 0;
                    acumulador = 0;
                    acumpac = 0;
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    dataGridView3.Rows.Clear();
                    double min = Double.Parse(txtMinimo.Text), prom = Double.Parse(txtPromedio.Text), max = Double.Parse(txtMaximo.Text);
                    //se calcula la moda
                    double moda = (prom - min) / (max - min);
                    txtModa.Text = moda.ToString();

                    //contadores de personas que estan en los servicios
                    double p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0;
                    //tabla de num pseudoaleatorios
                    for (int i = 0; i < n; i++)
                    {
                        modulo = (a * Xo + c) % M;
                        numerospseudoaleatorios[i] = modulo / M;
                        double ri = Math.Round(numerospseudoaleatorios[i], 5);
                        double X = 0;

                        ad = dataGridView1.Rows.Add();
                        dataGridView1.Rows[ad].Cells[0].Value = (i + 1).ToString();
                        dataGridView1.Rows[ad].Cells[1].Value = ri.ToString();

                        //formulas distribucion triangular
                        if (ri <= moda)
                        {
                            X = min + (Math.Sqrt((prom - min) * (max - min) * ri));
                        }
                        else if (ri > moda)
                        {
                            X = max - (Math.Sqrt((max - prom) * (max - min) * (1 - ri)));
                        }

                        Npaciente = Math.Round(X);
                        numpacientes[i] = Npaciente;
                        //columna número de pacientes por día
                        dataGridView1.Rows[ad].Cells[2].Value = Npaciente.ToString();

                        acumulador += numerospseudoaleatorios[i];
                        acumpac += numpacientes[i];
                        Xo = modulo;
                    }
                    TablaServicios();

                    int j = 1;
                    for (int i = n; i < (n + acumpac); i++)
                    {
                        modulo = (a * Xo + c) % M;
                        numerospseudoaleatorios[i] = modulo / M;
                        double ri = Math.Round(numerospseudoaleatorios[i], 5);


                        ad = dataGridView2.Rows.Add();
                        dataGridView2.Rows[ad].Cells[0].Value = (j).ToString();
                        dataGridView2.Rows[ad].Cells[1].Value = ri.ToString();

                        acumulador += numerospseudoaleatorios[i];

                        Xo = modulo;

                        //simula los servicios de cada paciente
                        if (ri >= 0 && ri < Double.Parse(dataGridView3.Rows[0].Cells[3].Value.ToString()))
                        {
                            dataGridView2.Rows[ad].Cells[2].Value = dataGridView3.Rows[0].Cells[0].Value;
                            dataGridView2.Rows[ad].Cells[3].Value = dataGridView3.Rows[0].Cells[4].Value;
                        }
                        else if (ri >= Double.Parse(dataGridView3.Rows[1].Cells[2].Value.ToString()) && ri < Double.Parse(dataGridView3.Rows[1].Cells[3].Value.ToString()))
                        {
                            dataGridView2.Rows[ad].Cells[2].Value = dataGridView3.Rows[1].Cells[0].Value;
                            dataGridView2.Rows[ad].Cells[3].Value = dataGridView3.Rows[1].Cells[4].Value;
                        }
                        else if (ri >= Double.Parse(dataGridView3.Rows[2].Cells[2].Value.ToString()) && ri < Double.Parse(dataGridView3.Rows[2].Cells[3].Value.ToString()))
                        {
                            dataGridView2.Rows[ad].Cells[2].Value = dataGridView3.Rows[2].Cells[0].Value;
                            dataGridView2.Rows[ad].Cells[3].Value = dataGridView3.Rows[2].Cells[4].Value;
                        }
                        else if (ri >= Double.Parse(dataGridView3.Rows[3].Cells[2].Value.ToString()) && ri < Double.Parse(dataGridView3.Rows[3].Cells[3].Value.ToString()))
                        {
                            dataGridView2.Rows[ad].Cells[2].Value = dataGridView3.Rows[3].Cells[0].Value;
                            dataGridView2.Rows[ad].Cells[3].Value = dataGridView3.Rows[3].Cells[4].Value;
                        }
                        else if (ri >= Double.Parse(dataGridView3.Rows[4].Cells[2].Value.ToString()) && ri < Double.Parse(dataGridView3.Rows[4].Cells[3].Value.ToString()))
                        {
                            dataGridView2.Rows[ad].Cells[2].Value = dataGridView3.Rows[4].Cells[0].Value;
                            dataGridView2.Rows[ad].Cells[3].Value = dataGridView3.Rows[4].Cells[4].Value;
                        }
                        else if (ri >= Double.Parse(dataGridView3.Rows[5].Cells[2].Value.ToString()) && ri < Double.Parse(dataGridView3.Rows[5].Cells[3].Value.ToString()))
                        {
                            dataGridView2.Rows[ad].Cells[2].Value = dataGridView3.Rows[5].Cells[0].Value;
                            dataGridView2.Rows[ad].Cells[3].Value = dataGridView3.Rows[5].Cells[4].Value;
                        }
                        else if (ri >= Double.Parse(dataGridView3.Rows[6].Cells[2].Value.ToString()) && ri < Double.Parse(dataGridView3.Rows[6].Cells[3].Value.ToString()))
                        {
                            dataGridView2.Rows[ad].Cells[2].Value = dataGridView3.Rows[6].Cells[0].Value;
                            dataGridView2.Rows[ad].Cells[3].Value = dataGridView3.Rows[6].Cells[4].Value;
                        }

                        //Se cuentan los servicios realizados
                        if (dataGridView2.Rows[ad].Cells[3].Value == dataGridView3.Rows[0].Cells[4].Value)
                        {
                            p1++;
                        }
                        else if (dataGridView2.Rows[ad].Cells[3].Value == dataGridView3.Rows[1].Cells[4].Value)
                        {
                            p2++;
                        }
                        else if (dataGridView2.Rows[ad].Cells[3].Value == dataGridView3.Rows[2].Cells[4].Value)
                        {
                            p3++;
                        }
                        else if (dataGridView2.Rows[ad].Cells[3].Value == dataGridView3.Rows[3].Cells[4].Value)
                        {
                            p4++;
                        }
                        else if (dataGridView2.Rows[ad].Cells[3].Value == dataGridView3.Rows[4].Cells[4].Value)
                        {
                            p5++;
                        }
                        else if (dataGridView2.Rows[ad].Cells[3].Value == dataGridView3.Rows[5].Cells[4].Value)
                        {
                            p6++;
                        }
                        else if (dataGridView2.Rows[ad].Cells[3].Value == dataGridView3.Rows[6].Cells[4].Value)
                        {
                            p7++;
                        }

                        j++;
                    }

                    //se agrega el precio a la tabla
                    dataGridView3.Rows[0].Cells[5].Value = p1;
                    dataGridView3.Rows[0].Cells[6].Value = Double.Parse(dataGridView3.Rows[0].Cells[4].Value.ToString()) * p1;
                    dataGridView3.Rows[1].Cells[5].Value = p2;
                    dataGridView3.Rows[1].Cells[6].Value = Double.Parse(dataGridView3.Rows[1].Cells[4].Value.ToString()) * p2;
                    dataGridView3.Rows[2].Cells[5].Value = p3;
                    dataGridView3.Rows[2].Cells[6].Value = Double.Parse(dataGridView3.Rows[2].Cells[4].Value.ToString()) * p3;
                    dataGridView3.Rows[3].Cells[5].Value = p4;
                    dataGridView3.Rows[3].Cells[6].Value = Double.Parse(dataGridView3.Rows[3].Cells[4].Value.ToString()) * p4;
                    dataGridView3.Rows[4].Cells[5].Value = p5;
                    dataGridView3.Rows[4].Cells[6].Value = Double.Parse(dataGridView3.Rows[4].Cells[4].Value.ToString()) * p5;
                    dataGridView3.Rows[5].Cells[5].Value = p6;
                    dataGridView3.Rows[5].Cells[6].Value = Double.Parse(dataGridView3.Rows[5].Cells[4].Value.ToString()) * p6;
                    dataGridView3.Rows[6].Cells[5].Value = p7;
                    dataGridView3.Rows[6].Cells[6].Value = Double.Parse(dataGridView3.Rows[6].Cells[4].Value.ToString()) * p7;




                    //MUESTRA DE RESULTADOS
                    nsimulados = 0;
                    gananciast = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        nsimulados += Double.Parse(dataGridView3.Rows[i].Cells[5].Value.ToString());
                        gananciast += Double.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
                    }

                    txtSimulados.Text = nsimulados.ToString();
                    txtGanancia.Text = gananciast.ToString();
                }
                else
                {
                    MessageBox.Show("No se pueden hacer cálculos sin generar los números pseudoaleatorios.");

                }
            }
        }

        //Se agregan valores a la tabla
        public void TablaServicios()
        {
            //agregar nombres de servicio a la tabla
            dataGridView3.Rows[dataGridView3.Rows.Add()].Cells[0].Value = "Atención de emergencia";
            dataGridView3.Rows[dataGridView3.Rows.Add()].Cells[0].Value = "Consulta familiar";
            dataGridView3.Rows[dataGridView3.Rows.Add()].Cells[0].Value = "Laboratorio";
            dataGridView3.Rows[dataGridView3.Rows.Add()].Cells[0].Value = "Operaciones menores";
            dataGridView3.Rows[dataGridView3.Rows.Add()].Cells[0].Value = "Operaciones especializadas";
            dataGridView3.Rows[dataGridView3.Rows.Add()].Cells[0].Value = "Vacuna y sanidad";
            dataGridView3.Rows[dataGridView3.Rows.Add()].Cells[0].Value = "Cuidados intensivos";



            //agregar probabilidades
            dataGridView3.Rows[0].Cells[1].Value = S1Prob;
            dataGridView3.Rows[1].Cells[1].Value = S2Prob;
            dataGridView3.Rows[2].Cells[1].Value = S3Prob;
            dataGridView3.Rows[3].Cells[1].Value = S4Prob;
            dataGridView3.Rows[4].Cells[1].Value = S5Prob;
            dataGridView3.Rows[5].Cells[1].Value = S6Prob;
            dataGridView3.Rows[6].Cells[1].Value = S7Prob;


            //agregar limites a la tabla 
            double liminf = 0;
            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                double limsup = liminf + Double.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());
                dataGridView3.Rows[i].Cells[2].Value = liminf;
                dataGridView3.Rows[i].Cells[3].Value = limsup;
                liminf = limsup;
            }

            //agregar precios
            dataGridView3.Rows[0].Cells[4].Value = S1Precio;
            dataGridView3.Rows[1].Cells[4].Value = S2Precio;
            dataGridView3.Rows[2].Cells[4].Value = S3Precio;
            dataGridView3.Rows[3].Cells[4].Value = S4Precio;
            dataGridView3.Rows[4].Cells[4].Value = S5Precio;
            dataGridView3.Rows[5].Cells[4].Value = S6Precio;
            dataGridView3.Rows[6].Cells[4].Value = S7Precio;
        }

        //Botón para la toma de decisión
        private void btnDecision_Click(object sender, EventArgs e)
        {

            if (txtCostoOp.TextLength == 0)
            {
                MessageBox.Show("Debes rellenar el campo del costo de operación.");

            }
            else
            {
                if (double.Parse(txtCostoOp.Text) < double.Parse(txtGanancia.Text))
                {
                    panelDecision.Visible = true;
                    label17.Visible = false;
                    txtGananciaDecision.Visible = false;
                    lblDecision.Text = "Se concluye que resulta costeable mantener el hospital con una cantidad de " + (dataGridView3.RowCount - 1).ToString() + " servicios manteniendo sus precios iniciales.";
                    lblDecision.Dock = DockStyle.Fill;
                }
                else
                {

                    while (double.Parse(txtGananciaDecision.Text) < double.Parse(txtCostoOp.Text))
                    {
                        DecisionCalcular();
                    }
                    int cantServ = dataGridView3.RowCount - 1;
                    lblDecision.Text = "La cantidad de servicios que deberan usar son: " + cantServ.ToString() + "\n. Los precios se han actualizado en la tabla";
                    btnDecision.Enabled = false;
                    panelDecision.Visible = true;

                }
            }

        }
        
        //Método para calcular en caso de que no sea costeable
        public void DecisionCalcular()
        {
            int j = 0;
            int inicio = dataGridView3.RowCount - 1;
            for (int i = 0; i < inicio; i++)
            {
                if (i == 0)
                {
                }
                else
                {
                    if (double.Parse(dataGridView3.Rows[i - 1].Cells[6].Value.ToString()) < double.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString()))
                    {
                        j = i - 1;
                    }
                    else
                    {
                        j = i;
                    }
                }
            }
            MessageBox.Show(dataGridView3.Rows[j].Cells[6].Value.ToString() + " este es menor");
            double promEliminado = double.Parse(dataGridView3.Rows[j].Cells[1].Value.ToString());
            //Elimina
            dataGridView3.Rows.Remove(dataGridView3.Rows[j]);
            int inicio2 = dataGridView3.RowCount - 1;
            double sumarProm = promEliminado / inicio2;
            MessageBox.Show(sumarProm.ToString());
            //suma para que el promedio llegue a 1
            double liminf = 0;
            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                double promAnterior = double.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());
                double promNuevo = promAnterior + sumarProm;
                dataGridView3.Rows[i].Cells[1].Value = Math.Round(promNuevo, 4);
                double limsup = liminf + Double.Parse(promNuevo.ToString());
                dataGridView3.Rows[i].Cells[2].Value = liminf;
                dataGridView3.Rows[i].Cells[3].Value = limsup;
                liminf = limsup;
            }
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                double ri = Double.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());

                for (int k = 0; k < dataGridView3.RowCount - 1; k++)
                {
                    if (ri >= Double.Parse(dataGridView3.Rows[k].Cells[2].Value.ToString()) && ri < Double.Parse(dataGridView3.Rows[k].Cells[3].Value.ToString()))
                    {
                        dataGridView2.Rows[i].Cells[2].Value = dataGridView3.Rows[k].Cells[0].Value;
                        dataGridView2.Rows[i].Cells[3].Value = dataGridView3.Rows[k].Cells[4].Value;

                    }
                }
            }

            //contador de servicios
            double acumuladorprecio = 0;
            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                int contadorservicios = 0;
                for (int k = 0; k < dataGridView2.RowCount - 1; k++)
                {
                    if (dataGridView2.Rows[k].Cells[3].Value == dataGridView3.Rows[i].Cells[4].Value)
                    {
                        contadorservicios++;
                    }
                }
                dataGridView3.Rows[i].Cells[5].Value = contadorservicios;

                //se le agrega el total precio
                dataGridView3.Rows[i].Cells[6].Value = contadorservicios * double.Parse(dataGridView3.Rows[i].Cells[4].Value.ToString());
                //cuenta la nueva ganancia sin modificar los precios
                acumuladorprecio += double.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
            }
            double costoOperacion = double.Parse(txtCostoOp.Text);
            double diferencia = Math.Abs(gananciast - acumuladorprecio);
            double gananciaDecision = ((100 / costoOperacion) * diferencia) / 100;


            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                double precioanterior = Double.Parse(dataGridView3.Rows[i].Cells[4].Value.ToString());
                double sumarprecio = precioanterior * gananciaDecision;
                double precionuevo = precioanterior + sumarprecio;
                dataGridView3.Rows[i].Cells[4].Value = precionuevo;
                //se saca el ingreso por cada servicio
                double ingresonuevo = Double.Parse(dataGridView3.Rows[i].Cells[5].Value.ToString()) * precionuevo;
                dataGridView3.Rows[i].Cells[6].Value = ingresonuevo;
            }



            // se vuelven a calcular los precios para dar la ganancia total con las mejoras
            double acumuladorprecio2 = 0;
            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                acumuladorprecio2 += double.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
            }
            txtGananciaDecision.Text = acumuladorprecio2.ToString();

            //se actualizan los precios en el data 2
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                double ri = Double.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());

                for (int k = 0; k < dataGridView3.RowCount - 1; k++)
                {
                    if (ri >= Double.Parse(dataGridView3.Rows[k].Cells[2].Value.ToString()) && ri < Double.Parse(dataGridView3.Rows[k].Cells[3].Value.ToString()))
                    {
                        dataGridView2.Rows[i].Cells[3].Value = dataGridView3.Rows[k].Cells[4].Value;

                    }
                }
            }
        }

        //Limpia todos los datos y tablas
        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            txta.Clear(); txtc.Clear(); txtGanancia.Clear(); txtM.Clear(); txtMaximo.Clear();
            txtMinimo.Clear(); txtModa.Clear(); txtn.Clear(); txtPromedio.Clear(); txtSimulados.Clear(); txtXo.Clear();

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();

        }

       
        //Validaciones
        private void txta_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == '.')
            {
                e.Handled = true;
                MessageBox.Show("Sólo se admiten valores enteros.");
            }
            if (e.KeyChar == '-')
            {
                e.Handled = true;
                MessageBox.Show("No se permiten valores negativos.");
            }
        }
        private void txtCostoOp_KeyPress(object sender, KeyPressEventArgs e)
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
    }
    
    
}
