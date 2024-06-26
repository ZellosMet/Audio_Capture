﻿namespace WindowsFormsApp1
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.b_Start = new System.Windows.Forms.Button();
			this.b_Stop = new System.Windows.Forms.Button();
			this.cht_Wave = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.t_Refresh_Wave = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.cht_Wave)).BeginInit();
			this.SuspendLayout();
			// 
			// b_Start
			// 
			this.b_Start.Location = new System.Drawing.Point(13, 12);
			this.b_Start.Name = "b_Start";
			this.b_Start.Size = new System.Drawing.Size(75, 23);
			this.b_Start.TabIndex = 1;
			this.b_Start.Text = "Start";
			this.b_Start.UseVisualStyleBackColor = true;
			this.b_Start.Click += new System.EventHandler(this.b_Start_Click);
			// 
			// b_Stop
			// 
			this.b_Stop.Location = new System.Drawing.Point(713, 12);
			this.b_Stop.Name = "b_Stop";
			this.b_Stop.Size = new System.Drawing.Size(75, 23);
			this.b_Stop.TabIndex = 2;
			this.b_Stop.Text = "Stop";
			this.b_Stop.UseVisualStyleBackColor = true;
			this.b_Stop.Click += new System.EventHandler(this.b_Stop_Click);
			// 
			// cht_Wave
			// 
			this.cht_Wave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "ChartArea1";
			this.cht_Wave.ChartAreas.Add(chartArea1);
			this.cht_Wave.Location = new System.Drawing.Point(12, 41);
			this.cht_Wave.Name = "cht_Wave";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series1.Name = "Series1";
			this.cht_Wave.Series.Add(series1);
			this.cht_Wave.Size = new System.Drawing.Size(775, 376);
			this.cht_Wave.TabIndex = 3;
			this.cht_Wave.Text = "chart1";
			// 
			// t_Refresh_Wave
			// 
			this.t_Refresh_Wave.Interval = 20;
			this.t_Refresh_Wave.Tick += new System.EventHandler(this.t_Refresh_Wave_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 429);
			this.Controls.Add(this.cht_Wave);
			this.Controls.Add(this.b_Stop);
			this.Controls.Add(this.b_Start);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.cht_Wave)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button b_Start;
		private System.Windows.Forms.Button b_Stop;
		private System.Windows.Forms.DataVisualization.Charting.Chart cht_Wave;
		private System.Windows.Forms.Timer t_Refresh_Wave;
	}
}

