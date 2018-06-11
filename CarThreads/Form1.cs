using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarThreads
{
    public partial class Form1 : Form
    {
        public static String[] colors = new String[]
            {
                "#000000", "#00FF00", "#0000FF", "#FF0000", "#01FFFE",
                "#FFA6FE", "#FFDB66", "#006401", "#010067", "#95003A",
                "#007DB5", "#FF00F6", "#FFEEE8", "#774D00", "#90FB92",
                "#0076FF", "#D5FF00", "#FF937E", "#6A826C", "#FF029D",
                "#FE8900", "#7A4782", "#7E2DD2", "#85A900", "#FF0056",
                "#A42400", "#00AE7E", "#683D3B", "#BDC6FF", "#263400",
                "#BDD393", "#00B917", "#9E008E", "#001544", "#C28C9F",
                "#FF74A3", "#01D0FF", "#004754", "#E56FFE", "#788231",
                "#0E4CA1", "#91D0CB", "#BE9970", "#968AE8", "#BB8800",
                "#43002C", "#DEFF74", "#00FFC6", "#FFE502", "#620E00",
                "#008F9C", "#98FF52", "#7544B1", "#B500FF", "#00FF78",
                "#FF6E41", "#005F39", "#6B6882", "#5FAD4E", "#A75740",
                "#A5FFD2", "#FFB167", "#009BFF", "#E85EBE"
            };

        public static ConcurrentDictionary<int, Label> parking;
        public static bool programRunning = true;
        List<Car> cars;
        List<Thread> carThreads;
        int howManyGarages;
        int howManyCars;
        Thread carManager;
        int timeInGarage;
        int timeInQueue;

        public void UpdateParkingLabel(int id, string txt, Color c)
        {
            var tmp = (Label)parking[id];
            tmp.Text = txt;
            tmp.BackColor = c;
        }
        public void UpdateQueueLabel(int id, string txt, Color c)
        {
            var tmp = (Label)queue.Controls[id];
            tmp.Text = txt;
            tmp.BackColor = c;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void InvokeUI(Action a)
        {
            this.Invoke(new MethodInvoker(a));
        }

        public void Init(int howManyGarages = 2, int howManyThreads = 5)
        {
            this.howManyGarages = howManyGarages;
            this.howManyCars = howManyThreads;
            parking = new ConcurrentDictionary<int, Label>(howManyGarages, howManyGarages);
            cars = new List<Car>();
            carThreads = new List<Thread>();

            garages.Controls.Clear();
            queue.Controls.Clear();

            garages.ColumnCount = howManyGarages;
            queue.RowCount = howManyThreads;

            foreach (RowStyle style in garages.RowStyles)
                style.SizeType = SizeType.AutoSize;
            foreach (RowStyle style in queue.RowStyles)
                style.SizeType = SizeType.AutoSize;

            for (int i = 0; i < howManyGarages; i++)
            {
                garages.Controls.Add(MakeLabel(i, "Empty"), 0, i);
                parking[i] = (Label)garages.Controls[i];
            }

            for (int i = 0; i < howManyThreads; i++)
                queue.Controls.Add(MakeLabel(i, "Empty"), 0, i);

            //RunThreads();
            carManager = new Thread(ManageCars);
            carManager.Start();
        }

        //private void RunThreads()
        //{
        //    carManager = new Thread(ManageCars);
        //    carManager.Start();
        //}

        private Label MakeLabel(int i, string txt)
        {
            var label = new Label();
            label.Text = txt;
            label.BorderStyle = BorderStyle.Fixed3D;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = txt.Equals("Empty") ? Color.White : ColorTranslator.FromHtml(Form1.colors[i]);
            return label;
        }

        private void ManageCars()
        {
            Random r = new Random();

            //Utwórz auta i ich wątki
            for (int j = 0; j < howManyCars; j++)
            {
                int randomSleep = (r.Next() % 3000) + 3000; //Wątki będą miały sleepTime z zakresu <3, 6> sekund
                Color c = ColorTranslator.FromHtml(Form1.colors[j]);
                int g = timeInGarage + (r.Next() % 3000); //czas w garażu
                int q = timeInQueue + (r.Next() % 3000); //czas w kolejce
                cars.Add(new Car(j, c, g, q));
                carThreads.Add(new Thread(cars[j].Run));
            }

            //Wypełnij kolejkę w GUI
            foreach (var car in cars)
                InvokeUI(() => { UpdateQueueLabel(car.CarId, "T " + car.CarId, car.CarColor); });

            //Wyczyść parking
            foreach (var item in parking)
            {
                InvokeUI(() =>
                {
                    var tmp = item.Value;
                    tmp.Text = "Empty";
                    tmp.BackColor = Color.White;
                });
            }

            //Wystartuj wątki
            foreach (var car in carThreads)
                car.Start();

            //Zarządzaj autami
            int i = 0;
            while (Form1.programRunning)
            {
                if (cars[i].Parked)
                {
                    if (Form1.parking[cars[i].ParkedId].Text.Equals("Empty"))
                    {
                        InvokeUI(() => { UpdateParkingLabel(cars[i].ParkedId, "T " + cars[i].CarId, cars[i].CarColor); });

                        InvokeUI(() => { UpdateQueueLabel(cars[i].CarId, "Empty", Color.White); });

                    }
                }
                else
                {
                    if(parking[cars[i].ParkedId].Text.Equals("T " + cars[i].CarId))
                        InvokeUI(() => { UpdateParkingLabel(cars[i].ParkedId, "Empty", Color.White); });
                    InvokeUI(() => { UpdateQueueLabel(cars[i].CarId, "T " + cars[i].CarId, cars[i].CarColor); });
                }

                if (i == howManyCars - 1)
                    i = 0;
                else
                    i++;
                Thread.Sleep(10);
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            int garageAmount;
            int carAmount;
            
            if( !int.TryParse(textBoxGarageNumber.Text, out garageAmount) || 
                !int.TryParse(textBoxCarAmount.Text, out carAmount) ||
                !int.TryParse(textBoxTimeInGarage.Text, out timeInGarage) ||
                !int.TryParse(textBoxTimeInQueue.Text, out timeInQueue))
            {
                labelError.Text = "Bad input";
                return;
            }
            buttonRun.Enabled = false;
            Form1.programRunning = true;
            Init(garageAmount, carAmount);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Form1.programRunning = false;
            for (int i = 0; i < carThreads.Count; i++)
            {
                //try
                //{
                //    carThreads[i].Abort();
                //}
                //catch (Exception)
                //{
                //    Console.WriteLine($"Car {cars[i].CarId} aborted.");
                //}
                carThreads[i].Join();
            }
            carManager.Join();
            buttonRun.Enabled = true;
        }
    }
}
