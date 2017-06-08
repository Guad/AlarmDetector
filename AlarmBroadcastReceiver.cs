using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Android.App;
using Android.Content;
using Android.Widget;

namespace AlarmDetector
{
    [IntentFilter(new []
    {
        ALARM_ALERT_ACTION,
    })]
    [BroadcastReceiver(Enabled = true, Exported = true)]
    public class AlarmBroadcastReceiver : BroadcastReceiver
    {
        public const string ALARM_ALERT_ACTION = "com.android.deskclock.ALARM_ALERT";
        
        /// <summary>
        /// Code to execute when an alarm is triggered.
        /// </summary>
        public override void OnReceive(Context context, Intent intent)
        {
            
        }

        private void ExampleWakeOnLan(byte[] mac)
        {
            using (var client = new UdpClient())
            {
                client.Connect(IPAddress.Broadcast, 40000);

                byte[] packet = new byte[17 * 6];

                for (int i = 0; i < 6; i++)
                    packet[i] = 0xFF;

                for (int i = 1; i <= 16; i++)
                for (int j = 0; j < 6; j++)
                    packet[i * 6 + j] = mac[j];

                client.Send(packet, packet.Length);
            }
        }
    }
}