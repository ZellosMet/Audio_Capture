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
		WasapiLoopbackCapture capture;
		WaveIn wi;
		short[] data;
		bool check = false;

		private BufferedWaveProvider buffer;
		private WaveOut waveOut;
		private WaveIn sourceStream = null;

		private bool listen = false;

		public Form1()
		{
			InitializeComponent();
			MMDeviceEnumerator mde = new MMDeviceEnumerator();
			MMDeviceCollection devices = mde.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
			cb_devices.Items.AddRange(devices.ToArray());

			//capture = new WasapiLoopbackCapture();
			//capture.DataAvailable += Capture_DataAvailable;
			//wi.DataAvailable += InputBufferToFileCallback;

			//listen = !listen;
			//if (listen)
			//	listenBtn.Text = "Stop listening";
			//else
			//{
			//	listenBtn.Text = "Listen";
			//	sourceStream.StopRecording();
			//	return;
			//}

			sourceStream = new WaveIn();
			sourceStream.WaveFormat = new WaveFormat(44100, 16, 1);

			waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback());

			sourceStream.DataAvailable += new EventHandler<WaveInEventArgs>(sourceStream_DataAvailable);
			//sourceStream.RecordingStopped += SourceStream_RecordingStopped; //new EventHandler<StoppedEventArgs>(sourceStream_RecordingStopped);

			buffer = new BufferedWaveProvider(sourceStream.WaveFormat);
			buffer.DiscardOnBufferOverflow = true;
			waveOut.DesiredLatency = 51;
			waveOut.Volume = 1f;
			waveOut.Init(buffer);
			
		}

		//private void SourceStream_RecordingStopped(object sender, StoppedEventArgs e)
		//{
		//	throw new NotImplementedException();
		//}

		//private void Capture_DataAvailable(object sender, WaveInEventArgs e)
		private void sourceStream_DataAvailable(object sender, WaveInEventArgs e)
		{
			data = new short[e.BytesRecorded];
			for (int i = 0, j = 0; i < e.BytesRecorded - 1; i += 2, j++)
				data[j] = (short)(e.Buffer[i] <<8 | (e.Buffer[i+1]));
			check = true;
		}
		private void sourceStream_RecordingStopped(object sender, WaveInEventArgs e)
		{
			sourceStream.Dispose();
			waveOut.Dispose();
		}

		//private void wie_DataAvailable(object sender, WaveEventArgs e)
		//{
		//	for (int i = 0, j = 0; i < e.Buffer.Length-1; i += 2, j++)
		//		data[j] = (short)(e.Buffer[i] << 8 | (e.Buffer[i + 1]));
		//}

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
			sourceStream.StartRecording();
			//capture.StartRecording();
			//wie.StartRecording();
			t_Refresh_Wave.Enabled = true;
		}

		private void b_Stop_Click(object sender, EventArgs e)
		{
			sourceStream.Dispose();
			waveOut.Dispose();
			//capture.StopRecording();
			//capture.Dispose();
			//wie.StopRecording();
			//wie.Dispose();
			t_Refresh_Wave.Enabled = false;
			check = false;
			cht_Wave.Series[0].Points.Clear();
		}

		private void cb_devices_SelectedIndexChanged(object sender, EventArgs e)
		{
			//wie = new NAudio.Wave.WaveOutEvent()
			//{
			//	DeviceNumber = cb_devices.SelectedIndex,
			//	WaveFormat = new NAudio.Wave.WaveFormat(44100, 16, 1),
			//	BufferMilliseconds = 20
			//};
			//wie.
			//wie.DataAvailable += wie_DataAvailable;
		}
	}
}
