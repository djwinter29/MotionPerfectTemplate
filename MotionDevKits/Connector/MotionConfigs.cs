using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MotionConnector
{
    public class ConnectorConfigs
    {
        [JsonProperty("Settings")]
        public ModbusTCPSettings Settings { get; set; }

        [JsonProperty("RegisterBlocks")]
        public Dictionary<string, RegisterBlock> RegisterBlocks { get; set; }

        [JsonProperty("Routine")]
        public Dictionary<string, Routine> Routine { get; set; }

        [JsonProperty("ErrorCode")]
        public Dictionary<int, string> ErrorCode { get; set; }
    }


    public class ModbusTCPSettings
    {
        [JsonProperty("IPAddress")]
        public string IPAddress { get; set; } = "127.0.0.1";

        [JsonProperty("Port")]
        public int Port { get; set; } = 502;

        [JsonProperty("Interval")]
        public int Interval { get; set; } = 1000;

    }

    public class RegisterBlock
    {
        public static float GetFloat(ushort[] raw, int offset)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(((uint)raw[offset + 1] << 16) + raw[offset]), 0);
        }

        #region Inner classes
        public enum RegisterType
        {
            Int16,
            Int32,
            Float,
            Hex16
        }

        public class Register : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private int baseaddress;
            private string regvalue;

            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            #region Properties (Json Configuration)
            [JsonProperty("Name")]
            public string Name { get; set; } = "RegisterName";

            [JsonProperty("Offset")]
            [Browsable(false)]
            public int Offset { get; set; } = 0;

            [JsonProperty("Group")]
            [Browsable(false)]
            public string Group { get; set; } = "Default";

            [JsonProperty("RegType")]
            [JsonConverter(typeof(StringEnumConverter))]
            [Browsable(false)]
            public RegisterType RegType { get; set; } = RegisterType.Int16;

            #endregion
            [DisplayName("Modbus Address")]
            public int Address
            {
                get
                {
                    return baseaddress + Offset;
                }
                private set
                {
                    if (baseaddress != value)
                    {
                        baseaddress = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            [DisplayName("Register Value")]
            public string Value
            {
                get
                {
                    return regvalue;
                }
                private set
                {
                    if (regvalue != value)
                    {
                        regvalue = value;
                        NotifyPropertyChanged();
                    }
                }
            }

            public void Update(int startaddr,ushort[] reg)
            {
                Address = startaddr;

                switch (RegType)
                {
                    case RegisterType.Int16:
                        Value = reg[Offset].ToString();
                        break;
                    case RegisterType.Hex16:
                        Value = reg[Offset].ToString("X4");
                        break;
                    case RegisterType.Int32:
                        Value = (((int)reg[Offset + 1] << 16) + reg[Offset]).ToString();
                        break;
                    case RegisterType.Float:
                        Value = RegisterBlock.GetFloat(reg, Offset).ToString();
                        break;
                    default:
                        Value = reg[Offset].ToString();
                        break;
                }

            }

        }
        #endregion


        #region Properties (Json Configuration)

        [JsonProperty("StartAddress")]
        public ushort StartAddress { get; set; } = 20000;

        [JsonProperty("Count")]
        public ushort Count { get; set; } = 1;


        [JsonProperty("Registers")]
        public List<Register> Registers { get; set; }

        #endregion

        public void Update(ushort[] newdata)
        {
            foreach(var r in Registers)
            {
                r.Update(StartAddress, newdata);
            }
        }

    }

    public class Routine
    {
        #region Inner classes
        public class RoutineParameter
        {
            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Value")]
            public float DefaultValue { get; set; }
        }
        #endregion

        #region Properties (Json Configuration)

        [JsonProperty("Index")]
        public int Index { get; set; } = 0;

        [JsonProperty("Timeout")]
        public int Timeout { get; set; } = 0;

        [JsonProperty("Parameters")]
        public List<RoutineParameter> Parameter { get; set; }

        #endregion
    }

}
