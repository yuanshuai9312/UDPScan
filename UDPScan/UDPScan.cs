using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
namespace UDPScan
{
    public partial class UDPScan : Form
    {
        IPAddress IP;
        //主线程
        private Thread tdm;
        //开始端口，结束端口
        int Start, End;
        //线程数
        private int count = 0;
        //当前扫描端口
        private int i;
        //Delegate数据结构定义
        public delegate void DelegateFunction(int status, int i);
        private DelegateFunction m_delegateFunction;
        //按钮显示委托操作
        private delegate void DelegateButton(Button but);
        private DelegateButton but_delegate;
        /// <summary>
        /// 构造函数
        /// </summary>
        public UDPScan()
        {
            InitializeComponent();
            //当前要扫描的ＩＰ地址
            string HostName = Dns.GetHostName(); //得到主机名           
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName); //得到主机IP 
            int ii = 0;
            for (; ii < IpEntry.AddressList.Length; ii++)
            {
                if (IpEntry.AddressList[ii].AddressFamily == AddressFamily.InterNetwork)
                    break;
            }
            tbipFrom.Text = IpEntry.AddressList[ii].ToString();
            this.m_delegateFunction = new DelegateFunction(subFunctionUDP);
            this.but_delegate = new DelegateButton(but_Protect);
        }

        private void but_Protect(Button but)
        {
            but.Enabled = true;
        }

        /// <summary>
        /// tcp scan
        /// </summary>
        private void buttonTcp_Click(object sender, EventArgs e)
        {
            try
            {
                IP = IPAddress.Parse(tbipFrom.Text);
            }
            catch
            {
                MessageBox.Show("请输入合法地址");
                return;
            }
            buttonTcp.Enabled = false;
            listViewRes.Items.Clear();
            Thread tmain = new Thread(new ThreadStart(MainProcessTCP));
            tmain.Start();
        }


        /// <summary>
        /// udp scan
        /// </summary>
        private void buttonUdpStart_Click(object sender, EventArgs e)
        {
            try
            {
                IP = IPAddress.Parse(tbipFrom.Text);
            }
            catch
            {
                MessageBox.Show("请输入合法地址");
                return;
            }
            buttonUdp.Enabled = false;
            listViewRes.Items.Clear();
            Thread tmain = new Thread(new ThreadStart(MainProcessUDP));
            tmain.Start();
        }

        //tcp 主线程
        #region
        private void MainProcessTCP()
        {
            count = 0;
            Start = Convert.ToInt32(tbstart.Text);
            End = Convert.ToInt32(tbend.Text);

            //循环取副线程扫描端口
            for (i = Start; i <= End; i++)
            {
                count++;

                //tdm.Start();

                ParameterizedThreadStart ParStart = new ParameterizedThreadStart(ProcessTCP);

                tdm = new Thread(ParStart);
                object o = i;

                tdm.Start(o);

                Thread.Sleep(10);
                //线程数控制在２０
                while (count > 20) ;

            }
            while (count > 0) ;
            MessageBox.Show("检测完成！");
            this.Invoke(but_delegate, buttonTcp);
        }
        #endregion

        /**/
        /// <summary>
        /// tcp 副线程
        /// </summary>
        #region
        private void ProcessTCP(object i)
        {
            //当前要扫描的ＩＰ地址

            int port = (int)i;
            TcpClient tc = new TcpClient();

            try
            {
                tc.SendTimeout = tc.ReceiveTimeout = 20000;
                //建立连接
                tc.Connect(IP, port);

                //判断是否连接成功
                if (tc.Connected)
                {

                    this.Invoke(m_delegateFunction, 0, port);

                }
                else
                {
                    this.Invoke(m_delegateFunction, 1, port);
                }

            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10061)
                {
                    this.Invoke(m_delegateFunction, 1, port);
                }
            }
            finally
            {
                if (tc != null)
                {
                    tc.Close();
                    tc = null;
                }

                //修改线程数
                count--;
            }
        }
        #endregion


        //udp 主线程
        #region
        private void MainProcessUDP()
        {
            count = 0;
            Start = Convert.ToInt32(tbstart.Text);
            End = Convert.ToInt32(tbend.Text);
            //循环取副线程扫描端口
            for (i = Start; i <= End; i++)
            {
                count++;
                ParameterizedThreadStart ParStart = new ParameterizedThreadStart(ProcessUDP);
                tdm = new Thread(ParStart);
                object o = i;
                tdm.Start(o);
                Thread.Sleep(10);
                //线程数控制在２０
                while (count > 1) ;
            }
            while (count > 0) ;
            MessageBox.Show("检测完成！");
            this.Invoke(but_delegate, buttonUdp);
        }
        #endregion

        /**/
        /// <summary>
        /// udp 副线程
        /// </summary>
        #region
        private void ProcessUDP(object i)
        {
            //当前要扫描的ＩＰ地址
            string HostName = Dns.GetHostName(); //得到主机名           
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName); //得到主机IP 
            int ii = 0;
            //得到IPv4
            for (; ii < IpEntry.AddressList.Length; ii++)
            {
                if (IpEntry.AddressList[ii].AddressFamily == AddressFamily.InterNetwork)
                    break;
            }
            //得到本机IPV4地址
            string strIPAddr = IpEntry.AddressList[ii].ToString();
            //拆箱
            int port = (int)i;
            //得到IP地址
            IP = IPAddress.Parse(strIPAddr);
            EndPoint ep = null;
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //管理员方式才能正确执行此句代码  需要管理员权限
            Socket icmp = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
            byte[] data = Encoding.ASCII.GetBytes("hello,jun");
            IPEndPoint ipe = new IPEndPoint(IP, port);
            ep = (EndPoint)ipe;
            try
            {
                //绑定网络地址
                icmp.Bind(ep);
                //将指定的 System.Net.Sockets.Socket 选项设置为指定的整数值。
                icmp.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 500);
                ipe.Address = IPAddress.Parse(tbipFrom.Text);
                ep = (EndPoint)ipe;
                sock.SendTo(data, ep);//先发送数据包

                data = new byte[1024];
                byte[] message = new byte[1024];

                int len = icmp.ReceiveFrom(data, ref ep);//接收ICMP包
                byte type = data[20];
                byte code = data[21];
                UInt16 check = BitConverter.ToUInt16(data, 22);
                int messagesize = len - 24;
                Buffer.BlockCopy(data, 24, message, 0, messagesize);
                this.Invoke(m_delegateFunction, 1, port);
            }
            catch (SocketException)//如果没收到ICMP，认为端口开放
            {
                this.Invoke(m_delegateFunction, 0, port);
            }
            //修改线程数
            count--;
        }
        #endregion
        /// <summary>
        /// 委托函数 显示扫描结果
        /// </summary>
        #region
        void subFunctionUDP(int status, int port)
        {
            ListViewItem item = new ListViewItem(listViewRes.Items.Count.ToString());
            item.SubItems.Add(port.ToString());
            if (status == 0)
            {
                item.SubItems.Add("open");
            }
            else
                item.SubItems.Add("close");
            listViewRes.Items.Add(item);
        }
        #endregion
        /// <summary>
        /// 窗口退出提示
        /// </summary>
        #region
        private void UDPScan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }
        #endregion
    }
}
