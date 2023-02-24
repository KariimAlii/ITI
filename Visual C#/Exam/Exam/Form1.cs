using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class Form1 : Form
    {
        bool lineRequied;
        bool rectangleRequied;
        bool circleRequied;
        bool isMouseDown;
        Point start, end;
        bool isFreehandRequired;
        //================ Line =================//
        public static Color Line_Color;
        string Line_Thickness;
        int Line_Thickness_Number;
        Pen Line_Pen;
        Point Line_Start;
        Point Line_End;
        DashStyle Line_Style;
        //================ Rectangle =================//
        Color Rect_Color;
        Rectangle Rect;
        Pen Rect_Pen;
        HatchBrush Rect_Brush;
        //================ Circle =================//
        Color Circle_Color;
        Pen Circle_Pen;
        public Form1()
        {
            InitializeComponent();
            //================ Line =================//
            Line_Thickness = "Normal";
            Line_Thickness_Number = 3;
            Line_Color = Color.Red;

            //================ Adjust Window =================//
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            toolStripButton9.Text = "Freehand";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void DrawLine(Color color, int penSize, int xStart, int yStart, int xEnd, int yEnd, DashStyle style)
        {
            Line_Color = color;
            Line_Pen = new Pen(color, penSize);
            Line_Pen.DashStyle = style;
            Line_Start = new Point(xStart, yStart);
            Line_End = new Point(xEnd, yEnd);
            Graphics g = this.CreateGraphics();
            g.DrawLine(Line_Pen, Line_Start, Line_End);
        }
        public void DrawRectangle(Color color, int penSize, int x, int y, int width, int height)
        {
            Rect_Color = color;
            Rect_Pen = new Pen(color, penSize);
            Rect = new Rectangle(x, y, width, height);
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(Rect_Pen, Rect);
        }
        public void DrawFilledRectangle(Color color, int penSize, int x, int y, int width, int height)
        {
            Rect_Color = color;
            Rect_Brush = new HatchBrush(HatchStyle.BackwardDiagonal, color, Color.Empty);
            Rect = new Rectangle(x, y, width, height);
            Graphics g = this.CreateGraphics();
            g.FillRectangle(Rect_Brush, Rect);
        }
        public void DrawCircle(Color color, int penSize, int x, int y, int width, int height)
        {
            Circle_Pen = new Pen(color, penSize);
            Graphics g = this.CreateGraphics();
            g.DrawEllipse(Circle_Pen, x, y, width, height);
        }
        public void AdjustStatusBar()
        {
            ColorLabel.Text = "Color:" + Line_Color.ToString();
            ThicknessLabel.Text = "Thickness:" + Line_Thickness;
            ShapeLabel.Text = "Shape: ";
            if (lineRequied) ShapeLabel.Text += "Line, ";
            if (rectangleRequied) ShapeLabel.Text += "Rectangle, ";
            if (circleRequied) ShapeLabel.Text += "Circle";
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (lineRequied) DrawLine(Line_Color, Line_Thickness_Number, 200, 200, 800, 800, DashStyle.Solid);
            if (rectangleRequied)
            {
                DrawRectangle(Line_Color, Line_Thickness_Number, 200, 200, 600, 600);
                DrawFilledRectangle(Line_Color, Line_Thickness_Number, 200, 200, 600, 600);
            }
            if (circleRequied) DrawCircle(Line_Color, Line_Thickness_Number, 50, 50, 200, 200);
            AdjustStatusBar();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {

            Invalidate();
        }

        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StyleDialogBox dlg_Box = new StyleDialogBox();
            dlg_Box.LineColor = Line_Color;
            dlg_Box.LineThickness = Line_Thickness;
            DialogResult dlg_Result = dlg_Box.ShowDialog();
            if (dlg_Result == DialogResult.OK)
            {
                Line_Color = dlg_Box.LineColor;
                Line_Thickness = dlg_Box.LineThickness;
                switch (Line_Thickness)
                {
                    case "Normal":
                        Line_Thickness_Number = 3;
                        break;
                    case "Bold":
                        Line_Thickness_Number = 4;
                        break;
                    case "Bolder":
                        Line_Thickness_Number = 5;
                        break;
                    case "Strong":
                        Line_Thickness_Number = 6;
                        break;
                    case "Bold Strong":
                        Line_Thickness_Number = 7;
                        break;
                }
                Invalidate();
            }
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lineRequied) lineRequied = false;
            else lineRequied = true;
            Invalidate();
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (circleRequied) circleRequied = false;
            else circleRequied = true;
            Invalidate();
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rectangleRequied) rectangleRequied = false;
            else rectangleRequied = true;
            Invalidate();
        }



        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Line_Thickness = "Normal";
            Line_Thickness_Number = 3;
            Invalidate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Line_Thickness = "Bold";
            Line_Thickness_Number = 4;
            Invalidate();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Line_Thickness = "Bolder";
            Line_Thickness_Number = 5;
            Invalidate();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Line_Thickness = "Strong";
            Line_Thickness_Number = 6;
            Invalidate();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Line_Thickness = "Bold Strong";
            Line_Thickness_Number = 7;
            Invalidate();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (lineRequied) lineRequied = false;
            else lineRequied = true;
            Invalidate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (rectangleRequied) rectangleRequied = false;
            else rectangleRequied = true;
            Invalidate();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (circleRequied) circleRequied = false;
            else circleRequied = true;
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            isMouseDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void freehandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isFreehandRequired) isFreehandRequired = false;
            else isFreehandRequired = true;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (isFreehandRequired) isFreehandRequired = false;
            else isFreehandRequired = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true && isFreehandRequired)
            {
                end = e.Location;
                DrawLine(Line_Color, Line_Thickness_Number, start.X, start.Y, end.X, end.Y, DashStyle.Solid);
                start = end;
            }
        }
    }
}
