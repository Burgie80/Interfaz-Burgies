# Práctica 1: C# con Pico W

```cs
/*
  Programa: Pr�ctica 1: C# y Pico W
  Autores: 
    - L�pez Machado �scar Roberto - [N�mero de control]
    - Morales Calvo �ngel Omar - [N�mero de control]
    - Torres Equihua Victor Manuel - [N�mero de control]
    - Van Pratt Gonz�lez Ricardo Adolfo - 21212581
  Fecha: 29 de abril de 2024

  Descripci�n:
  Este programa se conecta a una Pico W mediante un programa de Windows Forms para que env�e un mensaje

  Licencia: [Tipo de licencia]
*/

using System;
using System.IO.Ports;
using System.Threading;

namespace Practica_1
{
    public partial class Form1 : Form
    {
        SerialPort puerto = new SerialPort();
        bool check = false;

        public Form1()
        {
            InitializeComponent();
        }

        // Llama un evento existente para no reescribir el c�digo
        private void Form1_Load(object sender, EventArgs e)
        {
            btnReiniciar_Click(sender, e);
        }

        // Borra el mensaje escrito, reestablece el objeto seleccionado, y deshabilita el bot�n de enviar.
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            txtMensaje.Clear();
            cmbPuertos.SelectedIndex = 0;
            btnEnviar.Enabled = false;
        }

        // Establece una conexi�n si se est� desconectado, y lo desconecta si ya estaba conectado.
        // Si el puerto es el apropiado, se conecta exitosamente.
        // Si no swe puede, tira mensaje de error.
        private void btnConexion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!check)
                {
                    puerto.PortName = cmbPuertos.SelectedItem.ToString();
                    puerto.BaudRate = 115200;
                    puerto.DtrEnable = true;

                    puerto.Open();

                    MessageBox.Show($"Conectado al puerto {puerto.PortName}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cmbPuertos.Enabled = false;
                    btnConexion.Text = "Desconectarse";
                    check = true;
                }
                else
                {
                    puerto.Close();

                    MessageBox.Show("Adi�s", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cmbPuertos.Enabled = true;
                    btnEnviar.Enabled = false;
                    btnConexion.Text = "Conectarse";
                    check = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "�Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Intenta hacer que la Raspberry escriba el mensaje enviado a una terminal.
        // Si no hay un mensaje, despliega un mensaje indicando la falta de texto.
        // Despliega un mensaje de error si no se complet� la acci�n
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMensaje.Text))
                {
                    puerto.WriteLine(txtMensaje.ToString());
                    MessageBox.Show("Mensaje enviado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No hay mensaje para enviar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "�Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMensaje_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        // Verifica si la barra de texto con el mensaje est� vac�a o no.
        // Si est� vac�a, deshabilita el bot�n para enviar el mensaje.
        // Si no est� vac�a, lo habilita.
        private void Actualizar()
        {
            if (string.IsNullOrEmpty(txtMensaje.Text) || check == false)
            {
                btnEnviar.Enabled = false;
            }
            else
            {
                btnEnviar.Enabled = true;
            }
        }
    }
}
```
