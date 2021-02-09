using System;
using System.Collections.Generic;
using System.Text;

namespace XANTI.Services
{
    public interface ICrossPlatform
    {
        void StartTask(int actionId);
        void StopTask();
    }
}
