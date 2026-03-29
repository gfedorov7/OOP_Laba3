using Laba5.service;
using Laba5.src;

namespace Laba5
{
    public partial class Form1 : Form
    {
        /// <summary>Начальная высота окна.</summary>
        private const int START_WINDOW_HEIGHT = 451;

        /// <summary>Начальная ширина окна.</summary>
        private const int START_WINDOW_WIDTH = 526;

        /// <summary>Основная высота окна.</summary>
        private const int MAIN_WINDOW_HEIGHT = 723;

        /// <summary>Основная ширина окна.</summary>
        private const int MAIN_WINDOW_WIDTH = 628;
        
        private readonly IHousingDepartmentMediator _mediator;

        public Form1()
        {
            InitializeComponent();
            _mediator = new HousingDepartmentMediator(this);

        Size = new Size(START_WINDOW_WIDTH, START_WINDOW_HEIGHT);
        MaximumSize = new Size(START_WINDOW_WIDTH, START_WINDOW_HEIGHT);
        MinimumSize = new Size(START_WINDOW_WIDTH, START_WINDOW_HEIGHT);

            panel2.Visible = false;
            tableLayoutPanel2.Visible = false;
        }

        private void comboBox_fields_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mediator.ShowField(comboBox_fields.SelectedIndex);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            int fieldIndex = comboBox_fields.SelectedIndex;
            decimal numericValue = 0;
            string textValue = "";
            string residentNames = textBox_residentName.Text;
            string residentHouses = textBox_residentHouseNum.Text;

            if (fieldIndex == 0) textValue = textBox_district.Text;
            else if (fieldIndex == 1) numericValue = numericUpDown_housingDepartmentNumber.Value;
            else if (fieldIndex == 3) numericValue = numericUpDown_paidResidentsCount.Value;
            else if (fieldIndex == 4) numericValue = numericUpDown_tariff.Value;
            else if (fieldIndex == 5) numericValue = numericUpDown_balance.Value;
            else if (fieldIndex == 6) numericValue = numericUpDown_employeeCount.Value;

            _mediator.SaveField(fieldIndex, textValue, numericValue, residentNames, residentHouses);
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            _mediator.ToggleInfo();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            tableLayoutPanel2.Visible = true;
            Size = new Size(MAIN_WINDOW_WIDTH, MAIN_WINDOW_HEIGHT);
            MaximumSize = new Size(MAIN_WINDOW_WIDTH, MAIN_WINDOW_HEIGHT);
            MinimumSize = new Size(MAIN_WINDOW_WIDTH, MAIN_WINDOW_HEIGHT);
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            tableLayoutPanel2.Visible = false;
            Size = new Size(START_WINDOW_WIDTH, START_WINDOW_HEIGHT);
            MaximumSize = new Size(START_WINDOW_WIDTH, START_WINDOW_HEIGHT);
            MinimumSize = new Size(START_WINDOW_WIDTH, START_WINDOW_HEIGHT);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}