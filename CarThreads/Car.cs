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
        public Color CarColor { get; private set; }
        public int GarageTime { get; private set; }
        public int QueueTime { get; set; }
        public bool Parked { get; private set; } = false;
        public int ParkedId { get; set; }

        int counter = 0;

        public Car(int id, Color color, int garageTime, int queueTime)
        {
            CarId = id;
            CarColor = color;
            GarageTime = garageTime;
            QueueTime = queueTime;
            Console.WriteLine($"Thread {CarId} is created with {GarageTime} ms of sleep");
        }

        public void Run()
        {
            Label label;
            while(Form1.programRunning)
            {
                Console.WriteLine($"Thread {CarId} is working, counter {counter++}");
                for (int i = 0; (i < Form1.parking.Count) && Form1.programRunning; i++)
                {
                    if(Form1.parking.TryGetValue(i, out label))
                    {
                        //Sprawdź, czy na pewno Cię nie ma na parkingu (w sensie auta)
                        var values = Form1.parking.Values;
                        if (!values.Any(l => l.Text.Equals("T " + CarId)))
                        {
                            if(label.Text.Equals("Empty"))
                            {
                                Console.WriteLine($"Car {CarId} found free place on parking");

                                Parked = true;
                                ParkedId = i;

                                Thread.Sleep(GarageTime);
                                Parked = false;
                            }
                        }
                    }
                }
                Thread.Sleep(QueueTime);
                Console.WriteLine($"Thread {CarId} slept");
            }
            Console.WriteLine($"Car {CarId} stopped, ready to join.");
        }
    }
}
