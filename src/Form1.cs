using Maze;
using System.ComponentModel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //init design
            InitializeComponent();

            //map array & output
            jag = new string[0][];
            simulationStep = new List<Tuple<int, int>>();
            solutionStep = new List<Tuple<int, int>>();

            //thread
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            tick = 1000/(int)(1 + trackBar1.Value * 0.1f);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                label7.Text = "-";
                label9.Text = "-";
                if(backgroundWorker1.IsBusy){
                    backgroundWorker1.CancelAsync();
                    label11.Text = "Canceled";
                }

                jag = new string[0][];
                simulationStep.Clear();

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                // this.mapGridView.Columns.Add("","");
                // this.mapGridView.Rows.Add();
                Utils ut = new Utils();
                jag = ut.ReadFile(textBox1.Text);
                if (!ut.isLineHaveEqualElement(jag)) {
                    label2.Text = "All lines have to have the same number of elements";
                } else if (!ut.isSymbolValid(jag)) {
                    label2.Text = "File symbols can only be X, R, K, and T";
                } else {
                    label2.Text = "File is valid.";
                    MatrixElement[][] mainMatrix = ut.InitMatrix(jag);
                    // the rest of the BFS, DFS code
                    for (int i = 0; i < jag[0].Length; i++) {
                        dataGridView1.Columns.Add("","");
                    }
                    for (int i = 0; i < jag.Length; i++) {
                        dataGridView1.Rows.Add("","");
                    }
                    dataGridView1.SelectedCells[0].Selected = false;

                    drawMap();

                    AdjustRowHeight(dataGridView1);
                }
            } catch (DirectoryNotFoundException exc){
                label2.Text = "Please enter a file name at '../test'";
                if(backgroundWorker1.IsBusy){
                    backgroundWorker1.CancelAsync();
                    label11.Text = "Canceled";
                }

                jag = new string[0][];
                simulationStep.Clear();
            } catch (FileNotFoundException exc){
                label2.Text = "File was not found in '../test'";

                if(backgroundWorker1.IsBusy){
                    backgroundWorker1.CancelAsync();
                    label11.Text = "Canceled";
                }

                jag = new string[0][];
                simulationStep.Clear();
                solutionStep.Clear();
            }
        }

        private void drawMap(){
            for (int row = 0; row < jag.Length; row++){
                for(int column = 0; column < jag[row].Length; column++){
                    if(jag[row][column] == "K"){
                        dataGridView1.Rows[row].Cells[column].Style.BackColor = Color.White;
                        dataGridView1.Rows[row].Cells[column].Value = "Start";
                    } else if(jag[row][column] == "R"){
                        dataGridView1.Rows[row].Cells[column].Style.BackColor = Color.White;
                    } else if(jag[row][column] == "T"){
                        dataGridView1.Rows[row].Cells[column].Style.BackColor = Color.White;
                        dataGridView1.Rows[row].Cells[column].Value = "Treasure";
                    } else if(jag[row][column] == "X"){
                        dataGridView1.Rows[row].Cells[column].Style.BackColor = Color.Black;
                    }
                    //dataGridView1.Rows[row].Cells[column].Style.BackColor = Color.Red;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(jag.Length > 0){
                simulateOrSearch = true;
                label12.Text = "Searching..";
                simulationStep.Clear();
                solutionStep.Clear();
                drawMap();
                if(!backgroundWorker1.IsBusy){
                    backgroundWorker1.RunWorkerAsync();
                } else {
                    backgroundWorker1.CancelAsync();
                }
                label12.Text = "Done!";
            } else {
                label12.Text = "Map not loaded";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{
                drawMap();
                if(!backgroundWorker1.IsBusy){
                    if(simulationStep.Count > 0){
                        simulateOrSearch = false;
                        backgroundWorker1.RunWorkerAsync();
                    } else {
                        label11.Text = "Please search solution first";
                        if(jag.Length < 1){
                            label11.Text = "Please load a map";
                        }
                    }
                } else {
                    backgroundWorker1.CancelAsync();
                }
            } catch(ArgumentOutOfRangeException exc){
                label11.Text = "Please load a map";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //design purpose
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
            originalTextBox1Size = new Rectangle(textBox1.Location.X, textBox1.Location.Y, textBox1.Size.Width, textBox1.Size.Height);
            originalButton1Size = new Rectangle(button1.Location.X, button1.Location.Y, button1.Size.Width, button1.Size.Height);
            originalButton3Size = new Rectangle(button3.Location.X, button3.Location.Y, button3.Size.Width, button3.Size.Height);
            originalLabel2Size = new Rectangle(label2.Location.X, label2.Location.Y, label2.Size.Width, label2.Size.Height);
            originalLabel11Size = new Rectangle(label11.Location.X, label11.Location.Y, label11.Size.Width, label11.Size.Height);
            originalTrackBarSize = new Rectangle(trackBar1.Location.X, trackBar1.Location.Y, trackBar1.Size.Width, trackBar1.Size.Height);  
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            moveOnResize(textBox1, originalTextBox1Size, false, true);
            moveOnResize(button1, originalButton1Size, false, true);
            moveOnResize(label2, originalLabel2Size, false, true);
            moveOnResize(button3, originalButton3Size, false, true);
            moveOnResize(label11, originalLabel11Size, false, true);
            moveOnResize(trackBar1, originalTrackBarSize, false, true);

            AdjustRowHeight(dataGridView1);
        }

        private void moveOnResize(Control control, Rectangle rectangle, bool movePositionX, bool movePositionY)
        {
            int dX = this.Width - originalFormSize.Width;
            int dY = this.Height - originalFormSize.Height;

            if (movePositionX)
            {
                control.Location = new Point(rectangle.Location.X + dX, rectangle.Location.Y);
            }

            if (movePositionY)
            {
                control.Location = new Point(rectangle.Location.X, rectangle.Location.Y + dY);
            }
        }

        private void AdjustRowHeight(DataGridView dataGridView)
        {   
            int rowHeight = 0;
            if(dataGridView.RowCount != 0){
                rowHeight = dataGridView.Size.Height / dataGridView.RowCount;   
            }
            if (rowHeight > 0)
            {
                for(int i = 0; i < dataGridView.RowCount; i++){
                    dataGridView.Rows[i].Height = rowHeight;
                }
            }
        }

        private void searchDFS(){
            int krustyKrabX = 0;
            int krustyKrabY = 0;
            for (int i=0; i < jag.Length; i++) {
                for (int j=0; j < jag[i].Length; j++) {
                    if (jag[i][j] == "K") {
                        krustyKrabX = i;
                        krustyKrabY = j;
                        break;
                    }
                }
            }
            Utils ut = new Utils();
            MatrixElement[][] mainMatrix = ut.InitMatrix(jag);
            DFS a = new DFS();
            Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> bfsList; 
            if(checkBox1.Checked){
                bfsList = a.findDFSTSP(mainMatrix, jag, krustyKrabX, krustyKrabY);
            } else {
                bfsList = a.findDFS(mainMatrix, jag, krustyKrabX, krustyKrabY);
            }

            for(int i = 0; i < bfsList.Item1.Count; i++){
                simulationStep.Add(new Tuple<int, int>(bfsList.Item1[i].Item1,bfsList.Item1[i].Item2));
            }

            solutionStep = bfsList.Item2;
        }

        private void searchBFS(){
            int krustyKrabX = 0;
            int krustyKrabY = 0;
            for (int i=0; i < jag.Length; i++) {
                for (int j=0; j < jag[i].Length; j++) {
                    if (jag[i][j] == "K") {
                        krustyKrabX = i;
                        krustyKrabY = j;
                        break;
                    }
                }
            }
            Utils ut = new Utils();
            MatrixElement[][] mainMatrix = ut.InitMatrix(jag);
            BFS a = new BFS();
            Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> bfsList; 
            if(checkBox1.Checked){
                bfsList = a.findBFSTSP(mainMatrix, jag, krustyKrabX, krustyKrabY);
            } else {
                bfsList = a.findBFS(mainMatrix, jag, krustyKrabX, krustyKrabY);
            }

            for(int i = 0; i < bfsList.Item1.Count; i++){
                simulationStep.Add(new Tuple<int, int>(bfsList.Item1[i].Item1,bfsList.Item1[i].Item2));
            }

            solutionStep = bfsList.Item2;
        }

        private void sSolution(List<Tuple<int, int>> steps, Color highlight){
            for(int i = 0; i < steps.Count; i++){
                dataGridView1.Rows[steps[i].Item1].Cells[steps[i].Item2].Style.BackColor = highlight;
            }
        }

        private void simulate(List<Tuple<int, int>> steps, Color tail, Color head){
            label11.Text = "loading...";

            DataGridViewCell previousCell = dataGridView1.Rows[steps[0].Item1].Cells[steps[0].Item2];

            for(int i = 0; i < steps.Count; i++){
                if(backgroundWorker1.CancellationPending){
                    label11.Text = "Canceled";
                    return;
                }
                previousCell.Style.BackColor = tail;
                dataGridView1.Rows[steps[i].Item1].Cells[steps[i].Item2].Style.BackColor = head;
                wait(tick);
                previousCell = dataGridView1.Rows[steps[i].Item1].Cells[steps[i].Item2];

            }

            label11.Text = "Done!";
        }

        private void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled  = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                if(backgroundWorker1.CancellationPending){
                    timer1.Enabled = false;
                    timer1.Stop();
                }
                Application.DoEvents();
            }
        }

        private string translateSteps(List<Tuple<int, int>> steps){
            string result = "";
            Tuple<int, int> previousPoint = steps[0];

            if(steps.Count > 1){
                for(int i = 1; i < steps.Count; i++){
                    if(previousPoint.Item1 - steps[i].Item1 == 1){
                        result += "U";
                    } else if(previousPoint.Item1 - steps[i].Item1 == -1){
                        result += "D";
                    } else if(previousPoint.Item2 - steps[i].Item2 == 1){
                        result += "L";
                    } else if(previousPoint.Item2 - steps[i].Item2 == -1){
                        result += "R";
                    }

                    if(previousPoint != steps[i] && i != steps.Count - 1){
                        result += " -> ";
                    }

                    previousPoint = steps[i];
                }
            }


            return result;
        }

        private void backgroundWorker1_DoWork ( object sender, DoWorkEventArgs e )
        {
            if(!simulateOrSearch){
                label11.Text = "Simulating...";
                simulate(simulationStep, Color.Yellow, Color.Green);
                simulate(solutionStep, Color.Blue, Color.Green);
                sSolution(solutionStep, Color.Green);

            } else {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                // the code that you want to measure comes here
                if(radioButton1.Checked){
                    searchBFS();
                } else {
                    searchDFS();
                }
                watch.Stop();
                var elapsedMs = watch.ElapsedTicks;
                label10.Text = elapsedMs.ToString() + " ticks";
                if(solutionStep.Count > 0){
                    sSolution(solutionStep, Color.Green);
                    label7.Text = simulationStep.Count.ToString();
                    label9.Text = solutionStep.Count.ToString();
                    textBox2.Text = translateSteps(solutionStep);
                } else {
                    label12.Text = "Search interrupted, possible error may occur";
                }
            }
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private string[][] jag;
        private List<Tuple<int, int>> simulationStep;
        private List<Tuple<int, int>> solutionStep;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private bool simulateOrSearch;
        private int tick = 1000;
    }
}