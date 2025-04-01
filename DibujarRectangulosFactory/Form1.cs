using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
//0rganizacion de botones
namespace DibujarRectangulosFactory 
{
    public partial class Form1 : Form 
    {
        private int rectCount = 0;
        private Color selectedColor = Color.Black;
        private List<Rectangulo> rectangles = new List<Rectangulo>();

        private Button btnSelectColor;
        private PictureBox picColorDisplay;
        private Label lblX;
        private TextBox txtX;
        private Label lblY;
        private TextBox txtY;
        private Button btnDrawRectangle;
        private Label lblCounter;
        private TextBox txtCounter;

        public Form1() 
        {
            InitializeDynamicControls();
        }

        private void InitializeDynamicControls()
        {
            
            btnSelectColor = new Button();
            btnSelectColor.Text = "Seleccionar Color";
            btnSelectColor.Location = new Point(10, 10);
            btnSelectColor.Click += btnSelectColor_Click;
            Controls.Add(btnSelectColor);

          
            picColorDisplay = new PictureBox();
            picColorDisplay.BackColor = selectedColor;
            picColorDisplay.BorderStyle = BorderStyle.FixedSingle;
            picColorDisplay.Location = new Point(btnSelectColor.Right + 10, 10);
            picColorDisplay.Size = new Size(30, 30);
            Controls.Add(picColorDisplay);

 
            lblX = new Label();
            lblX.Text = "X:";
            lblX.Location = new Point(10, btnSelectColor.Bottom + 10);
            lblX.AutoSize = true;
            Controls.Add(lblX);

           
            txtX = new TextBox();
            txtX.Location = new Point(lblX.Right + 5, btnSelectColor.Bottom + 8);
            txtX.Size = new Size(50, 20);
            Controls.Add(txtX);

    
            lblY = new Label();
            lblY.Text = "Y:";
            lblY.Location = new Point(txtX.Right + 10, btnSelectColor.Bottom + 10);
            lblY.AutoSize = true;
            Controls.Add(lblY);

            txtY = new TextBox();
            txtY.Location = new Point(lblY.Right + 5, btnSelectColor.Bottom + 8);
            txtY.Size = new Size(50, 20);
            Controls.Add(txtY);

 
            btnDrawRectangle = new Button();
            btnDrawRectangle.Text = "Dibujar Rectángulo";
            btnDrawRectangle.Location = new Point(10, lblX.Bottom + 10);
            btnDrawRectangle.Click += btnDrawRectangle_Click;
            Controls.Add(btnDrawRectangle);

            lblCounter = new Label();
            lblCounter.Text = "Cantidad:";
            lblCounter.Location = new Point(10, btnDrawRectangle.Bottom + 10);
            lblCounter.AutoSize = true;
            Controls.Add(lblCounter);


            txtCounter = new TextBox();
            txtCounter.Location = new Point(lblCounter.Right + 5, btnDrawRectangle.Bottom + 8);
            txtCounter.Size = new Size(50, 20);
            txtCounter.ReadOnly = true;
            txtCounter.Text = rectCount.ToString();
            Controls.Add(txtCounter);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MinimumSize = new Size(300, 200); 
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedColor = colorDialog.Color;
                    picColorDisplay.BackColor = selectedColor;
                }
            }
        }

        private void btnDrawRectangle_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txtX.Text);
                int y = int.Parse(txtY.Text);

                Rectangulo rect = FiguraFactory.CrearRectangulo(x, y, selectedColor);
                rectangles.Add(rect); 
                rectCount++;
                txtCounter.Text = rectCount.ToString();
                Invalidate();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese valores numéricos válidos en X e Y.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                foreach (Rectangulo rectangulo in rectangles) 
                {
                    using (Brush brush = new SolidBrush(rectangulo.Color)) 
                    {
                        g.FillRectangle(brush, rectangulo.GetRectangle()); 
                    }
                }
            }
        }
    }

    

    

   
}