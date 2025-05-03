namespace OrderSimulator
{
    partial class MainForm
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
            btnGenerateOrder = new Button();
            listViewOrders = new BufferedListView();
            btnCancelOrder = new Button();
            txtLog = new TextBox();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerateOrder
            // 
            btnGenerateOrder.BackColor = Color.SteelBlue;
            btnGenerateOrder.ForeColor = Color.White;
            btnGenerateOrder.Location = new Point(188, 37);
            btnGenerateOrder.Name = "btnGenerateOrder";
            btnGenerateOrder.Size = new Size(209, 85);
            btnGenerateOrder.TabIndex = 0;
            btnGenerateOrder.Text = "Generate Order";
            btnGenerateOrder.UseVisualStyleBackColor = false;
            btnGenerateOrder.Click += btnGenerateOrder_Click;
            // 
            // listViewOrders
            // 
            listViewOrders.Dock = DockStyle.Bottom;
            listViewOrders.FullRowSelect = true;
            listViewOrders.GridLines = true;
            listViewOrders.Location = new Point(0, 270);
            listViewOrders.Name = "listViewOrders";
            listViewOrders.OwnerDraw = true;
            listViewOrders.Size = new Size(566, 180);
            listViewOrders.TabIndex = 1;
            listViewOrders.UseCompatibleStateImageBehavior = false;
            listViewOrders.View = View.Details;
            listViewOrders.DrawColumnHeader += listViewOrders_DrawColumnHeader;
            listViewOrders.DrawSubItem += listViewOrders_DrawSubItem;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.BackColor = Color.Brown;
            btnCancelOrder.ForeColor = SystemColors.Window;
            btnCancelOrder.Location = new Point(242, 147);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(112, 23);
            btnCancelOrder.TabIndex = 2;
            btnCancelOrder.Text = "Cancel Order";
            btnCancelOrder.UseVisualStyleBackColor = false;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // txtLog
            // 
            txtLog.Dock = DockStyle.Right;
            txtLog.Location = new Point(566, 0);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(234, 450);
            txtLog.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 244);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Orders";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(528, 9);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 5;
            label2.Text = "Logs";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnGenerateOrder);
            panel1.Controls.Add(btnCancelOrder);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listViewOrders);
            Controls.Add(txtLog);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Concurrency Order Simulator";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGenerateOrder;
        private BufferedListView listViewOrders;
        private Button btnCancelOrder;
        private TextBox txtLog;
        private Label label1;
        private Label label2;
        private Panel panel1;
    }
}
