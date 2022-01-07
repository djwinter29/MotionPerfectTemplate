using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using Serilog;

namespace MotionConnector
{
    public abstract class Control
    {
        public abstract void Update(Connector con, ushort[] int16_reg, ushort[] float_reg);
    }
    public abstract class Connector
    {
        private bool running = true;

        protected readonly ConnectorConfigs cfg;
        protected Control Controls;


        protected Connector()
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logfile.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

                Log.Debug("Starting up");

                cfg = JsonConvert.DeserializeObject<ConnectorConfigs>(File.ReadAllText("MotionKits.json"));

                StartModbusPoll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #region Private Metherds

        private void StartModbusPoll()
        {
            Task.Run(() =>
            {
                Thread.Sleep(1000); // wait 1 seconds

                while (running)
                {
                    foreach (var pair in cfg.RegisterBlocks)
                    {
                        RegisterBlock rb = pair.Value;

                        ushort[] regs = ReadRegisters(rb.StartAddress, rb.Count);

                        if (regs != null)
                        {
                            rb.Update(regs);
                        }
                    }
                    // Update the control registers
                    ushort[] regs16 = ReadRegisters(30000, 100);
                    ushort[] regsfloat = ReadRegisters(31000, 100);
                    Controls.Update(this, regs16, regsfloat);

                    Thread.Sleep(cfg.Settings.Interval);
                }
            });
        }

        protected void WriteRegister(ushort start, ushort value)
        {
            WriteRegisters(start, new ushort[] { value });
        }

        protected void WriteRegister(ushort start, int value)
        {
            ushort[] regs = new ushort[2];

            regs[0] = BitConverter.ToUInt16(BitConverter.GetBytes(value).Take(2).ToArray(), 0);
            regs[1] = BitConverter.ToUInt16(BitConverter.GetBytes(value).Skip(2).Take(2).ToArray(), 0);

            WriteRegisters(start, regs);
        }

        protected void WriteRegister(ushort start, float value)
        {
            ushort[] regs = new ushort[2];
            regs[0] = BitConverter.ToUInt16(BitConverter.GetBytes(value).Take(2).ToArray(), 0);
            regs[1] = BitConverter.ToUInt16(BitConverter.GetBytes(value).Skip(2).Take(2).ToArray(), 0);

            WriteRegisters(start, regs);
        }

        #endregion

        ~Connector()
        {
            running = false;
        }

        #region Abstract classes
        public abstract ushort[] ReadRegisters(ushort start, ushort count);

        public abstract void WriteRegisters(ushort start, ushort[] regs);

        public abstract void RunRoutine(ushort rt_idx, List<float> parameters);

        #endregion

        public string ConnectorAddress
        {
            get
            {
                return cfg.Settings.IPAddress;
            }
        }


        #region Routine related method
        public List<string> RoutineNames
        {
            get
            {
                return cfg.Routine.Select(v => v.Key).ToList();
            }
        }

        public string GetRoutineName(int rt_idx)
        {
            var ret = cfg.Routine.Where(a => a.Value.Index == rt_idx)
                     .Select(a => a.Key)
                     .ToList();
            return (ret.Count == 0) ? "unknown" : ret[0];
        }

        public int FindRoutineIndexInList(int rt_idx)
        {
            return RoutineNames.FindIndex(a => a.Contains(GetRoutineName(rt_idx)));
        }

        public Routine GetRoutine(string name)
        {
            return cfg.Routine[name];
        }

        #endregion

        #region Register related method
        public List<string> RegisterGroups
        {
            get
            {
                //walkthough all register blocks and registers, find all groups
                List<string> gp = new List<string>();
                foreach(var blk in cfg.RegisterBlocks)
                {
                    gp.AddRange(blk.Value.Registers.Select(x => x.Group));
                }
                return gp.Distinct().ToList();
            }
        }
        public string GetErrorString(int error)
        {
            var ret = cfg.ErrorCode.Where(x => x.Key == error).Select(x => x.Value).ToList();

            return (ret.Count == 0) ? $"Unknown({error})" : ret[0];
        }

        public BindingList<RegisterBlock.Register> GetRegisters(string group)
        {
            BindingList<RegisterBlock.Register> rg = new BindingList<RegisterBlock.Register>();
            foreach (var blk in cfg.RegisterBlocks)
            {
                var lists = blk.Value.Registers.Where(x => x.Group.Equals(group));
                foreach(var item in lists)
                {
                    rg.Add(item);
                }
            }

            return rg;
        }



        #endregion

        public void CancelRoutine()
        {
            WriteRegister(30000, (ushort)100);
        }

    }
}
