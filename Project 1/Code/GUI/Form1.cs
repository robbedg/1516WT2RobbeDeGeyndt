﻿using IShapes;
using Shapes;
using ILogic;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {

        //Timing

        Timer timer;

        //Globale variabelen voor GDI+
        Graphics screen;
        Bitmap backBuffer;
        float SchaalX;
        float SchaalY;

        //variabels for model
        Int32 time;                        //in msec

        double theta;                      //in degrees
        double standgrav;                  //standard gravity

        bool started;                      //simulation running.
        bool hasCollision;                 //collision happened

        ICalculations collision;

        ICircle circle;                    //Circle
        IRectangle rectangle;              //Rectangle

        public Form1()
        {
            InitializeComponent();
            InitGame();
            InitRenderer();
            InitTimer();
            startButton.Enabled = true;
        }

        //Timing
        private void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 10;            //msec, f = 100 Hz;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DoGame();
            display.Invalidate();           //force redraw (& paint event);
        }

        #region game loop

        private void InitGame()
        {
            //initialize collision
            collision = new Calculations();
            //initialize circle
            circle = new Circle((double)numericCircleMass.Value, 40, 480, 0);
            //intialize rectangle
            rectangle = new Shapes.Rectangle((double)numericRectangleMass.Value, (double)numericStaticFriction.Value, (double)numericKineticFriction.Value, 160, 80, (480 - 120 - (int)numericDistance.Value), 0);

            theta = (double)numericAngle.Value;                 //set angle
            standgrav = (double)numericStandGrav.Value;         //set standard gravity
            time = 0;                                           //set time

            circle.acceleration = 0;                            //set acceleration circle
            circle.speed = 0;                                   //set speed circle

            rectangle.acceleration = 0;                         //set acceleration rectangle
            rectangle.speed = 0;                                //set speed rectangle

            started = false;                                    //set if started
            hasCollision = false;                               //set if collided
        }

        private void DoGame()
        {
            //timer
            time += timer.Interval;

            //if collision happend
            if (hasCollision)
            {
                rectangle.acceleration = collision.ResultAcceleration(circle.acceleration, standgrav, theta, (Circle)circle, (Shapes.Rectangle)rectangle);
                
                circle.acceleration = rectangle.acceleration;

                //acceleration 0;
                if ((rectangle.acceleration <= 0)) rectangle.acceleration = 0;

                //set values
                rectangle.speed = rectangle.acceleration * (time / 1000.0d);
                circle.speed = rectangle.speed;
            }
            //before collision happened
            else
            {
                circle.acceleration = collision.Acceleration(standgrav, theta, 0);

                if (collision.Acceleration(standgrav, theta, rectangle.staticFriction) > 0)
                {
                    rectangle.acceleration = collision.Acceleration(standgrav, theta, rectangle.kineticFriction);
                }

                //set values
                circle.speed = circle.acceleration * (time / 1000.0d);
                rectangle.speed = rectangle.acceleration * (time / 1000.0d);
            }
        }

        #endregion game loop

        #region renderer

        private void InitRenderer()
        {
            backBuffer = new Bitmap(display.Width, display.Height);
            screen = Graphics.FromImage(backBuffer);
            //transformation, set coordinate system
            SchaalX = display.Width / 1000.0f;
            SchaalY = display.Height / 1000.0f;
            screen.ResetTransform();
            screen.ScaleTransform(SchaalX, -SchaalY); //scaling
            screen.TranslateTransform(display.Width / (SchaalX * 2f), -display.Height / (SchaalY * 2f)); //set middel
            //set rotation
            screen.RotateTransform((float)theta);
            //render with each display refresh
            display.Paint += new PaintEventHandler(PaintDisplay);
        }

        private void PaintDisplay(object sender, PaintEventArgs e)
        {
            //On_Paint event handler for display
            Render(e.Graphics);
        }

        //Generate objects on screen.
        private void Render(Graphics output)
        {
            screen.Clear(Color.White);

            //draw line
            screen.DrawLine(new Pen(Color.Blue), new Point(-1000, 0), new Point(1000, 0));

            //X-coordinate circle and rectangle
            circle.X -= (int)((circle.speed * 0.010) * (double)numericPPM.Value);
            rectangle.X -= (int)((rectangle.speed * 0.010) * (double)numericPPM.Value);

            //Check collision
            if (collision.CheckCollision((Circle)circle, (Shapes.Rectangle)rectangle))
            {
                //set X correct.
                circle.X = (rectangle.X + (rectangle.width / 2)) + circle.radius;

                //stop when v=0
                if (collision.ResultAcceleration(circle.acceleration, standgrav, theta, (Circle)circle, (Shapes.Rectangle)rectangle) <= 0)
                {
                    stop();
                    startButton.Enabled = false;
                    checkStopped.Checked = true;
                }
                else
                {
                    if (!hasCollision)
                    {
                        checkCollision.Checked = true;
                    }
                    hasCollision = true;
                }
            }

            //Draw circle
            System.Drawing.Rectangle boundingBox = new System.Drawing.Rectangle(new Point(circle.X - circle.radius, circle.Y), new Size(circle.radius * 2, circle.radius * 2));
            screen.FillEllipse(new SolidBrush(Color.Crimson), boundingBox);

            //Draw rectangle
            System.Drawing.Rectangle boundingBoxrect = new System.Drawing.Rectangle(new Point(rectangle.X - (rectangle.width / 2), rectangle.Y), new Size(rectangle.width, rectangle.height));
            screen.FillRectangle(new SolidBrush(Color.Green), boundingBoxrect);

            // toon backbuffer op display
            output.DrawImage(backBuffer, new System.Drawing.Rectangle(0, 0, display.Width, display.Height), new System.Drawing.Rectangle(0, 0, display.Width, display.Height), GraphicsUnit.Pixel);

            
            //check circle
            if (((circle.X <= -500) || (rectangle.X <= -500)) && !checkOutframe.Checked)
            {
                startButton_Click(new object(), new EventArgs());
                startButton.Enabled = false;
                checkOutframe.Checked = true;
            }
            // display textboxes
            textBoxCircleSpeed.Text = "" + circle.speed;
            textBoxAccCircle.Text = "" + circle.acceleration;
            textBoxSpeedRect.Text = "" + rectangle.speed;
            textBoxRectAcc.Text = "" + rectangle.acceleration;
            textBoxTime.Text = "" + time;
        }

        #endregion renderer

        //interactie
        private void startButton_Click(object sender, EventArgs e)
        {
            if (started)
            {
                stop();
            }
            else
            {
                timer.Enabled = true;
                startButton.Text = "Pause";
                started = true;
                updateButton.Enabled = false;
            }
        }

        //stop simulation
        private void stop()
        {
            timer.Enabled = false;
            startButton.Text = "Start";
            started = false;
            updateButton.Enabled = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            checkCollision.Checked = false;
            checkStopped.Checked = false;
            checkOutframe.Checked = false;
            InitTimer();
            InitGame();
            InitRenderer();
            startButton.Enabled = true;
            display.Invalidate();
        }

        private void numericDistance_ValueChanged(object sender, EventArgs e)
        {
            textBoxDistance.Text = "" + numericDistance.Value / numericPPM.Value;
        }
    }
}
