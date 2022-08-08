using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Clock
    {
        Counter _seccond = new Counter("seccond");
        Counter _minute = new Counter("minute");
        Counter _hour = new Counter("hour");


        public void Tick()
        {
            _seccond.Increment();
            if(_seccond.Tick>59)
            {
                _minute.Increment();
                _seccond.Reset();
                if (_minute.Tick>59)
                {
                    _hour.Increment();
                    _minute.Reset();
                    if (_hour.Tick>23)
                    {
                        Reset();
                    }
                }
            }
        }

        public void Reset()
        {
            _seccond.Reset();
            _minute.Reset();
            _hour.Reset();
        }

        public string CurrentTime()
        {
            return $"{_hour.Tick:D2}:{_minute.Tick:D2}:{_seccond.Tick:D2}"; 
        }
    }
}

