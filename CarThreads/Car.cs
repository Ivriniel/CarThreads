using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarThreads
{
    public class Car
    {
        public int CarId { get; private set; }
        public int GarageTime { get; private set; }
        public int ParkedId { get; set; }
        public int ThreadId { get; set; }

        public Car(int id, int threadId, int garageTime)
        {
            CarId = id;
            GarageTime = garageTime;
            ThreadId = threadId;
            Console.WriteLine($"Thread {CarId} is created with {GarageTime} ms of sleep");
        }

        public void Run()
        {
            bool foundParking = false;
            try
            {
                while (!foundParking)
                {
                    Monitor.Enter(Form1.Instance);
                    for (int i = 0; i < Form1.Instance.garages.Controls.Count; i++)
                    {
                        var label = (Label)Form1.Instance.garages.Controls[i];
                        if (label.Text.Equals("Empty"))
                        {
                            Form1.Instance.InvokeUI(() =>
                            {
                                label.Text = "Car " + CarId;
                                label.BackColor = ColorTranslator.FromHtml(Form1.colors[CarId]);
                            });

                            ParkedId = i;
                            foundParking = true;
                            break;
                        }
                    }
                    Monitor.PulseAll(Form1.Instance);
                    Monitor.Exit(Form1.Instance);
                }

                Monitor.Enter(Form1.Instance);
                var queueLabel = Form1.Instance.queue.Controls[CarId];
                Form1.Instance.InvokeUI(() =>
                {
                    queueLabel.Text = "Empty";
                    queueLabel.BackColor = Color.White;
                });
            }
            finally
            {
                Monitor.Exit(Form1.Instance);
            }
                Thread.Sleep(GarageTime);
            
            Monitor.Enter(Form1.Instance);
            try
            {
                var label = (Label)Form1.Instance.garages.Controls[ParkedId];
                Form1.Instance.InvokeUI(() =>
                {
                    label.Text = "Empty";
                    label.BackColor = Color.White;
                });


                var queueLabel = Form1.Instance.queue.Controls[CarId];
                Form1.Instance.InvokeUI(() =>
                {
                    queueLabel.Text = "Car " + CarId;
                    queueLabel.BackColor = ColorTranslator.FromHtml(Form1.colors[CarId]);
                });

            }
            finally
            {
                Monitor.PulseAll(Form1.Instance);
                Monitor.Exit(Form1.Instance);
            }

            Console.WriteLine($"Car {CarId} stopped, ready to join.");
            if (Form1.Instance.programRunning)
            {
                Car c1 = new Car(this.CarId, Form1.Instance.carThreads.Count, this.GarageTime);
                Form1.Instance.carThreads.Add(new Thread(c1.Run));
                Form1.Instance.carThreads.Last().Start(); 
            }
            //Form1.Instance.JoinAndStartNewCar(this);
        }
    }
}
