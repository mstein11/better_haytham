
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Haytham
{
    public  class ProcessTime
    {
        public Dictionary<string, object> TimerResults = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="order">"Start" or "Stop"</param>
        public void Timer(string flag,string order)
        { 
            //if(METState.Current.TimerEnable==true)
            //{
                switch (order)
                {
                    case "Start":
                        UpdateTimerResults(flag, DateTime.Now);
                        break;

                    case "Stop":

                        TimeSpan elapsed = DateTime.Now - (DateTime)TimerResults[flag];
                        UpdateTimerResults(flag, Math.Round(elapsed.TotalMilliseconds, 2));
                        break;
                }
           // }
        }
        private void UpdateTimerResults(string flag, object time)
        {
                    if (TimerResults.ContainsKey(flag) == true)
                    {
                        TimerResults[flag] = time;
                    }
                    else
                    {
                        TimerResults.Add(flag, time);
                    }
                    
        }


    }
}
