using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Client_TCP_Dispetcher_Final
{
    internal class Controller
    {
        public delegate void ControllerEventHandler(string msg);    //инициализация формы сообщением
        public event ControllerEventHandler SetMessageToForm;               

        public delegate string ControllerEventGetMessage();//взятие сообщения с формы
        public event ControllerEventGetMessage GetMessageFromForm;

        Socket sock;

        public Controller() { }

        public void SetMessageToFormString(string text) => SetMessageToForm(text);      //инициализация формы сообщением (в данном случае елементами листа процессов)
        public string GetMessageFromFormString(string text) => text;            //взять комманду ( в данном случае выбранный item из listbox


        public void Connect()           //коннект с сервером
        {
            try
            {
                IPAddress ipAddr = IPAddress.Loopback;
                IPEndPoint iPEndPoint = new IPEndPoint(ipAddr, 49152);
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(iPEndPoint);
                byte[] msg = Encoding.UTF8.GetBytes(Dns.GetHostName());
                int bytesSent = sock.Send(msg);
                MessageBox.Show("Клиент: " + Dns.GetHostName() + " установил соежинение с " + sock.RemoteEndPoint.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        public void AskListProcess()        //запрос сервера на лист процессов
        {
            string theMessage = "";
            try
            {
                theMessage = "List Process";
                byte[] msg = Encoding.UTF8.GetBytes(theMessage);
                int bytesSent = sock.Send(msg);
                Thread thread = new Thread(() => WaitAnswerFromServer());
                thread.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Клиент: " + ex.Message);
            }
        }


      public void WaitAnswerFromServer()        //ожидание овтета с листом процессов и инициализация листбокса
        {
            Dictionary<int, string> listProcess = null;
            try
            {
                var bytes = new byte[sock.ReceiveBufferSize];
                int byteRec = sock.Receive(bytes);
               
                MemoryStream memoryStream = new MemoryStream(bytes);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                MessageBox.Show("Получили лист от сервера");

                listProcess = (Dictionary<int, string>)binaryFormatter.Deserialize(memoryStream);
                memoryStream.Close();
               
                foreach (var el in listProcess)
                {
                     SetMessageToForm("Process : " + el.Key + " :" + el.Value);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Клиент: " + ex.Message);
            }
        }






        public void SendCommandToKillProcessOnServer()          //отправить запрос на сервер на убийство процесса
        {

            MessageBox.Show("Start SendCommandToKillProcessOnServer  CLIENT");
            int IdProcess = NumberProcess(GetMessageFromForm());
            string theMessage = $"kill process id + {IdProcess}";
            byte[] msg = Encoding.UTF8.GetBytes(theMessage);
            sock.Send(msg);
            Thread thread = new Thread(() => WaitReportFromServer());
            thread.Start();
        
        }


        public void WaitReportFromServer()          //получение ответа от сервера по поводу убийства процесса
        {
            string str = null;
            try
            {
                var bytes = new byte[sock.ReceiveBufferSize];
                sock.Receive(bytes);

                MemoryStream memoryStream = new MemoryStream(bytes);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                var res = binaryFormatter.Deserialize(memoryStream);

                MessageBox.Show(res.ToString());            //и вывод отчета в месседжбокс

            }
            catch (Exception ex)
            {

                MessageBox.Show("Клиент: " + ex.Message);
            }
        }

        public int NumberProcess(string text)       //извлечь из строки айди процесса
        {
            int i;
            int.TryParse(string.Join("", text.Where(c => char.IsDigit(c))), out i);
            return i;
        }





    }
}
