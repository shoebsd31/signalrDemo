using Common.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IAction
    {
        void Save(IOTMessage message);
    }
}
