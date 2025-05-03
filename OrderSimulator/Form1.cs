using System.Collections.Concurrent;

namespace OrderSimulator
{
    public partial class Form1 : Form
    {
        private int orderCounter = 1;
        private ConcurrentDictionary<string, Order> orders = new ConcurrentDictionary<string, Order>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewOrders.View = View.Details;
            listViewOrders.Columns.Add("ID", 80);
            listViewOrders.Columns.Add("Status", 100);
            listViewOrders.Columns.Add("Start Time", 120);
            listViewOrders.Columns.Add("End Time", 120);
            listViewOrders.Columns.Add("Progress", 100);
        }

        private void btnGenerateOrder_Click(object sender, EventArgs e)
        {
            string id = $"ORD-{orderCounter++}";
            var order = new Order { Id = id, StartTime = DateTime.Now };
            orders[id] = order;

            var listViewItem = new ListViewItem(id);
            listViewItem.SubItems.Add(order.Status);
            listViewItem.SubItems.Add(order.StartTime.ToString("HH:mm:ss"));
            listViewItem.SubItems.Add(""); // End time
            listViewItem.SubItems.Add(""); // Progress
            listViewOrders.Items.Add(listViewItem);

            ProcessOrderAsync(order, listViewItem);
        }

        private async void ProcessOrderAsync(Order order, ListViewItem listViewItem)
        {
            var token = order.CancellationTokenSource.Token;

            try
            {
                await Task.Run(() =>
                {
                    Log($"[Order {order.Id}] Started processing...");

                    Thread.Sleep(3000); // Simulated initial wait
                    token.ThrowIfCancellationRequested();

                    order.Status = "Processing";
                    UpdateListView(listViewItem, order);
                    Log($"[Order {order.Id}] Now processing...");

                    for (int i = 1; i <= 100; i++)
                    {
                        Thread.Sleep(30); // Simulate work
                        token.ThrowIfCancellationRequested();
                        order.Progress = i;
                        UpdateListView(listViewItem, order);
                    }

                    order.Status = "Completed";
                    order.EndTime = DateTime.Now;
                    UpdateListView(listViewItem, order);
                    Log($"[Order {order.Id}] Completed.");
                }, token);
            }
            catch (OperationCanceledException)
            {
                order.Status = "Cancelled";
                order.EndTime = DateTime.Now;
                UpdateListView(listViewItem, order);
                Log($"[Order {order.Id}] Cancelled.");
            }
        }


        private void UpdateListView(ListViewItem listViewItem, Order order)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateListView(listViewItem, order)));
                return;
            }

            listViewItem.SubItems[1].Text = order.Status;
            listViewItem.SubItems[3].Text = order.EndTime?.ToString("HH:mm:ss") ?? "";
            listViewItem.SubItems[4].Text = $"{order.Progress}%";
            listViewOrders.Invalidate(); // Redibuja para aplicar colores
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 0)
                return;

            var selectedItem = listViewOrders.SelectedItems[0];
            string orderId = selectedItem.Text;

            if (orders.TryGetValue(orderId, out Order order))
            {
                if (order.Status == "Pending" || order.Status == "Processing")
                {
                    order.CancellationTokenSource.Cancel();
                }
            }
        }

        private void Log(string message)
        {
            if (txtLog.InvokeRequired)
            {
                Invoke(new Action(() => Log(message)));
                return;
            }

            txtLog.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
        }

        private void listViewOrders_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var item = e.Item;
            var orderId = item.Text;

            Color backColor = Color.White;
            Color foreColor = Color.Black;

            if (orders.TryGetValue(orderId, out Order order))
            {
                switch (order.Status)
                {
                    case "Pending":
                        backColor = Color.LightYellow;
                        break;
                    case "Processing":
                        backColor = Color.LightBlue;
                        break;
                    case "Completed":
                        backColor = Color.LightGreen;
                        break;
                    case "Cancelled":
                        backColor = Color.LightCoral;
                        break;
                }
            }

            // Si está seleccionado, cambia el borde o fondo
            if (item.Selected)
            {
                backColor = Color.DodgerBlue;
                foreColor = Color.White;
            }

            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, listViewOrders.Font, e.Bounds, foreColor, TextFormatFlags.Left);
        }

        private void listViewOrders_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
}
