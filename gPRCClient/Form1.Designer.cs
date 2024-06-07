namespace gPRCClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_start = new Button();
            listBox = new ListBox();
            button_trigger = new Button();
            button_setServerAddr = new Button();
            textBox_serverIP = new TextBox();
            label_signal = new Label();
            SuspendLayout();
            // 
            // button_start
            // 
            button_start.Location = new Point(36, 124);
            button_start.Name = "button_start";
            button_start.Size = new Size(160, 26);
            button_start.TabIndex = 0;
            button_start.Text = "ContinousDataDisplay";
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += button_start_Click;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 17;
            listBox.Location = new Point(223, 76);
            listBox.Name = "listBox";
            listBox.Size = new Size(195, 276);
            listBox.TabIndex = 1;
            // 
            // button_trigger
            // 
            button_trigger.Location = new Point(36, 425);
            button_trigger.Name = "button_trigger";
            button_trigger.Size = new Size(160, 26);
            button_trigger.TabIndex = 0;
            button_trigger.Text = "TriggerOnce";
            button_trigger.UseVisualStyleBackColor = true;
            button_trigger.Click += button_trigger_Click;
            // 
            // button_setServerAddr
            // 
            button_setServerAddr.Location = new Point(36, 18);
            button_setServerAddr.Name = "button_setServerAddr";
            button_setServerAddr.Size = new Size(160, 30);
            button_setServerAddr.TabIndex = 2;
            button_setServerAddr.Text = "Set Server IP";
            button_setServerAddr.UseVisualStyleBackColor = true;
            button_setServerAddr.Click += button_setServerAddr_Click;
            // 
            // textBox_serverIP
            // 
            textBox_serverIP.Location = new Point(223, 23);
            textBox_serverIP.Name = "textBox_serverIP";
            textBox_serverIP.Size = new Size(157, 23);
            textBox_serverIP.TabIndex = 3;
            textBox_serverIP.Text = "192.168.0.101";
            // 
            // label_signal
            // 
            label_signal.BackColor = Color.Red;
            label_signal.BorderStyle = BorderStyle.FixedSingle;
            label_signal.Location = new Point(267, 419);
            label_signal.Name = "label_signal";
            label_signal.Size = new Size(30, 32);
            label_signal.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 510);
            Controls.Add(label_signal);
            Controls.Add(textBox_serverIP);
            Controls.Add(button_setServerAddr);
            Controls.Add(listBox);
            Controls.Add(button_trigger);
            Controls.Add(button_start);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_start;
        private ListBox listBox;
        private Button button_trigger;
        private Button button_setServerAddr;
        private TextBox textBox_serverIP;
        private Label label_signal;
    }
}
