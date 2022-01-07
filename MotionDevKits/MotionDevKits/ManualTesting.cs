using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotionConnector;
using MotionKits;


namespace MotionKits
{
    public partial class ManualTesting : Form
    {
        private ModbusTCPConnector con = new ModbusTCPConnector();

        private List<Label> labels = new List<Label>();
        private List<NumericUpDown> nums = new List<NumericUpDown>();

        public ManualTesting()
        {
            InitializeComponent();
            labels.Add(label_p1);
            labels.Add(label_p2);
            labels.Add(label_p3);
            labels.Add(label_p4);
            nums.Add(num_p1);
            nums.Add(num_p2);
            nums.Add(num_p3);
            nums.Add(num_p4);
        }

        private void ManualTesting_Load(object sender, EventArgs e)
        {
            combo_routine.DataSource = con.RoutineNames;
            if (combo_routine.DataSource != null)
                combo_routine.SelectedIndex = con.FindRoutineIndexInList(con.GetControl().Routine);

            combo_infofilter.DataSource = con.RegisterGroups;
            if (combo_infofilter.DataSource != null)
                combo_infofilter.SelectedIndex = 0;

            dataGridHist.DataSource = con.GetControl().History;

            cfgAddressLable.Text = con.ConnectorAddress;

            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            start_btn.Enabled = !con.Busy;
            stop_btn.Enabled = con.Busy;
            reset_btn.Enabled = false;
        }

        private void combo_routine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Routine rt = con.GetRoutine((string)combo_routine.SelectedItem);

            for (int i = 0; i < 4; i++)
            {
                labels[i].Visible = false;
                nums[i].Visible=false;
            }

            if (!(rt.Parameter is null))
            {
                for (int i = 0; i < rt.Parameter.Count; i++)
                {
                    labels[i].Visible = true;
                    labels[i].Text = rt.Parameter[i].Name;

                    nums[i].Visible = true;
                    nums[i].Value = (decimal)rt.Parameter[i].DefaultValue;
                }
            }
        }

        private void combo_infofilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            registerGridView.DataSource = con.GetRegisters((string)combo_infofilter.SelectedItem);
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            Routine rt = con.GetRoutine((string)combo_routine.SelectedItem);

            float p1 = (float)Convert.ToDouble(nums[0].Value);
            float p2 = (float)Convert.ToDouble(nums[1].Value);
            float p3 = (float)Convert.ToDouble(nums[2].Value);
            float p4 = (float)Convert.ToDouble(nums[3].Value);

            con.RunRoutine((ushort)rt.Index, new List<float> { p1, p2, p3, p4 });
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {

        }

        
    }
}
