using NAudio.CoreAudioApi;
using NAudio.Midi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		WaveInEvent wie;
		short[] data;

		public Form1()
		{
			InitializeComponent();
			MMDeviceEnumerator mde = new MMDeviceEnumerator();
			MMDeviceCollection devices = mde.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
			cb_devices.Items.AddRange(devices.ToArray());
			data = new short[44100 * 20 / 1000];
			wie = new NAudio.Wave.WaveInEvent()
			{
				DeviceNumber = cb_devices.SelectedIndex,
				WaveFormat = new NAudio.Wave.WaveFormat(44100, 16, 1),
				BufferMilliseconds = 20
			};
			wie.DataAvailable += wie_DataAvailable;
		}

		private void wie_DataAvailable(object sender, WaveInEventArgs e)
		{
			for (int i = 0, j = 0; i < e.Buffer.Length-1; i += 2, j++)
				data[j] = (short)(e.Buffer[i] << 8 | (e.Buffer[i + 1]));
		}

		private void t_Refresh_Wave_Tick(object sender, EventArgs e)
		{
			int x = 0;
			cht_Wave.Series[0].Points.Clear();
			while (x <= data.Length - 1)
			{				
				cht_Wave.Series[0].Points.AddXY(x + 1, data[x]);				
				x++;
			}
		}

		private void b_Start_Click(object sender, EventArgs e)
		{
			wie.StartRecording();
			t_Refresh_Wave.Enabled = true;
		}

		private void b_Stop_Click(object sender, EventArgs e)
		{
			wie.StopRecording();
			wie.Dispose();
			cht_Wave.Series[0].Points.Clear();
		}
	}
}
