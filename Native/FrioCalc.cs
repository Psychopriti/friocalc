using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FrioCalcNative
{
    internal sealed class Capacity
    {
        public decimal Largo;
        public decimal Ancho;
        public decimal Alto;
        public decimal Volumen;
        public string EnfriamientoHP;
        public int EnfriamientoBTU;
        public string CongelacionHP;
        public int CongelacionBTU;
    }

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var splash = new SplashForm())
            {
                splash.Show();
                Application.DoEvents();
                Thread.Sleep(3000);
                splash.Close();
            }
            Application.Run(new MainForm());
        }
    }

    internal sealed class SplashForm : Form
    {
        public SplashForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(720, 420);
            BackColor = Color.FromArgb(242, 247, 249);
            ShowInTaskbar = false;

            var card = new Panel();
            card.Location = new Point(42, 42);
            card.Size = new Size(636, 336);
            card.BackColor = Color.White;
            Controls.Add(card);

            var marenco = new PictureBox();
            marenco.Image = LoadImage("marenco-trading-logo.png");
            marenco.SizeMode = PictureBoxSizeMode.Zoom;
            marenco.Location = new Point(68, 42);
            marenco.Size = new Size(500, 92);
            card.Controls.Add(marenco);

            var frio = new PictureBox();
            frio.Image = LoadImage(Path.Combine("Native", "Assets", "friocalc-logo.png"));
            frio.SizeMode = PictureBoxSizeMode.Zoom;
            frio.Location = new Point(68, 144);
            frio.Size = new Size(500, 124);
            card.Controls.Add(frio);

            var made = new Label();
            made.Text = "made by JM";
            made.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            made.ForeColor = Color.FromArgb(237, 28, 36);
            made.TextAlign = ContentAlignment.MiddleCenter;
            made.Location = new Point(0, 282);
            made.Size = new Size(636, 34);
            card.Controls.Add(made);
        }

        private static Image LoadImage(string relativePath)
        {
            Image embedded = AssetLoader.Load(relativePath);
            if (embedded != null)
            {
                return embedded;
            }

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            return File.Exists(path) ? Image.FromFile(path) : null;
        }
    }

    internal sealed class MainForm : Form
    {
        private const decimal StockLength = 12m;

        private readonly Capacity[] table = new Capacity[]
        {
            Row(1.83m,1.83m,2.4m,8.037m,"3/4",6500,"1.5",6500),
            Row(1.83m,2.4m,2.4m,10.541m,"1",9000,"1.5",6500),
            Row(1.83m,3m,2.4m,13.176m,"1",9000,"2",9000),
            Row(2.4m,2.4m,2.4m,13.824m,"1",9000,"2",9000),
            Row(2.4m,3m,2.4m,17.28m,"1",10400,"2",9000),
            Row(2.4m,3.65m,2.4m,21.024m,"1.5",13000,"2",9000),
            Row(3m,3m,3m,27m,"1.5",13000,"3",12000),
            Row(2.4m,4.26m,3m,30.672m,"1.5",13000,"3",12000),
            Row(3m,3.65m,3m,32.85m,"1.5",14000,"3",12000),
            Row(2.4m,4.87m,3m,35.064m,"2",13000,"3",12000),
            Row(3m,4.26m,3m,38.34m,"2",15600,"3",12000),
            Row(2.4m,5.48m,3m,39.456m,"2",14000,"3",12000),
            Row(3.65m,3.65m,3m,39.968m,"2",15600,"3",12000),
            Row(2.4m,6m,3m,43.2m,"2",15600,"4",18000),
            Row(3m,4.87m,3m,43.83m,"2",15600,"4",18000),
            Row(3.65m,4.26m,3m,46.647m,"2",15600,"4",14000),
            Row(2.4m,6.7m,3m,48.24m,"2",18000,"4",18000),
            Row(3m,5.48m,3m,49.32m,"2",18000,"4",18000),
            Row(2.4m,7.31m,3m,52.632m,"2",18000,"4",18000),
            Row(3.65m,4.87m,3m,53.327m,"2",18000,"4",14000),
            Row(3m,6m,3m,54m,"3",26000,"4",18000),
            Row(4.26m,4.26m,3m,54.443m,"2",20800,"5",16000),
            Row(2.4m,7.92m,3m,57.024m,"3",20800,"5",24000),
            Row(3.65m,5.48m,3m,60.006m,"3",26000,"5",16000),
            Row(2.4m,8.53m,3m,61.416m,"3",20800,"5",18000),
            Row(4.26m,4.87m,3m,62.239m,"3",26000,"5",16000),
            Row(3.65m,6m,3m,65.7m,"3",26000,"5",16000),
            Row(3m,7.31m,3m,65.79m,"3",26000,"4",18000),
            Row(2.4m,9.14m,3m,65.808m,"3",26000,"6",24000),
            Row(2.4m,9.75m,3m,70.2m,"3",26000,"6",24000),
            Row(4.87m,4.87m,3m,71.151m,"3",26000,"5",16000),
            Row(3.65m,6.7m,3m,73.365m,"3",26000,"6",24000),
            Row(4.26m,6m,3m,76.68m,"3",26000,"6",18000),
            Row(3m,8.53m,3m,76.77m,"3",26000,"6",24000),
            Row(4.87m,6m,3m,87.66m,"3",26000,"6",20000),
            Row(5.48m,5.48m,3m,90.091m,"3",26000,"6",20000),
            Row(4.26m,7.31m,3m,93.422m,"3",26000,"6",24000),
            Row(5.48m,6m,3m,98.64m,"3",26000,"6",24000),
            Row(4.87m,7.31m,3m,106.799m,"3",26000,"7.5",28000),
            Row(6m,6m,3m,108m,"4",31200,"7.5",28000),
            Row(5.48m,7.31m,3m,120.176m,"4",31200,"7.5",28000),
            Row(6m,7.31m,3m,131.58m,"4",37000,"7.5",24000),
            Row(6m,8.53m,3m,153.54m,"4",36000,"10",36000),
            Row(6m,9.75m,3m,175.5m,"5",41600,"10",40000),
            Row(6m,10.97m,3m,197.46m,"5",52000,"12",48000),
            Row(6m,12.19m,3m,219.42m,"6",52000,"12",48000),
            Row(12.19m,7.31m,3m,267.327m,"6",52000,"15",56000),
            Row(12.19m,8.53m,3m,311.942m,"8",74000,"15",62000),
            Row(12.19m,9.75m,3m,356.558m,"8",74000,"15",62000),
            Row(12.19m,10.97m,3m,401.173m,"8",74000,"20",78000),
            Row(12.19m,12.19m,3m,445.788m,"10",74000,"20",78000)
        };

        private TextBox largoBox;
        private TextBox anchoBox;
        private TextBox altoBox;
        private TextBox volumenBox;
        private Button medidasButton;
        private Button volumenButton;
        private Button enfriamientoButton;
        private Button congelacionButton;
        private Panel dimensionesPanel;
        private Panel volumenPanel;
        private Label volumenLabel;
        private Label hpLabel;
        private Label btuLabel;
        private Label refLabel;
        private Label noteLabel;
        private Label panelTotalLabel;
        private Label wallCutsLabel;
        private Label roofLabel;
        private FlowLayoutPanel panelCards;
        private RoomPreview preview;
        private bool usarMedidas = true;
        private bool usarEnfriamiento = true;

        private static Capacity Row(decimal largo, decimal ancho, decimal alto, decimal volumen, string enfHp, int enfBtu, string congHp, int congBtu)
        {
            return new Capacity
            {
                Largo = largo,
                Ancho = ancho,
                Alto = alto,
                Volumen = volumen,
                EnfriamientoHP = enfHp,
                EnfriamientoBTU = enfBtu,
                CongelacionHP = congHp,
                CongelacionBTU = congBtu
            };
        }

        public MainForm()
        {
            Text = "FRIOCALC";
            MinimumSize = new Size(1080, 820);
            Size = new Size(1220, 940);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(242, 247, 249);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Native", "Assets", "friocalc.ico");
            if (File.Exists(iconPath))
            {
                Icon = new Icon(iconPath);
            }
            BuildUi();
            UpdateResult(null, EventArgs.Empty);
        }

        private void BuildUi()
        {
            var root = new TableLayoutPanel();
            root.Dock = DockStyle.Fill;
            root.Padding = new Padding(30);
            root.ColumnCount = 1;
            root.RowCount = 3;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 104));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 246));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.BackColor = BackColor;
            Controls.Add(root);

            var header = new Panel();
            header.Dock = DockStyle.Fill;
            header.BackColor = BackColor;
            root.Controls.Add(header, 0, 0);

            var logo = new PictureBox();
            logo.Image = LoadImage(Path.Combine("Native", "Assets", "friocalc-logo.png"));
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.Location = new Point(0, 2);
            logo.Size = new Size(440, 84);
            header.Controls.Add(logo);

            var subtitle = new Label();
            subtitle.Text = "Calculadora de seleccion para cuarto frio";
            subtitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            subtitle.ForeColor = Color.FromArgb(237, 28, 36);
            subtitle.Location = new Point(4, 82);
            subtitle.AutoSize = true;
            header.Controls.Add(subtitle);

            var maker = new Label();
            maker.Text = "made by JM";
            maker.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            maker.ForeColor = Color.FromArgb(127, 127, 127);
            maker.TextAlign = ContentAlignment.MiddleRight;
            maker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maker.Location = new Point(914, 34);
            maker.Size = new Size(170, 28);
            header.Controls.Add(maker);

            var inputCard = CardPanel();
            inputCard.Padding = new Padding(28);
            root.Controls.Add(inputCard, 0, 1);

            medidasButton = SelectorButton("Ingresar medidas", 28, 26, 220);
            medidasButton.Click += delegate { usarMedidas = true; UpdateMode(); };
            inputCard.Controls.Add(medidasButton);

            volumenButton = SelectorButton("Ingresar volumen", 258, 26, 220);
            volumenButton.Click += delegate { usarMedidas = false; UpdateMode(); };
            inputCard.Controls.Add(volumenButton);

            enfriamientoButton = SelectorButton("Enfriamiento", 520, 26, 190);
            enfriamientoButton.Click += delegate { usarEnfriamiento = true; UpdateUsage(); };
            inputCard.Controls.Add(enfriamientoButton);

            congelacionButton = SelectorButton("Congelacion", 720, 26, 190);
            congelacionButton.Click += delegate { usarEnfriamiento = false; UpdateUsage(); };
            inputCard.Controls.Add(congelacionButton);

            dimensionesPanel = new Panel();
            dimensionesPanel.Location = new Point(28, 112);
            dimensionesPanel.Size = new Size(900, 118);
            dimensionesPanel.BackColor = Color.White;
            inputCard.Controls.Add(dimensionesPanel);

            largoBox = Input(dimensionesPanel, "Largo", "3", 0, 8);
            anchoBox = Input(dimensionesPanel, "Ancho", "4", 245, 8);
            altoBox = Input(dimensionesPanel, "Altura", "3", 490, 8);

            volumenPanel = new Panel();
            volumenPanel.Location = new Point(28, 112);
            volumenPanel.Size = new Size(900, 118);
            volumenPanel.BackColor = Color.White;
            inputCard.Controls.Add(volumenPanel);

            volumenBox = Input(volumenPanel, "Volumen del cuarto", "36", 0, 8);
            volumenBox.Width = 260;

            var resultCard = CardPanel();
            resultCard.Padding = new Padding(30);
            resultCard.AutoScroll = true;
            root.Controls.Add(resultCard, 0, 2);

            var resultTitle = new Label();
            resultTitle.Text = "Resultado recomendado";
            resultTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            resultTitle.ForeColor = Color.FromArgb(39, 49, 58);
            resultTitle.Location = new Point(30, 18);
            resultTitle.Size = new Size(420, 42);
            resultCard.Controls.Add(resultTitle);

            var resultSub = new Label();
            resultSub.Text = "Se redondea hacia arriba al siguiente volumen disponible.";
            resultSub.ForeColor = Color.FromArgb(102, 112, 133);
            resultSub.Location = new Point(34, 58);
            resultSub.Size = new Size(520, 26);
            resultCard.Controls.Add(resultSub);

            AddMetricTitle(resultCard, "Volumen", 34, 102);
            AddMetricTitle(resultCard, "Condensador", 270, 102);
            AddMetricTitle(resultCard, "Evaporador", 506, 102);

            volumenLabel = BigLabel(resultCard, "36 m3", 34, 130, 24);
            hpLabel = BigLabel(resultCard, "2 HP", 270, 130, 24);
            btuLabel = BigLabel(resultCard, "15,600 BTU", 506, 130, 24);

            refLabel = new Label();
            refLabel.Location = new Point(36, 202);
            refLabel.Size = new Size(520, 34);
            refLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            refLabel.ForeColor = Color.FromArgb(39, 49, 58);
            resultCard.Controls.Add(refLabel);

            noteLabel = new Label();
            noteLabel.Location = new Point(36, 236);
            noteLabel.Size = new Size(520, 46);
            noteLabel.ForeColor = Color.FromArgb(102, 112, 133);
            noteLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            resultCard.Controls.Add(noteLabel);

            var divider = new Panel();
            divider.Location = new Point(34, 298);
            divider.Size = new Size(1080, 1);
            divider.BackColor = Color.FromArgb(226, 235, 239);
            resultCard.Controls.Add(divider);

            var panelTitle = new Label();
            panelTitle.Text = "Calculadora de paneles";
            panelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            panelTitle.ForeColor = Color.FromArgb(39, 49, 58);
            panelTitle.Location = new Point(34, 318);
            panelTitle.Size = new Size(360, 42);
            resultCard.Controls.Add(panelTitle);

            AddMetricTitle(resultCard, "Total a comprar", 36, 376);
            panelTotalLabel = BigLabel(resultCard, "0 paneles", 34, 404, 28);
            panelTotalLabel.Size = new Size(250, 64);

            wallCutsLabel = SummaryBox(resultCard, "Paredes", 316, 376, 360);
            roofLabel = SummaryBox(resultCard, "Techo recomendado", 704, 376, 360);

            preview = new RoomPreview();
            preview.Location = new Point(34, 492);
            preview.Size = new Size(520, 220);
            resultCard.Controls.Add(preview);

            panelCards = new FlowLayoutPanel();
            panelCards.Location = new Point(584, 492);
            panelCards.Size = new Size(530, 220);
            panelCards.FlowDirection = FlowDirection.TopDown;
            panelCards.WrapContents = false;
            panelCards.AutoScroll = true;
            panelCards.BackColor = Color.White;
            resultCard.Controls.Add(panelCards);

            UpdateMode();
            UpdateUsage();
        }

        private Panel CardPanel()
        {
            var panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.Margin = new Padding(8);
            panel.BackColor = Color.White;
            return panel;
        }

        private Button SelectorButton(string text, int x, int y, int width)
        {
            var button = new Button();
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(width, 58);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button.Cursor = Cursors.Hand;
            return button;
        }

        private void StyleSelector(Button button, bool active)
        {
            button.BackColor = active ? Color.FromArgb(237, 28, 36) : Color.FromArgb(233, 242, 245);
            button.ForeColor = active ? Color.White : Color.FromArgb(39, 49, 58);
            button.FlatAppearance.BorderColor = active ? Color.FromArgb(237, 28, 36) : Color.FromArgb(202, 218, 224);
        }

        private TextBox Input(Control parent, string label, string value, int x, int y)
        {
            var text = new Label();
            text.Text = label;
            text.Location = new Point(x, y);
            text.Size = new Size(220, 26);
            text.ForeColor = Color.FromArgb(127, 127, 127);
            text.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            parent.Controls.Add(text);

            var box = new TextBox();
            box.Text = value;
            box.Location = new Point(x, y + 28);
            box.Size = new Size(205, 46);
            box.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            box.BorderStyle = BorderStyle.FixedSingle;
            box.TextChanged += UpdateResult;
            parent.Controls.Add(box);
            return box;
        }

        private void AddMetricTitle(Control parent, string text, int x, int y)
        {
            var label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.Size = new Size(230, 24);
            label.ForeColor = Color.FromArgb(127, 127, 127);
            label.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            parent.Controls.Add(label);
        }

        private Label BigLabel(Control parent, string text, int x, int y, int size)
        {
            var label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.Size = new Size(230, 62);
            label.Font = new Font("Segoe UI", size, FontStyle.Bold, GraphicsUnit.Point);
            label.ForeColor = Color.FromArgb(39, 49, 58);
            parent.Controls.Add(label);
            return label;
        }

        private Label SummaryBox(Control parent, string title, int x, int y, int width)
        {
            var label = new Label();
            label.Text = title;
            label.Location = new Point(x, y);
            label.Size = new Size(width, 92);
            label.Padding = new Padding(14, 10, 14, 10);
            label.BackColor = Color.FromArgb(242, 247, 249);
            label.ForeColor = Color.FromArgb(39, 49, 58);
            label.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            parent.Controls.Add(label);
            return label;
        }

        private void UpdateMode()
        {
            dimensionesPanel.Visible = usarMedidas;
            volumenPanel.Visible = !usarMedidas;
            StyleSelector(medidasButton, usarMedidas);
            StyleSelector(volumenButton, !usarMedidas);
            UpdateResult(null, EventArgs.Empty);
        }

        private void UpdateUsage()
        {
            StyleSelector(enfriamientoButton, usarEnfriamiento);
            StyleSelector(congelacionButton, !usarEnfriamiento);
            UpdateResult(null, EventArgs.Empty);
        }

        private void UpdateResult(object sender, EventArgs e)
        {
            if (volumenLabel == null)
            {
                return;
            }

            decimal volume = GetVolume();
            Capacity selection = table[table.Length - 1];

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].Volumen >= volume)
                {
                    selection = table[i];
                    break;
                }
            }

            string hp = usarEnfriamiento ? selection.EnfriamientoHP : selection.CongelacionHP;
            int btu = usarEnfriamiento ? selection.EnfriamientoBTU : selection.CongelacionBTU;

            volumenLabel.Text = FormatDecimal(volume) + " m3";
            hpLabel.Text = hp + " HP";
            btuLabel.Text = btu.ToString("N0", CultureInfo.InvariantCulture) + " BTU";
            refLabel.Text = FormatDecimal(selection.Largo) + " x " + FormatDecimal(selection.Ancho) + " x " + FormatDecimal(selection.Alto) + " m";
            noteLabel.Text = volume > table[table.Length - 1].Volumen
                ? "El volumen supera la tabla original. Se muestra la capacidad mayor disponible."
                : "Cubre hasta " + FormatDecimal(selection.Volumen) + " m3. La seleccion redondea hacia arriba.";

            UpdatePanelCalculator();
        }

        private decimal GetVolume()
        {
            if (!usarMedidas)
            {
                return ReadDecimal(volumenBox.Text);
            }

            return ReadDecimal(largoBox.Text) * ReadDecimal(anchoBox.Text) * ReadDecimal(altoBox.Text);
        }

        private decimal ReadDecimal(string value)
        {
            decimal result;
            value = (value ?? string.Empty).Replace(',', '.');
            if (decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out result) && result > 0)
            {
                return result;
            }

            return 0m;
        }

        private string FormatDecimal(decimal value)
        {
            return value.ToString("0.##", CultureInfo.InvariantCulture);
        }

        private int RoundUpUnits(decimal value)
        {
            return (int)Math.Ceiling(value);
        }

        private decimal RoundUpTenths(decimal value)
        {
            return Math.Ceiling(value * 10m) / 10m;
        }

        private void UpdatePanelCalculator()
        {
            if (panelTotalLabel == null)
            {
                return;
            }

            panelCards.Controls.Clear();

            if (!usarMedidas)
            {
                panelTotalLabel.Text = "--";
                wallCutsLabel.Text = "Para calcular paneles usa largo, ancho y altura.";
                roofLabel.Text = "";
                preview.SetRoom(0, 0, 0, 0, 0, "Sin medidas");
                return;
            }

            decimal largo = ReadDecimal(largoBox.Text);
            decimal ancho = ReadDecimal(anchoBox.Text);
            decimal alto = ReadDecimal(altoBox.Text);
            if (largo <= 0 || ancho <= 0 || alto <= 0)
            {
                panelTotalLabel.Text = "0 paneles";
                wallCutsLabel.Text = "Ingresa medidas validas.";
                roofLabel.Text = "";
                preview.SetRoom(0, 0, 0, 0, 0, "Sin medidas");
                return;
            }

            int cortesLargo = RoundUpUnits(largo);
            int cortesAncho = RoundUpUnits(ancho);
            int wallCuts = (cortesLargo * 2) + (cortesAncho * 2);

            PanelPlan anchoPlan = BuildPlan(alto, wallCuts, RoundUpTenths(ancho), cortesLargo, "Techo a lo ancho");
            PanelPlan largoPlan = BuildPlan(alto, wallCuts, RoundUpTenths(largo), cortesAncho, "Techo a lo largo");
            PanelPlan chosen = BetterPlan(anchoPlan, largoPlan);

            panelTotalLabel.Text = chosen.Panels.Count.ToString(CultureInfo.InvariantCulture) + " paneles";
            wallCutsLabel.Text = "Paredes\n"
                + wallCuts.ToString(CultureInfo.InvariantCulture) + " cortes de " + FormatDecimal(alto) + " m\n"
                + "Largo: " + cortesLargo.ToString(CultureInfo.InvariantCulture) + " por lado | Ancho: " + cortesAncho.ToString(CultureInfo.InvariantCulture) + " por lado\n"
                + FormatDecimal(chosen.WallLinear) + " m en " + chosen.WallPanelCount.ToString(CultureInfo.InvariantCulture) + " paneles";
            roofLabel.Text = "Techo recomendado\n"
                + chosen.Orientation + "\n"
                + chosen.RoofCuts.ToString(CultureInfo.InvariantCulture) + " cortes de "
                + FormatDecimal(chosen.RoofCutLength) + " m en " + chosen.RoofPanels.ToString(CultureInfo.InvariantCulture)
                + " panel(es) | Sobra " + FormatDecimal(chosen.TotalWaste) + " m";

            for (int i = 0; i < chosen.Panels.Count; i++)
            {
                StockPanel panel = chosen.Panels[i];
                panelCards.Controls.Add(BuildPanelCard(i + 1, panel));
            }

            preview.SetRoom(largo, ancho, alto, cortesLargo, cortesAncho, chosen.Orientation);
        }

        private PanelPlan BetterPlan(PanelPlan a, PanelPlan b)
        {
            if (a.Panels.Count != b.Panels.Count)
            {
                return a.Panels.Count < b.Panels.Count ? a : b;
            }

            if (a.TotalWaste != b.TotalWaste)
            {
                return a.TotalWaste < b.TotalWaste ? a : b;
            }

            if (a.RoofPanels != b.RoofPanels)
            {
                return a.RoofPanels < b.RoofPanels ? a : b;
            }

            if (a.RoofCuts != b.RoofCuts)
            {
                return a.RoofCuts < b.RoofCuts ? a : b;
            }

            if (a.RoofCutLength != b.RoofCutLength)
            {
                return a.RoofCutLength < b.RoofCutLength ? a : b;
            }

            return a;
        }

        private PanelPlan BuildPlan(decimal wallCutLength, int wallCuts, decimal roofCutLength, int roofCuts, string orientation)
        {
            var roofCutList = new List<Cut>();
            for (int i = 0; i < roofCuts; i++)
            {
                roofCutList.Add(new Cut(roofCutLength, "techo"));
            }

            var roofPanels = PackCuts(roofCutList, "Techo");
            decimal wallLinear = wallCuts * wallCutLength;
            int wallPanelCount = (int)Math.Ceiling(wallLinear / StockLength);
            var wallPanels = new List<StockPanel>();
            for (int i = 0; i < wallPanelCount; i++)
            {
                decimal used = i == wallPanelCount - 1 ? wallLinear - (StockLength * i) : StockLength;
                wallPanels.Add(MakePanel(new Cut(used, "paredes"), "Paredes"));
            }

            var panels = new List<StockPanel>();
            panels.AddRange(roofPanels);
            panels.AddRange(wallPanels);

            var plan = new PanelPlan();
            plan.Panels = panels;
            plan.Orientation = orientation;
            plan.RoofCutLength = roofCutLength;
            plan.RoofCuts = roofCuts;
            plan.RoofPanels = roofPanels.Count;
            plan.WallLinear = wallLinear;
            plan.WallPanelCount = wallPanelCount;
            plan.TotalWaste = (panels.Count * StockLength) - TotalUsed(panels);
            return plan;
        }

        private List<StockPanel> PackCuts(List<Cut> cuts, string section)
        {
            cuts.Sort(delegate(Cut x, Cut y)
            {
                return y.Length.CompareTo(x.Length);
            });

            var panels = new List<StockPanel>();
            for (int i = 0; i < cuts.Count; i++)
            {
                Cut cut = cuts[i];
                StockPanel best = null;
                decimal bestRemaining = StockLength + 1m;
                for (int j = 0; j < panels.Count; j++)
                {
                    decimal remaining = StockLength - panels[j].Used;
                    if (remaining >= cut.Length && remaining < bestRemaining)
                    {
                        best = panels[j];
                        bestRemaining = remaining;
                    }
                }

                if (best == null)
                {
                    best = new StockPanel();
                    best.Section = section;
                    panels.Add(best);
                }
                best.Cuts.Add(cut);
            }

            return panels;
        }

        private StockPanel MakePanel(Cut cut, string section)
        {
            var panel = new StockPanel();
            panel.Section = section;
            panel.Cuts.Add(cut);
            return panel;
        }

        private decimal TotalUsed(List<StockPanel> panels)
        {
            decimal used = 0m;
            for (int i = 0; i < panels.Count; i++)
            {
                used += panels[i].Used;
            }
            return used;
        }

        private string DescribeCuts(List<Cut> cuts)
        {
            var counts = new Dictionary<string, int>();
            for (int i = 0; i < cuts.Count; i++)
            {
                string key = FormatDecimal(cuts[i].Length) + " m";
                if (!counts.ContainsKey(key))
                {
                    counts[key] = 0;
                }
                counts[key]++;
            }

            var parts = new List<string>();
            foreach (var kv in counts)
            {
                parts.Add(kv.Value.ToString(CultureInfo.InvariantCulture) + " x " + kv.Key);
            }
            return string.Join(", ", parts.ToArray());
        }

        private Panel BuildPanelCard(int number, StockPanel panel)
        {
            decimal waste = StockLength - panel.Used;
            int usedWidth = (int)Math.Round((double)(panel.Used / StockLength * 156m));
            if (usedWidth < 0)
            {
                usedWidth = 0;
            }
            if (usedWidth > 156)
            {
                usedWidth = 156;
            }

            var card = new Panel();
            card.Size = new Size(500, 62);
            card.Margin = new Padding(0, 0, 0, 10);
            card.BackColor = Color.FromArgb(242, 247, 249);

            var title = new Label();
            title.Text = "Panel " + number.ToString(CultureInfo.InvariantCulture) + " - " + panel.Section;
            title.Location = new Point(12, 8);
            title.Size = new Size(112, 22);
            title.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            title.ForeColor = Color.FromArgb(237, 28, 36);
            card.Controls.Add(title);

            var cuts = new Label();
            cuts.Text = DescribeCuts(panel.Cuts);
            cuts.Location = new Point(132, 8);
            cuts.Size = new Size(170, 44);
            cuts.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cuts.ForeColor = Color.FromArgb(39, 49, 58);
            card.Controls.Add(cuts);

            var usedText = new Label();
            usedText.Text = "Usado " + FormatDecimal(panel.Used) + "m";
            usedText.Location = new Point(318, 8);
            usedText.Size = new Size(86, 20);
            usedText.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            usedText.ForeColor = Color.FromArgb(39, 49, 58);
            card.Controls.Add(usedText);

            var wasteText = new Label();
            wasteText.Text = "Sobra " + FormatDecimal(waste) + "m";
            wasteText.Location = new Point(408, 8);
            wasteText.Size = new Size(82, 20);
            wasteText.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            wasteText.ForeColor = waste == 0 ? Color.FromArgb(25, 140, 100) : Color.FromArgb(127, 127, 127);
            card.Controls.Add(wasteText);

            var barBack = new Panel();
            barBack.Location = new Point(318, 36);
            barBack.Size = new Size(156, 10);
            barBack.BackColor = Color.FromArgb(214, 226, 231);
            card.Controls.Add(barBack);

            var barUsed = new Panel();
            barUsed.Location = new Point(318, 36);
            barUsed.Size = new Size(usedWidth, 10);
            barUsed.BackColor = Color.FromArgb(237, 28, 36);
            card.Controls.Add(barUsed);

            return card;
        }

        private static Image LoadImage(string relativePath)
        {
            Image embedded = AssetLoader.Load(relativePath);
            if (embedded != null)
            {
                return embedded;
            }

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            return File.Exists(path) ? Image.FromFile(path) : null;
        }
    }

    internal static class AssetLoader
    {
        public static Image Load(string relativePath)
        {
            string name = null;
            if (relativePath.EndsWith("marenco-trading-logo.png", StringComparison.OrdinalIgnoreCase))
            {
                name = "FrioCalcNative.marenco_logo";
            }
            else if (relativePath.EndsWith("friocalc-logo.png", StringComparison.OrdinalIgnoreCase))
            {
                name = "FrioCalcNative.friocalc_logo";
            }

            if (name == null)
            {
                return null;
            }

            var stream = typeof(AssetLoader).Assembly.GetManifestResourceStream(name);
            if (stream == null)
            {
                return null;
            }

            using (stream)
            using (var image = Image.FromStream(stream))
            {
                return new Bitmap(image);
            }
        }
    }

    internal sealed class Cut
    {
        public decimal Length;
        public string Kind;

        public Cut(decimal length, string kind)
        {
            Length = length;
            Kind = kind;
        }
    }

    internal sealed class StockPanel
    {
        public List<Cut> Cuts = new List<Cut>();
        public string Section = "";

        public decimal Used
        {
            get
            {
                decimal used = 0m;
                for (int i = 0; i < Cuts.Count; i++)
                {
                    used += Cuts[i].Length;
                }
                return used;
            }
        }
    }

    internal sealed class PanelPlan
    {
        public List<StockPanel> Panels;
        public string Orientation;
        public decimal RoofCutLength;
        public int RoofCuts;
        public int RoofPanels;
        public decimal WallLinear;
        public int WallPanelCount;
        public decimal TotalWaste;
    }

    internal sealed class RoomPreview : Panel
    {
        private decimal largo;
        private decimal ancho;
        private decimal alto;
        private int largoPanels;
        private int anchoPanels;
        private string orientation = "";

        public RoomPreview()
        {
            DoubleBuffered = true;
            BackColor = Color.FromArgb(242, 247, 249);
        }

        public void SetRoom(decimal largoValue, decimal anchoValue, decimal altoValue, int largoCount, int anchoCount, string roofOrientation)
        {
            largo = largoValue;
            ancho = anchoValue;
            alto = altoValue;
            largoPanels = largoCount;
            anchoPanels = anchoCount;
            orientation = roofOrientation;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(BackColor);

            if (largo <= 0 || ancho <= 0 || alto <= 0)
            {
                DrawCentered(g, "Vista de paneles", ClientRectangle, Color.FromArgb(127, 127, 127));
                return;
            }

            Point topA = new Point(100, 28);
            Point topB = new Point(300, 28);
            Point topC = new Point(370, 76);
            Point topD = new Point(170, 76);
            Point botA = new Point(100, 108);
            Point botB = new Point(300, 108);
            Point botC = new Point(370, 136);
            Point botD = new Point(170, 136);

            var roofBrush = new SolidBrush(Color.FromArgb(218, 247, 255));
            var wallBrush = new SolidBrush(Color.FromArgb(245, 249, 251));
            var sideBrush = new SolidBrush(Color.FromArgb(224, 235, 239));
            var redPen = new Pen(Color.FromArgb(237, 28, 36), 2);
            var greyPen = new Pen(Color.FromArgb(127, 127, 127), 1);
            var bluePen = new Pen(Color.FromArgb(7, 150, 200), 1);

            g.FillPolygon(wallBrush, new Point[] { topA, topB, botB, botA });
            g.FillPolygon(sideBrush, new Point[] { topB, topC, botC, botB });
            g.FillPolygon(roofBrush, new Point[] { topA, topB, topC, topD });

            DrawDivisions(g, topA, topB, botA, botB, largoPanels, bluePen);
            DrawDivisions(g, topB, topC, botB, botC, anchoPanels, bluePen);
            DrawDivisions(g, topA, topD, topB, topC, orientation.IndexOf("ancho") >= 0 ? largoPanels : anchoPanels, redPen);

            g.DrawPolygon(redPen, new Point[] { topA, topB, topC, topD });
            g.DrawPolygon(greyPen, new Point[] { topA, topB, botB, botA });
            g.DrawPolygon(greyPen, new Point[] { topB, topC, botC, botB });

            string text = "L " + FormatPreview(largo) + "m  A " + FormatPreview(ancho) + "m  H " + FormatPreview(alto) + "m";
            g.DrawString(text, new Font("Segoe UI", 9F, FontStyle.Bold), new SolidBrush(Color.FromArgb(39, 49, 58)), new PointF(10, 8));
        }

        private void DrawDivisions(Graphics g, Point a1, Point a2, Point b1, Point b2, int count, Pen pen)
        {
            if (count <= 1)
            {
                return;
            }

            for (int i = 1; i < count; i++)
            {
                float t = (float)i / (float)count;
                Point p1 = Lerp(a1, a2, t);
                Point p2 = Lerp(b1, b2, t);
                g.DrawLine(pen, p1, p2);
            }
        }

        private Point Lerp(Point a, Point b, float t)
        {
            return new Point((int)(a.X + ((b.X - a.X) * t)), (int)(a.Y + ((b.Y - a.Y) * t)));
        }

        private void DrawCentered(Graphics g, string text, Rectangle rect, Color color)
        {
            using (var brush = new SolidBrush(color))
            using (var fmt = new StringFormat())
            {
                fmt.Alignment = StringAlignment.Center;
                fmt.LineAlignment = StringAlignment.Center;
                g.DrawString(text, new Font("Segoe UI", 10F, FontStyle.Bold), brush, rect, fmt);
            }
        }

        private string FormatPreview(decimal value)
        {
            return value.ToString("0.##", CultureInfo.InvariantCulture);
        }
    }
}
