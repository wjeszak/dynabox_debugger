namespace DynaboxDebugger
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
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.ports = new System.Windows.Forms.ComboBox();
            this.button_connection = new System.Windows.Forms.Button();
            this.preview = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // serial
            // 
            this.serial.BaudRate = 19200;
            this.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_DataReceived);
            // 
            // ports
            // 
            this.ports.FormattingEnabled = true;
            this.ports.Location = new System.Drawing.Point(12, 12);
            this.ports.Name = "ports";
            this.ports.Size = new System.Drawing.Size(121, 21);
            this.ports.TabIndex = 1;
            // 
            // button_connection
            // 
            this.button_connection.Location = new System.Drawing.Point(139, 10);
            this.button_connection.Name = "button_connection";
            this.button_connection.Size = new System.Drawing.Size(75, 23);
            this.button_connection.TabIndex = 2;
            this.button_connection.Text = "Connect";
            this.button_connection.UseVisualStyleBackColor = true;
            this.button_connection.Click += new System.EventHandler(this.button_connection_Click);
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(247, 10);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(354, 222);
            this.preview.TabIndex = 3;
            this.preview.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 256);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.button_connection);
            this.Controls.Add(this.ports);
            this.Name = "Form1";
            this.Text = "Dynabox Debugger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.ComboBox ports;
        private System.Windows.Forms.Button button_connection;
        private System.Windows.Forms.RichTextBox preview;
    }
}

