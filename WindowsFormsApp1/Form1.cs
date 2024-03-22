using NAudio.CoreAudioApi;
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

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		short[] data;
		bool check = false;
		private WaveIn sourceStream = null;

		public Form1()
		{
			InitializeComponent();

			sourceStream = new WaveIn();
			sourceStream.WaveFormat = new WaveFormat(44100, 16, 1);

			sourceStream.DataAvailable += SourceStream_DataAvailable;
			sourceStream.RecordingStopped += SourceStream_RecordingStopped;			
		}

		private void SourceStream_RecordingStopped(object sender, StoppedEventArgs e)
		{
			sourceStream.StopRecording();
			sourceStream.Dispose();
		}

		private void SourceStream_DataAvailable(object sender, WaveInEventArgs e)
		{
			data = new short[e.Buffer.Length/ 4];
			for (int i = 0, j = 0; i < e.Buffer.Length / 2-1; i += 2, j++)
				data[j] = (short)(e.Buffer[i] << 8 | (e.Buffer[i + 1]));
			check = true;
		}

		private void t_Refresh_Wave_Tick(object sender, EventArgs e)
		{
			if (!check) return;
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
			sourceStream = new WaveIn();
			sourceStream.WaveFormat = new WaveFormat(44100, 16, 1);
			sourceStream.DataAvailable += SourceStream_DataAvailable;
			sourceStream.RecordingStopped += SourceStream_RecordingStopped;
			sourceStream.StartRecording();

			t_Refresh_Wave.Enabled = true;
		}

		private void b_Stop_Click(object sender, EventArgs e)
		{
			sourceStream.Dispose();
			t_Refresh_Wave.Enabled = false;
			check = false;
			cht_Wave.Series[0].Points.Clear();
		}
	}
}
