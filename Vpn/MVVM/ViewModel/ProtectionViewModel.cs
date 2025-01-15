﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vpn.Core;

namespace Vpn.MVVM.ViewModel
{
    internal class ProtectionViewModel : ObservableObject
    {
        public ObservableCollection<ServerModel> Servers { get; set; }

        private string _connectionStatus;

        public string ConnectionStatus
        {
            get { return _connectionStatus; }
            set { _connectionStatus = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand ConnectCommand { get; set; }

        public ProtectionViewModel() 
        {
            Servers= new ObservableCollection<ServerModel>();
            for (int i = 0; i < 10; i++)
            {
                Servers.Add(new ServerModel
                {
                    Country ="USA"
                });

            }

            ConnectCommand = new RelayCommand(o => { ConnectionStatus = "Connection..";});
            ServerBuilder();
        }

        private void ServerBuilder()
        {
            var address = "";
            var FolderPath = $"{Directory.GetCurrentDirectory()}/VPN";
            var PbkPath = $"{FolderPath}/{address}.pbk";

            if(!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            if(File.Exists(PbkPath))
            {
                MessageBox.Show("Connection alredy exists!");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("[MyServer]");
            sb.AppendLine("MEDIA=rastap");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine($"PhoneNumber={address}");
            File.WriteAllText(PbkPath, sb.ToString());
        }
    }
}
