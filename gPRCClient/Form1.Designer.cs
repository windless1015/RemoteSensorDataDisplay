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
            SuspendLayout();
            // 
            // button_start
            // 
            button_start.Location = new Point(56, 49);
            button_start.Name = "button_start";
            button_start.Size = new Size(140, 23);
            button_start.TabIndex = 0;
            button_start.Text = "ContinousDataDisplay";
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += button_start_Click;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(217, 12);
            listBox.Name = "listBox";
            listBox.Size = new Size(195, 244);
            listBox.TabIndex = 1;
            // 
            // button_trigger
            // 
            button_trigger.Location = new Point(56, 363);
            button_trigger.Name = "button_trigger";
            button_trigger.Size = new Size(140, 23);
            button_trigger.TabIndex = 0;
            button_trigger.Text = "TriggerOnce";
            button_trigger.UseVisualStyleBackColor = true;
            button_trigger.Click += button_start_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox);
            Controls.Add(button_trigger);
            Controls.Add(button_start);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button_start;
        private ListBox listBox;
        private Button button_trigger;
    }
}
