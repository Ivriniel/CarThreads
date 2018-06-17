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
        public static Form1 Instance { get; private set; } = null;
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

        List<Car> cars = new List<Car>();
        public List<Thread> carThreads = new List<Thread>();

        int howManyGarages;
        int howManyCars;
        int timeInGarage;

        public bool programRunning;

        public Form1()
        {
            InitializeComponent();
            if (Form1.Instance == null)
                Form1.Instance = this;
        }

        public void InvokeUI(Action a)
        {
            this.Invoke(new MethodInvoker(a));
        }

        public void Init(int howManyGarages = 2, int howManyThreads = 5)
        {
            this.howManyGarages = howManyGarages;
            this.howManyCars = howManyThreads;

            garages.Controls.Clear();
            queue.Controls.Clear();

            garages.ColumnCount = howManyGarages;
            queue.RowCount = howManyThreads;

            foreach (RowStyle style in garages.RowStyles)
                style.SizeType = SizeType.AutoSize;
            foreach (RowStyle style in queue.RowStyles)
                style.SizeType = SizeType.AutoSize;

            for (int i = 0; i < howManyGarages; i++)
                garages.Controls.Add(MakeLabel(i, "Empty"), 0, i);

            for (int i = 0; i < howManyThreads; i++)
                queue.Controls.Add(MakeLabel(i, "Empty"), 0, i);

            Random rand = new Random();
            for (int i = 0; i < howManyThreads; i++)
            {
                Car c = new Car(i, i, timeInGarage + rand.Next() % 3000);
                var label = (Label)Form1.Instance.queue.Controls[i];
                label.Text = "Car " + c.CarId;
                label.BackColor = ColorTranslator.FromHtml(Form1.colors[c.CarId]);
                cars.Add(c);
                carThreads.Add(new Thread(c.Run));
            }

            foreach (var carThread in carThreads)
            {
                carThread.Start();
            }
        }

        private Label MakeLabel(int i, string txt)
        {
            var label = new Label();
            label.Text = txt;
            label.BorderStyle = BorderStyle.Fixed3D;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = txt.Equals("Empty") ? Color.White : ColorTranslator.FromHtml(Form1.colors[i]);
            return label;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            int garageAmount;
            int carAmount;
            
            if( !int.TryParse(textBoxGarageNumber.Text, out garageAmount) || 
                !int.TryParse(textBoxCarAmount.Text, out carAmount) ||
                !int.TryParse(textBoxTimeInGarage.Text, out timeInGarage))
            {
                labelError.Text = "Bad input";
                return;
            }
            buttonRun.Enabled = false;
            programRunning = true;
            Init(garageAmount, carAmount);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            programRunning = false;
            for (int i = 0; i < carThreads.Count; i++)
            {
                carThreads[i].Join();
            }
            buttonRun.Enabled = true;
        }
    }
}
