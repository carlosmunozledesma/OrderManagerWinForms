using System.Collections.Concurrent;
using System.Diagnostics;

namespace OrderSimulator
{
    public partial class MainForm : Form
    {
        private int orderCounter = 1;
        private ConcurrentDictionary<string, Order> orders = new ConcurrentDictionary<string, Order>();

        public MainForm()
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
            listViewItem.SubItems.Add(order.Status.ToString());
            listViewItem.SubItems.Add(order.StartTime.ToString("HH:mm:ss"));
            listViewItem.SubItems.Add(""); // End time
            listViewItem.SubItems.Add(""); // Progress
            listViewOrders.Items.Add(listViewItem);

            ProcessOrderAsync(order, listViewItem);
        }

        private async void ProcessOrderAsync(Order order, ListViewItem listViewItem)
        {
            var token = order.CancellationTokenSource.Token;
            var stopwatch = Stopwatch.StartNew();

            try
            {
                Log($"[Order {order.Id}] Started processing...");

                // Simulated initial wait (1 second)
                await Task.Delay(1000, token);

                order.Status = OrderStatus.Processing;
                UpdateListView(listViewItem, order);
                Log($"[Order {order.Id}] Now processing...");

                int totalDurationMs = order.DurationInSeconds * 1000;
                int step = 100; // ms per update
                int steps = totalDurationMs / step;

                for (int i = 1; i <= steps; i++)
                {
                    await Task.Delay(step, token); // Non-blocking
                    token.ThrowIfCancellationRequested();

                    order.Progress = (i * 100) / steps;
                    UpdateListView(listViewItem, order);
                }

                order.Status = OrderStatus.Completed;
                order.EndTime = DateTime.Now;
                UpdateListView(listViewItem, order);
                Log($"[Order {order.Id}] Completed.");
            }
            catch (OperationCanceledException)
            {
                order.Status = OrderStatus.Cancelled;
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

            listViewItem.SubItems[1].Text = order.Status.ToString();
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
                if (order.Status == OrderStatus.Pending || order.Status == OrderStatus.Processing)
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
                    case OrderStatus.Pending:
                        backColor = Color.LightYellow;
                        break;
                    case OrderStatus.Processing:
                        backColor = Color.LightBlue;
                        break;
                    case OrderStatus.Completed:
                        backColor = Color.LightGreen;
                        break;
                    case OrderStatus.Cancelled:
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
