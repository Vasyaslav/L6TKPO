using MVCLibrary;

namespace MVCWFA
{
    public partial class Form1 : Form
    {
        private ElevatorModel eModel;
        private ElevatorController eController;
        private ElevatorView1 eV1;
        private ElevatorView2 eV2;
        private ElevatorView3 eV3;
        //private ElevatorView3 eV3;
        public Form1()
        {
            InitializeComponent();

            this.eModel = new ElevatorModel();
            this.eController = new ElevatorController(eModel);
            this.eV1 = new ElevatorView1(panelView1, eModel);
            this.eV2 = new ElevatorView2(panelView2, eModel);
            this.eV3 = new ElevatorView3(panelView3, eModel);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            eController.ChangePowerShortageChance((int)numericUpDown2.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eController.MakeMove((int)numericUpDown1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            eController.LoadHuman();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            eController.UnloadHuman();
        }
    }

    public class ElevatorView1 : Observer
    {
        public ElevatorModel eM;
        public RichTextBox ElevatorTextBox;

        public ElevatorView1(Panel panel, ElevatorModel eModel)
        {
            eM = eModel;
            eM.AddObserver(this);
            ElevatorTextBox = new RichTextBox();
            ElevatorTextBox.Location = new Point(1, 1);
            ElevatorTextBox.Width = panel.Width - 2;
            ElevatorTextBox.Height = panel.Height - 2;
            panel.Controls.Add(ElevatorTextBox);
        }

        public override void Update(string newData)
        {
            ElevatorTextBox.Text = ElevatorTextBox.Text + '\n' + newData;
        }
    }
    public class ElevatorView2 : Observer
    {
        public ElevatorModel eM;
        public Label floorLabel;
        public TextBox floorTextBox;
        public Label massLabel;
        public TextBox massTextBox;
        public Label powerShortageLabel1;
        public Label powerShortageLabel2;
        public TextBox powerShortageTextBox;
        public Label stateLabel;
        public RichTextBox stateRichTextBox;

        public ElevatorView2(Panel panel, ElevatorModel eModel)
        {

            eM = eModel;
            eM.AddObserver(this);
            int controlsWidth = panel.Width - 2;
            int controlsHeight = 20;
            int heightStep = controlsHeight + 4;
            floorLabel = new Label();
            floorLabel.Text = "Текущий этаж";
            floorLabel.Width = controlsWidth;
            floorLabel.Height = controlsHeight;
            floorLabel.Location = new Point(1, 1);
            floorTextBox = new TextBox();
            floorTextBox.ReadOnly = true;
            floorTextBox.Width = controlsWidth;
            floorTextBox.Height = controlsHeight;
            floorTextBox.Location = new Point(1, 1 + heightStep - 4);
            panel.Controls.Add(floorLabel);
            panel.Controls.Add(floorTextBox);

            massLabel = new Label();
            massLabel.Text = "Текущая масса";
            massLabel.Width = controlsWidth;
            massLabel.Height = controlsHeight;
            massLabel.Location = new Point(1, 1 + heightStep * 2);
            massTextBox = new TextBox();
            massTextBox.ReadOnly = true;
            massTextBox.Width = controlsWidth;
            massTextBox.Height = controlsHeight;
            massTextBox.Location = new Point(1, 1 + heightStep * 3 - 4);
            panel.Controls.Add(massLabel);
            panel.Controls.Add(massTextBox);

            powerShortageLabel1 = new Label();
            powerShortageLabel1.Text = "Текущая вероятность отключения";
            powerShortageLabel1.Width = controlsWidth;
            powerShortageLabel1.Height = controlsHeight;
            powerShortageLabel1.Location = new Point(1, 1 + heightStep * 4);
            powerShortageLabel2 = new Label();
            powerShortageLabel2.Text = "электроэнергии";
            powerShortageLabel2.Width = controlsWidth;
            powerShortageLabel2.Height = controlsHeight;
            powerShortageLabel2.Location = new Point(1, 1 + heightStep * 5 - 4);
            powerShortageTextBox = new TextBox();
            powerShortageTextBox.ReadOnly = true;
            powerShortageTextBox.Width = controlsWidth;
            powerShortageTextBox.Height = controlsHeight;
            powerShortageTextBox.Location = new Point(1, 1 + heightStep * 6 - 4);
            panel.Controls.Add(powerShortageLabel1);
            panel.Controls.Add(powerShortageLabel2);
            panel.Controls.Add(powerShortageTextBox);

            stateLabel = new Label();
            stateLabel.Text = "Текущее состояние";
            stateLabel.Width = controlsWidth;
            stateLabel.Height = controlsHeight;
            stateLabel.Location = new Point(1, 1 + heightStep * 7);
            stateRichTextBox = new RichTextBox();
            stateRichTextBox.ReadOnly = true;
            stateRichTextBox.Width = controlsWidth;
            stateRichTextBox.Height = controlsHeight * 3;
            stateRichTextBox.Location = new Point(1, 1 + heightStep * 8 - 4);
            panel.Controls.Add(stateLabel);
            panel.Controls.Add(stateRichTextBox);
        }

        public override void Update(string newData)
        {
            List<string> dataStrings = newData.Split('\n').ToList();
            floorTextBox.Text = dataStrings[0].Split(' ').Last();
            massTextBox.Text = dataStrings[1].Split(' ').Last();
            powerShortageTextBox.Text = dataStrings[2].Split(' ').Last();
            stateRichTextBox.Text = "";
            List<string> stateStrings = dataStrings[3].Split(' ').ToList();
            stateStrings.RemoveRange(0, 2);
            foreach (string str in stateStrings)
            {
                stateRichTextBox.Text += str + " ";
            }
        }
    }

    public class ElevatorView3 : Observer
    {
        public ElevatorModel eM;
        private Panel panel;
        private Random random;
        public Label floorLabel;
        public Label massLabel;
        public Label powerShortageLabel1;
        public Label powerShortageLabel2;
        public RichTextBox stateRichTextBox;

        public ElevatorView3(Panel panel, ElevatorModel eModel)
        {
            eM = eModel;
            eM.AddObserver(this);
            this.panel = panel;
            this.random = new Random();

            floorLabel = new Label();
            floorLabel.AutoSize = true;
            floorLabel.Location = GetValidLocation(floorLabel);
            panel.Controls.Add(floorLabel);

            massLabel = new Label();
            massLabel.AutoSize = true;
            massLabel.Location = GetValidLocation(massLabel);
            panel.Controls.Add(massLabel);

            powerShortageLabel1 = new Label();
            powerShortageLabel1.AutoSize = true;
            powerShortageLabel1.Location = GetValidLocation(powerShortageLabel1);
            panel.Controls.Add(powerShortageLabel1);

            powerShortageLabel2 = new Label();
            powerShortageLabel2.AutoSize = true;
            powerShortageLabel2.Location = new Point(powerShortageLabel1.Location.X, powerShortageLabel1.Location.Y + 20);
            panel.Controls.Add(powerShortageLabel2);

            stateRichTextBox = new RichTextBox();
            stateRichTextBox.ReadOnly = true;
            stateRichTextBox.Width = panel.Width - 2;
            stateRichTextBox.Height = 80;
            stateRichTextBox.Location = GetValidLocation(stateRichTextBox);
            panel.Controls.Add(stateRichTextBox);
        }
        public override void Update(string newData)
        {
            floorLabel.Text = "Текущий этаж = ";
            floorLabel.Location = GetValidLocation(floorLabel);
            massLabel.Text = "Текущая масса = ";
            massLabel.Location = GetValidLocation(massLabel);
            powerShortageLabel1.Text = "Текущая вероятность отключения";
            powerShortageLabel1.Location = GetValidLocation(powerShortageLabel1);
            powerShortageLabel2.Text = "электроэнергии: ";
            powerShortageLabel2.Location = new Point(powerShortageLabel1.Location.X, powerShortageLabel1.Location.Y + 20);
            stateRichTextBox.Text = "Текущее состояние: ";
            stateRichTextBox.Location = GetValidLocation(stateRichTextBox);
            List<string> dataStrings = newData.Split('\n').ToList();
            floorLabel.Text += dataStrings[0].Split(' ').Last();
            massLabel.Text += dataStrings[1].Split(' ').Last();
            powerShortageLabel2.Text += dataStrings[2].Split(' ').Last();
            List<string> stateStrings = dataStrings[3].Split(' ').ToList();
            stateStrings.RemoveRange(0, 2);
            foreach (string str in stateStrings)
            {
                stateRichTextBox.Text += str + " ";
            }
        }
        private Point GetValidLocation(Control control)
        {
            Point location = new Point();
            location.X = random.Next(panel.Width - control.Width - 2) + 1;
            location.Y = random.Next(panel.Height - control.Height - 2) + 1;
            return location;
        }
    }

    public class ElevatorController
    {
        public ElevatorModel eM { get; private set; }
        public ElevatorController(ElevatorModel eModel)
        {
            eM = eModel;
        }

        public void LoadHuman()
        {
            if (eM.state.name == "В движении" || eM.state.name == "Нет питания")
            {
                GetInfo("Лифт не может загружать пассажиров в движении или выключенном состоянии");
            }
            else
            {
                eM.Load();
                //MessageBox.Show("1");
                GetInfo();
            }
        }

        public void UnloadHuman()
        {
            if (eM.mass == 0)
            {
                GetInfo("В лифте нет пассажиров");
            }
            else if (eM.state.name == "В движении" || eM.state.name == "Нет питания")
            {
                GetInfo("Лифт может выгружать пассажиров в движении или выключенном состоянии");
                return;
            } else
            {
                eM.Unload();
                GetInfo();
            }
        }

        public void ChangePowerShortageChance(int chance)
        {
            eM.ChangePower(chance);
            GetInfo();
            MessageBox.Show(eM.powerShortageChance.ToString());
        }

        public void MakeMove(int nFloor)
        {
            eM.ChangeNextFloor(nFloor);
            eM.NotifyUpdate(eM.Move());
        }
        public void GetInfo()
        {
            eM.NotifyUpdate(eM.Info());
        }
        public void GetInfo(string str)
        {
            eM.NotifyUpdate(eM.Info(str));
        }
    }
}
