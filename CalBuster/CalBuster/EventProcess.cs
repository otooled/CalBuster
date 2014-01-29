using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalBuster
{
    public class EventProcess
    {
        public delegate void MyDelegate(string x, string y, string z);
        public event MyDelegate MyEvent;		

        public void Process(string x, string y, string z)
        {
            Event ev = new Event();

            MyEvent += new MyDelegate(ev.sendEmails);     
           
            MyEvent(x,y,z);				
        }
    }
}