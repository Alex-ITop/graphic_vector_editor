using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeorProg2.Control;
using TeorProg2.GraphicItems;
using TeorProg2.Model;
using TeorProg2.Property;

namespace TeorProg2
{
    public partial class Form1 : Form
    {
        public Graphics graphics;
        internal IController Controller;
        internal Form1(IController controller)
        {
            InitializeComponent();
            graphics = panel1.CreateGraphics();
            Controller= controller;
            Controller.Model.GrController.SetPort(graphics, 1, 1); 
            buttonColor1.BackColor = Controller.Model.GrProperties.FillProps.Color;
            buttonColor2.BackColor = Controller.Model.GrProperties.ContourProps.Color;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            MouseEventArgs cursor = (MouseEventArgs)e;
            Controller.EventHandler.LeftMouseUp(cursor.X, cursor.Y);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.Model.GrProperties.ContourProps.Width = comboBox1.SelectedIndex+1;
            ((GrPropChannel)Controller.Model.GrProperties).ApplyProps();
        }

        private void buttonUnite_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBoxFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFigure.SelectedIndex)
            {
                case 0:
                    Controller.Model.Factory.itemType = ItemType.None;
                    break;
                case 1:
                    Controller.Model.Factory.itemType = ItemType.Line;
                    break;
                case 2:
                    Controller.Model.Factory.itemType = ItemType.Rectangle;
                    break;
            }
        }

        private void buttonFillColor_Click(object sender, EventArgs e)
        {
            Controller.Model.GrProperties.FillProps.Color = GetColor();
            ((GrPropChannel)Controller.Model.GrProperties).ApplyProps();
            buttonColor1.BackColor = Controller.Model.GrProperties.FillProps.Color;
        }

        private void buttonContourColor_Click(object sender, EventArgs e)
        {
            Controller.Model.GrProperties.ContourProps.Color = GetColor();
            ((GrPropChannel)Controller.Model.GrProperties).ApplyProps();
            buttonColor2.BackColor = Controller.Model.GrProperties.ContourProps.Color;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            graphics = panel1.CreateGraphics();
            Controller.Model.GrController.SetPort(graphics, 1, 1);
            Controller.Model.GrController.Repaint();
        }

        private Color GetColor()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    return colorDialog.Color;
                }
            }
            return Color.Black;
        }
    }
}
