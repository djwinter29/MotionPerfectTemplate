using NModbus;
using System;
using System.Net.Sockets;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MotionConnector
{
    public class ModbusControl : Control
    {
        public class HistoryRun : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private ushort runCount;
            private string routine;
            private string result;
            private float runTime;

            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            [DisplayName("Run Index")]
            public ushort RunCount 
            {   get
                {
                    return runCount;
                }
                set
                {
                    if (runCount != value)
                    {
                        runCount = value;
                        NotifyPropertyChanged();
                    }
                }
            }

            [DisplayName("Routine Name")]
            public string Routine
            {
                get
                {
                    return routine;
                }
                set
                {
                    if (routine != value)
                    {
                        routine = value;
                        NotifyPropertyChanged();
                    }
                }
            }

            [DisplayName("Elapsed(ms)")]
            public float RunTime
            {
                get
                {
                    return runTime;
                }
                set
                {
                    if (runTime != value)
                    {
                        runTime = value;
                        NotifyPropertyChanged();
                    }
                }
            }

            [DisplayName("Result")]
            public string Result
            {
                get
                {
                    return result;
                }
                set
                {
                    if (result != value)
                    {
                        result = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }

        public ModbusControl()
        {
            History = new BindingList<HistoryRun>();
            for (int i = 0; i < 3; i++)
            {
                History.Add(new HistoryRun());
            }    
        }

        public ushort RequestCount { get; private set; }
        public ushort ResponseCount { get; private set; }
        public ushort Routine { get; private set; }
        public float[] RoutineParameter
        {
            get;
        } = new float[4];   

        public BindingList<HistoryRun> History
        {
            get;
        }

        public override void Update(Connector con, ushort [] int16_reg, ushort[] float_reg)
        {
            RequestCount = int16_reg[0];
            ResponseCount = int16_reg[1];
            Routine  = int16_reg[2];
            for(int i =0; i < 4; i ++)
            {
                RoutineParameter[i] = RegisterBlock.GetFloat(float_reg, i * 2);
            }

            for (int i = 0; i < 3; i++)
            {
                History[i].RunCount = int16_reg[i + 10];
                History[i].Routine = con.GetRoutineName(int16_reg[i + 20]);
                History[i].Result = con.GetErrorString(int16_reg[i + 30]);
                History[i].RunTime = RegisterBlock.GetFloat(float_reg, i * 2 + 20);
            }
        }
    }   

    public class ModbusTCPConnector : Connector
    {
        private readonly ModbusFactory factory = new ModbusFactory();
        private static Mutex mut = new Mutex();

        public ModbusTCPConnector()
        {
            Controls = new ModbusControl();
        }

        public override ushort[] ReadRegisters(ushort start, ushort count)
        {
            ushort[] regs = null;

            try
            {
                mut.WaitOne();
                using (TcpClient client = new TcpClient(cfg.Settings.IPAddress, cfg.Settings.Port))
                {
                    IModbusMaster master = factory.CreateMaster(client);

                    regs = master.ReadInputRegisters(0, start, count);
                }
                mut.ReleaseMutex();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

            return regs;
        }

        public override void WriteRegisters(ushort start, ushort[] regs)
        {
            try
            {
                mut.WaitOne();
                using (TcpClient client = new TcpClient(cfg.Settings.IPAddress, cfg.Settings.Port))
                {
                    IModbusMaster master = factory.CreateMaster(client);

                    master.WriteMultipleRegisters(0, start, regs);
                }
                mut.ReleaseMutex();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        public ModbusControl GetControl()
        {
            return (ModbusControl)Controls;
        }

        public bool Busy
        {
            get
            {
                ModbusControl ctrl = GetControl();
                return ctrl.RequestCount != ctrl.ResponseCount;
            }
        }

        public override void RunRoutine(ushort rt_idx, List<float> parameters)
        {
            int startindex = 0;
            foreach (float p in parameters)
            {
                WriteRegister((ushort)(31000 + startindex * 2), p);
                ++startindex;
            }
            WriteRegister(30002, rt_idx);

            ushort currentreq = GetControl().ResponseCount;
            // Now update the request
            WriteRegister(30000, ++currentreq);
        }

    }
}
